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
    public class DocumentosRequeridosController : ApiController
    {
        private readonly DocumentosLogica _documentosLogica;
        public DocumentosRequeridosController()
        {
            _documentosLogica = new DocumentosLogica();
        }
        // GET: api/DocumentosRequridos
        public ResponseDocumento Get()
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documentos = _documentosLogica.ConsultarDocumentosRequeridos();
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documentos Consultados Con Exito";
                respuesta.Documentos = documentos;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // GET: api/DocumentosRequridos/5
        public ResponseDocumento Get(int id_usuario)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documentos = _documentosLogica.ConsultarDocumentosRequeridos(id_usuario);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documentos Consultados Con Exito";
                respuesta.Documentos = documentos;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // POST: api/DocumentosRequridos
        public ResponseDocumento Post([FromBody] Documento documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                documento.Estado = 2;
                documento.Ruta = documento.Ruta;
                _documentosLogica.InsertDocumentoRequerido(documento);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Insertado Correctamente";
                respuesta.Documentos = _documentosLogica.ConsultarDocumentosRequeridos();
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // PUT: api/DocumentosRequridos/5
        public ResponseDocumento Put([FromBody] Documento documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                _documentosLogica.ActualizarDocumentoRequerido(documento);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Actualizado Correctamente";
                respuesta.Documentos = _documentosLogica.ConsultarDocumentosRequeridos();
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // DELETE: api/DocumentosRequridos/5
        public ResponseDocumento Delete(int id_doc, int id_user)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                _documentosLogica.BorrarDocumentoRequerido(id_doc, id_user);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Borrado Correctamente";
                respuesta.Documentos = _documentosLogica.ConsultarDocumentosRequeridos();
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
