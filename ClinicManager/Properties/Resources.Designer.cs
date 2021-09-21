﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicManager.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClinicManager.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE DATABASE ClinicData
        ///GO
        ///
        ///USE ClinicData
        ///
        ///CREATE TABLE Localizations (
        ///	Id INT IDENTITY(1,1) NOT NULL,
        ///	Country NVARCHAR(255) NOT NULL,
        ///	City NVARCHAR(255) NOT NULL,
        ///	Street NVARCHAR(255) NOT NULL,
        ///	House TINYINT NOT NULL,
        ///	Flat TINYINT NOT NULL,
        ///	PostalCode NVARCHAR(255) NOT NULL,
        ///	CONSTRAINT PK__Localizations_Id PRIMARY KEY CLUSTERED (Id),
        ///	CONSTRAINT CK__Localizations_House CHECK (House &gt; 0),
        ///	CONSTRAINT CK__Localizations_Flat CHECK (Flat &gt; 0),
        ///);
        ///GO
        ///
        ///CREATE TABLE Drugs (
        ///	Id INT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string dbConfig {
            get {
                return ResourceManager.GetString("dbConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DBCC CHECKIDENT (&apos;Clinics&apos;, RESEED, 1)  -- wyzerowanie autoinkrementowanego ID
        ///DBCC CHECKIDENT (&apos;Costs&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Data&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Drugs&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Employees&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Localizations&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Operations&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Opinions&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Patients&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Producents&apos;, RESEED, 1)
        ///DBCC CHECKIDENT (&apos;Registrations&apos;, RESEED, 1)
        ///DBCC CHECKIDENT ( [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string dbData {
            get {
                return ResourceManager.GetString("dbData", resourceCulture);
            }
        }
    }
}
