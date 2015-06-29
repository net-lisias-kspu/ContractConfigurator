#!/usr/bin/env perl

use strict;
use File::Copy qw(move);

my $rootDir;
my $outfh;

sub MakeName($)
{
    my $name = shift;

    # Get the tag
    my $tag = $name;
    $tag =~ s/\.md$//g;
    $tag =~ s/ *Parameter$//g;
    $tag =~ s/ *Requirement$//g;
    $tag =~ s/ *Behaviour$//g;
    $tag =~ s/[\/\(\)]//g;

    return $tag;
}

sub MakeTag($)
{
    my $name = shift;

    # Get the tag
    my $tag = $name;
    $tag =~ s/\.md$//g;
    $tag =~ s/ /-/g;
    $tag =~ s/[\/\(\)]//g;

    return $tag;
}

sub CleanFileName($)
{
    my $fname = shift;
    $fname =~ s/^\d+-//g;
    $fname =~ s/\/$//g;
    return $fname;
}

sub HandleDir($$)
{
    my $dir = shift;
    my $prefix = shift;

    my @prefixes = split /$;/, $prefix;
    my $count = scalar(@prefixes);
    my $spaces = ($count-1) * 4;
    if ($count == 1)
    {
        print $outfh "**$prefixes[-1]**\n"
    }
    else
    {
        print ($outfh (' ' x ($spaces-4)), "* ", $prefixes[-1], "\n");
    }
    
    my $dh;
    opendir $dh, $dir or die "cannot open $dir: $!";
    my @sorted_dir = 
        map $_->[0],
        sort {
            $a->[1] <=> $b->[1] || $a->[0] cmp $b->[0]
        }
        map [ $_, -f "$dir/$_" ],
        readdir($dh);

    foreach my $file (@sorted_dir)
    {
        if ($file eq '.' || $file eq '..' || $file =~ /^_/)
        {
            next;
        }
        elsif (-d "$dir/$file")
        {
            HandleDir("$dir/$file", "$prefix$;" . CleanFileName($file));
        }
        elsif ($file =~ /\.md$/)
        {
            my $name = MakeName($file);
            my $tag = MakeTag($file);

            print($outfh (' ' x $spaces) . "* [[$name|$tag]]\n");
        }
    }
    closedir $dh; 
}

foreach $rootDir (@ARGV)
{
    my $outfile = ">$rootDir/_Sidebar.md";
    open $outfh, $outfile;
    HandleDir($rootDir, CleanFileName($rootDir));

    print $outfh "\n---\n\n";
    open IFILE, "<_Sidebar.md";
    while (my $line = <IFILE>)
    {
        print $outfh $line;
    }
    close IFILE;

    close $outfh;
}

exit 1;

sub stuff {
foreach my $file (@ARGV)
{
    my @lines;

    my $minCount = 10;
    my $countAtLevel = 0;

    # First pass to look for the headings
    open IFILE, "<$file";
    my $line;
    while ($line = <IFILE>)
    {
        if ($line =~ /^#/)
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

            push @lines, $line;
        }
    }
    close IFILE;

    if ($countAtLevel <= 1)
    {
        $minCount += 1;
    }

    # Open in and out files
    open IFILE, "<$file";
    open OFILE, ">out.txt";

    # FFWD to the correct location
    while ($line = <IFILE>)
    {
        if ($line !~ /^\* \[\[/)
        {
            print OFILE $line;
        }
        else
        {
            last;
        }
    }

    # Write new TOC
    my $identifier = $file;
    $identifier =~ s/\.md$//;
    foreach my $line (@lines)
    {
        # How many spaces to prepend
        my $count = () = $line =~ /#/g;
        my $spaces = ($count - $minCount) * 2;

        if ($spaces < 0)
        {
            next;
        }

        # Get the name & tag
        my $name = Util::MakeName($line);
        my $tag = Util::MakeTag($line);

        print(OFILE (' ' x $spaces) . "* [[$name|$identifier#$tag]]\n");
    }

    # Dump the garbage
    while ($line = <IFILE>)
    {
        if ($line !~ /^ *\* \[\[/)
        {
            print OFILE $line;
            last;
        }
    }

    # Write the remainder
    while ($line = <IFILE>)
    {
        print OFILE $line;
    }

    close IFILE;
    close OFILE;

    move("out.txt", $file);
}
}
