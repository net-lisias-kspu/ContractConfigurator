package Util;

use strict;

sub MakeName($)
{
    my $line = shift;

    # Get the name
    my $name = $line;
    $name =~ s/^#+ ?//;
    $name =~ s/[\r\n]//g;

    return $name;
}

sub MakeTag($)
{
    my $line = shift;

    my $name = MakeName($line);

    # Get the tag
    my $tag = lc $name;
    $tag =~ s/ /-/g;
    $tag =~ s/[\/\(\)]//g;

    return $tag;
}

1;
