#<!/usr/bin/env perl

use strict;
use File::Copy qw(move);

my %IGNORED_TYPES = (
    Boolean => 1,
    Enumeration => 1,
    Numeric => 1,
    String => 1,
);

my %TYPE_MAP = qw(
    BodyLocation Enumeration-Type
    ChangeVesselOwnership.State Enumeration-Type
    ContractPrestige Enumeration-Type
    ExperimentSituations Enumeration-Type
    FinePrint.Utilities.OrbitType Enumeration-Type
    Gender Enumeration-Type
    HasAntennaParameter.AntennaType Enumeration-Type
    KerbalType Enumeration-Type
    Message.Condition Enumeration-Type
    PartCategories Enumeration-Type
    ProtoCrewMember.Gender Enumeration-Type
    ProtoCrewMember.KerbalType Enumeration-Type
    RosterStatus Enumeration-Type
    SCANdata.SCANtype Enumeration-Type
    ScienceRecoveryMethod Enumeration-Type
    Timer.TimerType Enumeration-Type
    Vessel.Situations Enumeration-Type
    VesselType Enumeration-Type
    enum Enumeration-Type
    bool Boolean-Type
    double Numeric-Type
    float Numeric-Type
    int Numeric-Type
    long Numeric-Type
    string String-Type
    uint Numeric-Type
    ulong Numeric-Type
    numeric Numeric-Type
);

my %unhandledTypes;

sub MakeName($)
{
    my $name = shift;

    # Get the tag
    my $tag = $name;
    $tag =~ s/\.md$//g;
    $tag =~ s/-/ /g;
    $tag =~ s/ (Parameter|Requirement|Behaviour|Type)$//g;
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

sub HandleDir($)
{
    my $dir = shift;

    my $dh;
    opendir $dh, $dir or die "cannot open $dir: $!";

    foreach my $file (readdir($dh))
    {
        if ($file =~ /^[\._]/ ||
            $file eq 'Expressions.md')
        {
            next;
        }
        elsif (-d "$dir/$file")
        {
            HandleDir("$dir/$file");
        }
        elsif ($file =~ /\.md$/)
        {
            HandleFile("$dir/$file");
        }
    }
    closedir $dh; 
}

sub HandleFile($)
{
    my $file = shift;

    open IFILE, "<$file" or die "Couldn't open input file $file!: $!";
    open OFILE, ">out.txt" or die "Couldn't open input file $file!: $!";

    while (my $line = <IFILE>)
    {
        $line =~ s/[\n\r]//g;

        if ($line =~ /Type: +([^< ].*)/)
        {
            my $type = $1;
            if (exists $TYPE_MAP{$type})
            {
                $line =~ s/$type/<a href="$TYPE_MAP{$type}">$type<\/a>/;
            }
            else
            {
                $unhandledTypes{$type} = 1;
            }
        }
        elsif ($line =~ /\| +`([^ <]+)/)
        {
            my $type = $1;
            if (exists $TYPE_MAP{$type})
            {
                $line =~ s/`$type/[`$type`]($TYPE_MAP{$type})`/;
            }
            else
            {
                $unhandledTypes{$type} = 1;
            }
        }

        if ($line =~ /^\| [^\|]+[^\]]\(([^) ,`<]+)/)
        {
            my $type = $1;
            if (exists $TYPE_MAP{$type})
            {
                $line =~ s/([^\]])\($type/$1(`[`$type`]($TYPE_MAP{$type})`/;
            }
            else
            {
                $unhandledTypes{$type} = 1;
            }
        }

        while ($line =~ /^\| [^\|]+, +([^) ,\[`<]+)/)
        {
            my $type = $1;
            if (exists $TYPE_MAP{$type})
            {
                $line =~ s/, $type/, `[`$type`]($TYPE_MAP{$type})`/;
            }
            else
            {
                $unhandledTypes{$type} = 1;
                last;
            }
        }

        while ($line =~ /^\| [^\|]+<([\w]+)>/)
        {
            my $type = $1;
            if (exists $TYPE_MAP{$type})
            {
                $line =~ s/<$type>/<`[`$type`]($TYPE_MAP{$type})`>/;
            }
            else
            {
                $unhandledTypes{$type} = 1;
                last;
            }
        }

        print OFILE $line, "\n";
    }

    close IFILE;
    close OFILE;

    move("out.txt", $file);
}

sub LoadTypes($)
{
    my $dir = shift;

    my $dh;
    opendir $dh, $dir or die "cannot open $dir: $!";

    foreach my $file (readdir($dh))
    {
        if ($file =~ /^[\._]/ ||
            $file eq 'Expressions.md' ||
            $file eq 'Global-Functions.md' ||
            $file =~ /-Behaviour/)
        {
            next;
        }
        elsif (-d "$dir/$file")
        {
            LoadTypes("$dir/$file");
        }
        else
        {
            my $type = MakeName($file);

            if (exists $IGNORED_TYPES{$type})
            {
                next;
            }
            my $tag = MakeTag($file);

            $TYPE_MAP{$type} = $tag;
        }
    }

    closedir $dh;
}


LoadTypes("5-Expressions");

foreach my $rootDir (@ARGV)
{
    HandleDir($rootDir);
}

foreach my $type (sort keys %unhandledTypes)
{
    if ($type ne "Vector3d" && $type ne "T")
    {
        print "Unhandled type: $type\n";
    }
}
