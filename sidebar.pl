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
        print $outfh "**[[$prefixes[-1]]]**\n"
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
        map [ $_, -d "$dir/$_" ],
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
