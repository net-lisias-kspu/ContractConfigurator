## Table of Contents

* [[Table of Contents|Data-Types#table-of-contents]]
* [[Basic Data Types|Data-Types#basic-data-types]]
* [[Complex Classes|Data-Types#complex-classes]]

## Basic Data Types

The following list the basic data types that are supported in the Contract Configurator expression language.

| Type | Description |
| :--- | :--- |
| `string` | A general string.  This data type is parsed differentely than other data types - the expression syntax is limited to a "search and replace" of special identifiers and function calls. |
| `bool` | A boolean value (true/false). |
| `int` | An integer value (32 bit). |
| `short` | A short integer value (16 bit). |
| `float` | A floating point number (eg. a real number). |
| `double` | Double precision floating point. |
| `enum` | An enumeration (can be replaced with the name of *any* enumeration within the KSP or Contract Configurator code base). |
| `List<T>` | A list of items of a given type.  `T` can be any supported type. |

<sub>[ [[Top|Data-Types]] ] [ [[Basic Data Types|Data-Types#basic-data-types]] ]</sub>

## Complex Classes

| Type | Description |
| :--- | :--- |
| `AvailablePart` | An available part (ie. the definition of a part). |
| `CelestialBody` | Represents a celestial body in the game (sun, planet or moon). |
| `Duration` | A duration in time.  Can be specified with units of y, d, h, m, s.  Example: `2d 4h` is 2 days and 4 hours. |
| `Kerbal` | A Kerbal.  This actually represents a `ProtoCrewMember` in game. |
| `Resource` | A KSP resource.  This actually represents a `PartResourceDefinition` in game. |
| `Vessel` | A ship, station, base, EVA Kerbal or space object. |
| `Waypoint` | An in-game waypoint used by contracts. |

<sub>[ [[Top|Data-Types]] ] [ [[Complex Classes|Data-Types#complex-classes]] ]</sub>

