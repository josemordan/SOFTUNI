﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftUNI.WebAPI.Datos.Universidades {
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
    internal class QuerysUniversidades {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuerysUniversidades() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SoftUNI.WebAPI.Datos.Universidades.QuerysUniversidades", typeof(QuerysUniversidades).Assembly);
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
        ///   Looks up a localized string similar to SELECT ID
        ///	  ,ID_Universidad
        ///      ,NOMBRE
        ///  FROM dbo.Carreras.
        /// </summary>
        internal static string ConsultarCarreras {
            get {
                return ResourceManager.GetString("ConsultarCarreras", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT top 1 ID
        ///      ,ID_Estudiante as us
        ///      ,ID_Universidad as uni
        ///      ,ID_Carrera as carr
        ///  FROM dbo.SolicitudUniversidad where ID_Estudiante = @id.
        /// </summary>
        internal static string ConsultarSolicitudes {
            get {
                return ResourceManager.GetString("ConsultarSolicitudes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT  ID
        ///      ,NOMBRE
        ///      ,Region
        ///      ,Provincia
        ///      ,Municipio
        ///      ,Sector
        ///      ,Residencia
        ///      ,Localicacion,Imagen
        ///  FROM dbo.UNIVERSIDADES.
        /// </summary>
        internal static string ConsultarUniversidades {
            get {
                return ResourceManager.GetString("ConsultarUniversidades", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO dbo.SolicitudUniversidad
        ///           (ID_Estudiante
        ///           ,ID_Universidad
        ///           ,ID_Carrera)
        ///     VALUES
        ///           (@ID_Estudiante
        ///           ,@ID_Universidad
        ///           ,@ID_Carrera).
        /// </summary>
        internal static string InsertarSolicitud {
            get {
                return ResourceManager.GetString("InsertarSolicitud", resourceCulture);
            }
        }
    }
}
