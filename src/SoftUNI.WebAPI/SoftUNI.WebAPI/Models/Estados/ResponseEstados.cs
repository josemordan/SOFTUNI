using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Estados
{
    public class ResponseEstados
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public List<EstadosDocumentos> Estados { get; set; }
    }
}