The ScienceSubject class represents a subject for which science can be performed.  It is made up of a celestial body, an experiment, a situation (landed/splashed/flying low/etc.) and possibly a biome (if applicable for the given combination).

**Methods**

| Method Signature | Description |
| :--- | :--- |
| `ScienceExperiment Experiment()` | The experiment the given subject is applicable to. |
| `ExperimentSituations Situation()` | The situation the given subject is applicable to. |
| `CelestialBody CelestialBody()` | The celestial body the given subject is applicable to. |
| `Biome Biome()` | The biome the given subject is applicable to (null if not applicable). |
| `string SitutationString()` | The situation portion of the subject tile ("while high over Jool"). |
| `float CollectedScience()` | The amount of science collected for the given subject. |
| `float RemainingScience()` | The amount of science remaining for the given subject. |
| `float TotalScience()` | The total amount of science available for the given subject. |
| `float NextScienceReportValue()` | The value of the next science report for the given subject. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| `List<ScienceSubject> AllScienceSubjects()` | The list of all currently available science subjects (except "difficult" ones). |
| `List<ScienceSubject> AllScienceSubjectsByBody(List<CelestialBody>)` | Same as AllScienceSubjects, but filtered by CelestialBody. |
| `List<ScienceSubject> AllScienceSubjectsByExperiment(List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by ScienceExperiment. |
| `List<ScienceSubject> AllScienceSubjectsByBiome(List<Biome>)` | Same as AllScienceSubjects, but filtered by Biome. |
| `List<ScienceSubject> AllScienceSubjectsByBodyExperiment(List<CelestialBody>, List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by CelestialBody and ScienceExperiment. |
| `List<ScienceSubject> AllScienceSubjectsByBiomeExperiment(List<Biome>, List<ScienceExperiment>)` | Same as AllScienceSubjects, but filtered by Biome and ScienceExperiment. |
| `List<ScienceSubject> DifficultScienceSubjects()` | The list of all "difficult" subjects (such as "splashed down in the mountains"). |