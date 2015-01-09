#!/usr/bin/env perl

use strict;
use File::Copy qw(move);

foreach my $file (@ARGV)
{
    my @lines;

    # First pass to look for the headings
    open IFILE, "<$file";
    my $line;
    while ($line = <IFILE>)
    {
        if ($line =~ /^###/)
	{
	    push @lines, $line;
	}
    }
    close IFILE;

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
	my $spaces = ($count - 3) * 2;

	# Get the name
	my $name = $line;
	$name =~ s/^#+ ?//;
	$name =~ s/[\r\n]//g;

	# Get the tag
	my $tag = lc $name;
	$tag =~ s/ /-/g;

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
