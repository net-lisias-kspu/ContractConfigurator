﻿using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("KerKonConConExt")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("KerKonConConExt")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("1a7e7d93-0fe2-4099-afa7-cefa133a985b")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(KerKonConConExt.Version.Number)]
[assembly: AssemblyFileVersion(KerKonConConExt.Version.Number)]
[assembly: AssemblyInformationalVersion(KerKonConConExt.Version.Number)]
[assembly: KSPAssembly("KerKonConConExt", KerKonConConExt.Version.major, KerKonConConExt.Version.minor)]

//[assembly: KSPAssemblyDependency("KSPe", 2, 0)]
[assembly: KSPAssemblyDependency("ContractConfigurator", KerKonConConExt.Version.major, KerKonConConExt.Version.minor)]
[assembly: KSPAssemblyDependency("KerbalKonstructs", 0, 9)]
