using SoftUNI.WebAPI.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Documentos
{
    public class Documento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Institucion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Ruta { get; set; }
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}