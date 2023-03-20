using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Usuarios
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Lugar_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Region { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Sector { get; set; }
        public string Residencia { get; set; }
        public string Matricula { get; set; }
        public int Tipo { get; set; }
        public bool Inscrito { get; set; }
    }
}