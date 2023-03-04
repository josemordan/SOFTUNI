using SoftUNI.WebAPI.Logica.Documentos;
using SoftUNI.WebAPI.Models.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftUNI.WebAPI.Controllers
{
    public class DocumentosEstudiantesController : ApiController
    {
        private readonly DocumentosLogica _documentosLogica;
        public DocumentosEstudiantesController()
        {
            _documentosLogica = new DocumentosLogica();
        }
        // GET: api/DocumentosEstudiantes
        public ResponseDocumento Get()
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documentos = _documentosLogica.ConsultarDocumentos();
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

        // GET: api/DocumentosEstudiantes/5
        public ResponseDocumento Get(int id_usuario)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documentos = _documentosLogica.ConsultarDocumentos(id_usuario);
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

        // POST: api/DocumentosEstudiantes
        public ResponseDocumento Post([FromBody] Documento documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                documento.Estado = "Cargado";
                _documentosLogica.InsertDocumento(documento);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Insertado Correctamente";
                respuesta.Documentos = _documentosLogica.ConsultarDocumentos();
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // PUT: api/DocumentosEstudiantes/5
        public ResponseDocumento Put([FromBody] Documento documento)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                _documentosLogica.ActualizarDocumento(documento);
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Documento Actualizado Correctamente";
                respuesta.Documentos = _documentosLogica.ConsultarDocumentos();
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }


        public ResponseDocumento GetTarifa(int documentoTarifa)
        {
            ResponseDocumento respuesta = new ResponseDocumento();
            try
            {
                var documentos = _documentosLogica.ConsultarDocumentos(documentoTarifa);
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


        // DELETE: api/DocumentosEstudiantes/5
        public void Delete(int id)
        {
        }
    }
}
