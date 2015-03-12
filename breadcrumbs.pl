#!/usr/bin/env perl

use strict;
use File::Copy qw(move);
use Util;

my %backRef = ();
my $identifier;

sub MakeKey(@)
{
    return join "$;", @_;
}

sub PrintCrumbs
{
    my $fh = shift;
    my $key = shift;

    # Output the top link
    print $fh "[ [[Top|$identifier]] ] [ ";

    my $first = 1;
    foreach my $val (split "$;", $key)
    {
        if (!$first)
	{
	    print $fh "/ ";
	}
	$first = 0;

        print $fh "[[$backRef{$val}|$identifier#$val]] ";
    }
    print $fh "]\n\n";
}

foreach my $file (@ARGV)
{
    $identifier = $file;
    $identifier =~ s/\.md$//;

    my %data;
    my $currentCount = 0;
    my @currentKey = ();

    my $minCount = 10;
    my $countAtLevel = 0;

    # First pass to look for the headings
    open IFILE, "<$file";
    my $line;
    while ($line = <IFILE>)
    {
        if ($line =~ /^#/ && $line !~ /Table of Contents/i)
        {
            my $count = () = $line =~ /#/g;

            # Logic for determining minCount
            if ($count < $minCount)
            {
                $minCount = $count if $count < $minCount;
            }
            if ($count == $minCount)
            {
                $countAtLevel++;
            }

            # If we're on a heading line
            if ($count > 0)
            {
                if ($count > $currentCount)
                {
                    $currentCount = $count;
                }
		elsif ($count < $currentCount)
		{
		    @currentKey = @currentKey[0..$count-1];
		}

                my $tag = Util::MakeTag($line);
		$currentKey[$count-1] = $tag;

                my $key = MakeKey(@currentKey);
		$data{$line} = $key;
		$backRef{$tag} = Util::MakeName($line);
            }
        }
    }
    close IFILE;

    if ($countAtLevel <= 1)
    {
        $minCount += 1;
    }

    # Rewrite with shortened values
    my %oldData = %data;
    %data = ();
    foreach my $key (keys %oldData)
    {
       my @vals = split "$;", $oldData{$key};
       $data{$key} = join "$;", @vals[$minCount-1..scalar(@vals)-1];
    }

    # Open in and out files
    open IFILE, "<$file";
    open OFILE, ">out.txt";

    # Start reading
    my $currentKey = "";
    my $lineIsEmpty = 0;
    while ($line = <IFILE>)
    {
        # Key line
        if (exists($data{$line}))
	{
	    # Existing key, print the breadcrumbs
	    if ($currentKey ne "")
	    {
	        PrintCrumbs(*OFILE, $currentKey);
	    }

            $currentKey = $data{$line};
	}
	# Existing breadcrumb line
	elsif($line =~ /^\[ \[\[Top/)
	{
            # Remove line and the one after
	    <IFILE>;
	    next;
	}

        # Add newline at EOF
        if ($line !~ /\n$/)
	{
	    $line .= "\n";
	}
	$lineIsEmpty = ($line eq "\n" || $line eq "\r\n");
        print ("line is [$line]");

	print OFILE $line;
    }

    # Last one, print crumbs
    if ($currentKey ne "")
    {
        if (!$lineIsEmpty)
	{
	    print OFILE "\n";
	}

	PrintCrumbs(*OFILE, $currentKey);
    }

    close IFILE;
    close OFILE;

    move("out.txt", $file);
}
