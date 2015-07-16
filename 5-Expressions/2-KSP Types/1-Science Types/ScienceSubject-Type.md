The ScienceSubject class represents a subject for which science can be performed.  It is made up of a celestial body, an experiment, a situation (landed/splashed/flying low/etc.) and possibly a biome (if applicable for the given combination).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`ScienceExperiment`](ScienceExperiment-Type) `Experiment()` | The experiment the given subject is applicable to. |
| [`ExperimentSituations`](Enumeration-Type) `Situation()` | The situation the given subject is applicable to. |
| [`CelestialBody`](CelestialBody-Type) `CelestialBody()` | The celestial body the given subject is applicable to. |
| [`Biome`](Biome-Type) `Biome()` | The biome the given subject is applicable to (null if not applicable). |
| [`string`](String-Type) `SitutationString()` | The situation portion of the subject tile ("while high over Jool"). |
| [`float`](Numeric-Type) `CollectedScience()` | The amount of science collected for the given subject. |
| [`float`](Numeric-Type) `RemainingScience()` | The amount of science remaining for the given subject. |
| [`float`](Numeric-Type) `TotalScience()` | The total amount of science available for the given subject. |
| [`float`](Numeric-Type) `NextScienceReportValue()` | The value of the next science report for the given subject. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjects()` | The list of all currently available science subjects (except "difficult" ones). |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjectsByBody(`[`List`](List-Type)`<CelestialBody>)` | Same as AllScienceSubjects, but filtered by CelestialBody. |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjectsByExperiment(`[`List`](List-Type)`<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by ScienceExperiment. |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjectsByBiome(`[`List`](List-Type)`<Biome>)` | Same as AllScienceSubjects, but filtered by Biome. |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjectsByBodyExperiment(`[`List`](List-Type)`<CelestialBody>, `[`List`](List-Type)`<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by CelestialBody and ScienceExperiment. |
| [`List`](List-Type)`<ScienceSubject> AllScienceSubjectsByBiomeExperiment(`[`List`](List-Type)`<Biome>, `[`List`](List-Type)`<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by Biome and ScienceExperiment. |
| [`List`](List-Type)`<ScienceSubject> DifficultScienceSubjects()` | The list of all "difficult" subjects (such as "splashed down in the mountains"). |