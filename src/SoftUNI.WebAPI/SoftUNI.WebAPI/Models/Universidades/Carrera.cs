using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Universidades
{
    public class Carrera
    {
        public int ID { get; set; }
        public int ID_Universidad { get; set; }
        public string Nombre { get; set; }
    }
}