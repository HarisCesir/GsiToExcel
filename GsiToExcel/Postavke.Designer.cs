﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GsiToExcel {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    internal sealed partial class Postavke : global::System.Configuration.ApplicationSettingsBase {
        
        private static Postavke defaultInstance = ((Postavke)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Postavke())));
        
        public static Postavke Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int BrojDecimala {
            get {
                return ((int)(this["BrojDecimala"]));
            }
            set {
                this["BrojDecimala"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DataGridKolone {
            get {
                return ((string)(this["DataGridKolone"]));
            }
            set {
                this["DataGridKolone"] = value;
            }
        }
    }
}
