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
    public class LoginController : ApiController
    {
        public readonly UsuariosLogica _usuariosLogica;
        public LoginController()
        {
            _usuariosLogica = new UsuariosLogica();
        }

        // GET: api/Login
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Login/5
        public ResponseUsuario Get(string usuario, string clave)
        {
            ResponseUsuario respuesta = new ResponseUsuario();
            try
            {
                var userLogin=_usuariosLogica.ValidaLogin(usuario, clave);
                if (userLogin == null)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Usuario O Clave incorrecta";
                    return respuesta;
                }
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Usuario Logueado";
                respuesta.Usuarios = userLogin;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        //// POST: api/Login
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Login/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Login/5
        //public void Delete(int id)
        //{
        //}
    }
}
