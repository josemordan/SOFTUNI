using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Universidades
{
    public class ResponseSolicitud
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public List<Solicitud> Solcitudes { get; set; }
    }
}