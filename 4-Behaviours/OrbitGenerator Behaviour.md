Behaviour for generating orbits.  Note that this only generates the orbits, and is not responsible for creating the contract parameter to ask a player to hit that orbit.  That needs to be done with the [[ReachSpecificOrbit parameter|ReachSpecificOrbit-Parameter]].

    BEHAVIOUR
    {
        name = OrbitGenerator
        type = OrbitGenerator

        // Use this to generate an orbit with specific parameters
        FIXED_ORBIT
        {
            // Body for the orbit - defaulted from the contract if not supplied
            targetBody = Kerbin

            // Actual orbit details. Note that REF represents the reference
            // body - but will be overriden by the targetBody.
            ORBIT
            {
                SMA = 1449999.99996286
                ECC = 1.07570816555399E-05
                INC = 0
                LPE = 270.690311604893
                LAN = 1.93635924563296
                MNA = 1.55872660382504
                EPH = 31.3999999999994
                REF = 1
            }
        }

        // Use this to generate an orbit with some randomization
        RANDOM_ORBIT
        {
            // Body for the orbit - defaulted from the contract if not supplied
            targetBody = Kerbin

            // Type of orbit to generate.  Valid values are from
            // FinePrint.Utilities.OrbitType:
            //    EQUATORIAL
            //    KOLNIYA
            //    POLAR
            //    RANDOM
            //    STATIONARY
            //    SYNCHRONOUS
            //    TUNDRA
            type = KOLNIYA

            // A factor between 0.0 and 1.0 which indicates how high the orbit
            // can be.  A value of 1.0 indicates the orbit may go as far out as
            // the body's sphere of influence, whereas a value of 0.0
            // represents the minimum altitude possible.
            // Default = 0.8
            altitudeFactor = 0.8

            // A factor between 0.0 which indicates the maximum possible
            // inclination for the generated orbit.  A value of 0.0 means the
            // orbit must always be equatorial.  A value of 1.0 means the orbit
            // can be anywhere between 0 and 90 degrees inclined.  This is
            // ignored for EQUATORIAL, POLAR and STATIONARY.
            // Default = 0.8
            inclinationFactor = 0.8

            // The eccentricity of the orbit.  Ignored for all but SYNCHRONOUS.
            // Default = 0.0
            eccentricity = 0.0

            // The amount the player is allowed to deviate from this orbit in
            // the ReachSpecificOrbit parameter.  Lower numbers are more
            // difficult.
            // Default = 10.0
            deviationWindow = 10.0
        }
    }
