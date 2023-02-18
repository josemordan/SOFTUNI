﻿using EmailValidation;
using SoftUNI.WebAPI.Logica;
using SoftUNI.WebAPI.Logica.Usuarios;
using SoftUNI.WebAPI.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftUNI.WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        public readonly UsuariosLogica _usuariosLogica;
        public UsuariosController()
        {
            _usuariosLogica = new UsuariosLogica();
        }

        // GET: api/Usuarios
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Usuarios/5
        public Response Get(int id)
        {
            Response respuesta = new Response();
            try
            {
                var usuario = _usuariosLogica.ConsultaUsuario(id);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Consultado Correctamente";
                respuesta.Usuarios = usuario;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // POST: api/Usuarios
        public Response Post([FromBody] Usuario usuario)
        {
            Response respuesta = new Response();
            try
            {
                if (!EmailValidator.Validate(usuario.Correo))
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Correo Incorrecto";
                    respuesta.Usuarios = usuario;
                    return respuesta;
                }
                if(!new ValidaCedulas().CedulaValida(usuario.Identificacion))
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Identificacion Incorrecta";
                    respuesta.Usuarios = usuario;
                    return respuesta;
                }
                if (_usuariosLogica.ExisteUsuario(usuario.Identificacion))
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = $"Ya existe el Usuario {usuario.Identificacion}";
                    respuesta.Usuarios = usuario;
                    return respuesta;
                }
                var user = _usuariosLogica.ConsultaUsuarioDumy(usuario.Identificacion);
                if (user == null)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Identificacion No existe";
                    respuesta.Usuarios = usuario;
                    return respuesta;
                }

                usuario.Nombres = user.Nombres;
                usuario.Apellidos = user.Apellidos;
                usuario.Identificacion = user.Identificacion;
                usuario.Telefono = user.Telefono;
                usuario.Celular = user.Celular;
                usuario.Fecha_Nacimiento = user.Fecha_Nacimiento;
                usuario.Lugar_Nacimiento = user.Lugar_Nacimiento;
                usuario.Nacionalidad = user.Nacionalidad;
                usuario.Region = user.Region;
                usuario.Provincia = user.Provincia;
                usuario.Municipio = user.Municipio;
                usuario.Sector = user.Sector;
                usuario.Residencia = user.Residencia;
                _usuariosLogica.InsertarUsuario(usuario);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Usuario Resgistrado Correctamente";
                respuesta.Usuarios = usuario;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
                respuesta.Usuarios = usuario;
            }
            return respuesta;
        }

        // PUT: api/Usuarios/5
        //public Response Put(int id, [FromBody] Usuario usuario)
        public Response Put([FromBody] Usuario usuario)
        {
            Response respuesta = new Response();
            try
            {
                _usuariosLogica.ActualizarUsuario(usuario);
                var usuarioUpdated = _usuariosLogica.ConsultaUsuario(usuario.ID_Usuario);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Actualizado Correctamente";
                respuesta.Usuarios = usuarioUpdated;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
                respuesta.Usuarios = usuario;
            }
            return respuesta;
        }

        // DELETE: api/Usuarios/5
        public Response Delete(int id)
        {
            Response respuesta = new Response();
            try
            {
                _usuariosLogica.EliminarUsuario(id);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Usuario Eliminado";
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}