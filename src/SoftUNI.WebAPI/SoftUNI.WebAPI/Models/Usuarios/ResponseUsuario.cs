using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Usuarios
{
    public class ResponseUsuario
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuarios { get; set; }
    }
}