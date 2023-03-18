using SoftUNI.WebAPI.Logica.Estados;
using SoftUNI.WebAPI.Models.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SoftUNI.WebAPI.Controllers
{
    [EnableCors(origins: "*", "*", "*")]
    public class EstadosController : ApiController
    {
        private readonly EstadosLogica _estadosLogica;
        public EstadosController()
        {
            _estadosLogica = new EstadosLogica();
        }
        // GET: api/Estados
        public ResponseEstados Get()
        {
            ResponseEstados respuesta = new ResponseEstados();
            try
            {
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Estados Consultados Con Exito";
                respuesta.Estados = _estadosLogica.ConsultarEstados();
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje =ex.Message;
            }
            return respuesta;
        }

        // GET: api/Estados/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Estados
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Estados/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Estados/5
        //public void Delete(int id)
        //{
        //}
    }
}
