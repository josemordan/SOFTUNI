﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Models.Usuarios
{
    public class ResponseUsuariosTipo
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}