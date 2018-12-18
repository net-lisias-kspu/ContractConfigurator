The LaunchSite class represents a launch site on a planet or moon.

**Methods**

| Method Signature | Description |
| :--- | :--- |
| [`string`](String-Type) `Name()` | The name of the Launch Site. |
| [`PQSCity`](PQSCity-Type)` PQSCity()` | The associated PQSCity (if any). |
| [`Location`](Location-Type)` Location()` | The location of the Launch Site on the celestial body. |

**Global Functions**

| Function Signature| Description |
| :--- | :--- |
| [`List`](List-Type)`<`[`LaunchSite`](LaunchSite-Type)`> AllLaunchSites()` | Returns a list of all launch sites. |
| [`List`](List-Type)`<`[`LaunchSite`](LaunchSite-Type)`> AllEnabledLaunchSites()` | Returns a list of all launch sites that are enabled (presumably DLC-locked launch sites are not returned). |
| [`List`](List-Type)`<`[`LaunchSite`](LaunchSite-Type)`> AllStockLaunchSites()` | Returns a list of all stock launch sites. |
| [`List`](List-Type)`<`[`LaunchSite`](LaunchSite-Type)`> AllNonStockLaunchSites()` | Returns a list of all non-stock launch sites (presumably modded launch sites). |
