#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"SPbSU")]
[assembly: AssemblyProduct(@"RobotsLanguage")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"SPbSU.RobotsLanguage.DslPackage, PublicKey=00240000048000009400000006020000002400005253413100040000010001004182E84E38D969E6E4C328AE0CAADD06BF845E17DD139D1687B25CFA782B8F158333ADC50C44A82844A2F58DFBF03D5F8164C2D1FEB2D7625316A0FE72A27FDC977A53F25D766C0A99967EA00BE2ECE369442B447E2C81217042DBAAE6765F41ECE5096E46A4733B96946008550FF4D752A022211C3B1A0F9D35B1F4B2D03CDD")]