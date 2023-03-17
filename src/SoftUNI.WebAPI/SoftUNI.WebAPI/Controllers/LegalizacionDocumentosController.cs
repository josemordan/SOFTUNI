using SoftUNI.WebAPI.Logica.Documentos;
using SoftUNI.WebAPI.Models.Documentos;
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
    public class LegalizacionDocumentosController : ApiController
    {
        private readonly DocumentosLogica _documentosLogica;
        public LegalizacionDocumentosController()
        {
            _documentosLogica = new DocumentosLogica();
        }
        // GET: api/LegalizacionDocumentos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LegalizacionDocumentos/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/LegalizacionDocumentos
        public ResponseDocumento Post(int id_usuario, int id_documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documento = _documentosLogica.ConsultarDocumentos(id_usuario).Where(x => x.ID == id_documento).ToList();    
                /*
                    aqui logica para enviar a legalizar con el otro grupo
                */
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Enviado A Legalizacion";
                respuesta.Documentos = documento;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // PUT: api/LegalizacionDocumentos/5
        public ResponseDocumento Put([FromBody] Documento documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                documento.Estado = "Legalizado";
                documento.Fecha = DateTime.Now;
                _documentosLogica.LegalizarDocumento(documento);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Guardado Con Exito";
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        //// DELETE: api/LegalizacionDocumentos/5
        //public void Delete(int id)
        //{
        //}
    }
}
