using SoftUNI.WebAPI.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Documentos
{
    public class SolicitudDocumento
    {
        public int ID { get; set; }
        public int ID_Documento { get; set; }
        public string Nombre_Documento { get; set; }
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public string DescripcionEstado { get; set; }
        public string Ruta { get; set; }
        public bool Fisico { get; set; }
        public bool Legalizar { get; set; }
        public decimal Tarifa { get; set; }
    }
}