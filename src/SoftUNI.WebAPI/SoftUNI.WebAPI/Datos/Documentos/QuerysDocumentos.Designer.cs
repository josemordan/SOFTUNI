﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftUNI.WebAPI.Datos.Documentos {
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
    internal class QuerysDocumentos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuerysDocumentos() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SoftUNI.WebAPI.Datos.Documentos.QuerysDocumentos", typeof(QuerysDocumentos).Assembly);
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
        ///   Looks up a localized string similar to UPDATE dbo.RelacionEstudiantesDocumentos
        ///   SET Fecha = @Fecha
        ///      ,Estado_Documento = @Estado_Documento  ,Ruta = @Ruta
        /// WHERE ID_Documento = @ID_Documento and ID_Usuario = @ID_Usuario.
        /// </summary>
        internal static string ActualizarDocumento {
            get {
                return ResourceManager.GetString("ActualizarDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE dbo.RelacionEstuDocRequeridos
        ///   SET Fecha = @Fecha
        ///      ,Estado_Documento = @Estado_Documento
        /// WHERE ID_Doc_Req = @ID_Documento and ID_Usuario = @ID_Usuario.
        /// </summary>
        internal static string ActualizarDocumentoRequerido {
            get {
                return ResourceManager.GetString("ActualizarDocumentoRequerido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from dbo.RelacionEstudiantesDocumentos where ID_Documento = @ID_Documento and ID_Usuario = @ID_Usuario.
        /// </summary>
        internal static string BorrarDocumento {
            get {
                return ResourceManager.GetString("BorrarDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from dbo.RelacionEstuDocRequeridos where ID_Doc_Req = @ID_Documento and ID_Usuario = @ID_Usuario.
        /// </summary>
        internal static string BorrarDocumentoRequerido {
            get {
                return ResourceManager.GetString("BorrarDocumentoRequerido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	   b.ID as id_documento
        ///	  ,b.Nombre_Documento
        ///	  ,b.Institucion
        ///      ,ID_Usuario
        ///      ,Fecha
        ///      ,Estado_Documento
        ///	  ,Ruta
        ///	  ,Legalizacion
        ///	  ,c.Monto
        ///	  ,Fisico
        ///	  ,Legalizado
        ///  FROM dbo.DocumentosEstudiantes b
        ///  inner join dbo.Tarifas c on b.ID = c.ID_Documento
        ///  left join  dbo.RelacionEstudiantesDocumentos a on a.ID_Documento =b.ID and id_usuario=@id.
        /// </summary>
        internal static string ConsultarDocumentos {
            get {
                return ResourceManager.GetString("ConsultarDocumentos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	   b.ID as id_documento
        ///	  ,b.Nombre
        ///	  ,b.Institucion
        ///      ,ID_Usuario
        ///      ,Fecha
        ///      ,Estado_Documento
        ///	  ,Ruta
        ///  FROM dbo.DocumentosRequeridos b
        ///  left join  dbo.RelacionEstuDocRequeridos a on a.ID_Doc_Req =b.ID and id_usuario=@id.
        /// </summary>
        internal static string ConsutlarDocumentosRequeridos {
            get {
                return ResourceManager.GetString("ConsutlarDocumentosRequeridos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO dbo.RelacionEstudiantesDocumentos
        ///           (ID_Documento
        ///           ,ID_Usuario
        ///           ,Fecha
        ///           ,Estado_Documento
        ///		   ,Fisico
        ///		   ,Legalizado)
        ///     VALUES
        ///           (@ID_Documento
        ///           ,@ID_Usuario
        ///           ,@Fecha
        ///           ,@Estado_Documento
        ///		   ,@Fisico
        ///		   ,@Legalizar
        ///		   ).
        /// </summary>
        internal static string InsertarDocumento {
            get {
                return ResourceManager.GetString("InsertarDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO dbo.RelacionEstuDocRequeridos
        ///           (ID_Doc_Req
        ///           ,ID_Usuario
        ///           ,Fecha
        ///           ,Estado_Documento
        ///           ,Ruta)
        ///     VALUES
        ///           (@ID_Documento
        ///           ,@ID_Usuario
        ///           ,@Fecha
        ///           ,@Estado_Documento
        ///           ,@Ruta
        ///		   ).
        /// </summary>
        internal static string InsertarDocumentoRequerido {
            get {
                return ResourceManager.GetString("InsertarDocumentoRequerido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE dbo.RelacionEstudiantesDocumentos
        ///   SET Fecha = @Fecha
        ///      ,Estado_Documento = @Estado_Documento
        ///      ,Ruta = @Ruta
        /// WHERE ID_Documento = @ID_Documento and ID_Usuario = @ID_Usuario.
        /// </summary>
        internal static string LegalizarDocumento {
            get {
                return ResourceManager.GetString("LegalizarDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///      Monto
        ///  FROM dbo.Tarifas where id_docdumento=@doc.
        /// </summary>
        internal static string ObtenerTarifaDocumento {
            get {
                return ResourceManager.GetString("ObtenerTarifaDocumento", resourceCulture);
            }
        }
    }
}
