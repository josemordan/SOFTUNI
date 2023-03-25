using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Documentos
{
    public class ResponseSolicitudDocumentos
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public List<SolicitudDocumento> Solicitud { get; set; }
    }
}