using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Universidades
{
    public class Solicitud
    {
        public int ID { get; set; }
        public int ID_Universidad { get; set; }
        public string NombreUniversidad { get; set; }
        public int ID_Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public int ID_Carrera { get; set; }
        public string NombreCarrera { get; set; }
        public int Estado { get; set; }
        public string DescripcionEstado { get; set; }
        public DateTime Fecha { get; set; }
        public Universidad Universidad { get; set; }
    }
}