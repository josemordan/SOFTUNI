using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Documentos
{
    public class ResponseTotalSolicitudes
    {

        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public Cantidades Cantidades { get; set; }       
    }

    public class Cantidades
    {
        public int TotalSolicitudPendiente { get; set; }
        public int TotalSolicitudAprobadas { get; set; }
        public int TotalSolicitudRechazadas { get; set; }
        public int TotalSolicitudLegalizado { get; set; }
    }
}