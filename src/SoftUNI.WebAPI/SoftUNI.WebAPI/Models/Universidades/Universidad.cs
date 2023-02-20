using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Universidades
{
    public class Universidad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Sector { get; set; }
        public string Residencia { get; set; }
        public string Localizacion { get; set; }
        public int ID_Carrera { get; set; }
        public List<Carrera> Carreras { get; set; }
        public int ID_Usuario { get; set; }
    }
}