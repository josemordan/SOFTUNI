using SoftUNI.WebAPI.Datos.Documentos;
using SoftUNI.WebAPI.Logica.Estados;
using SoftUNI.WebAPI.Models.Documentos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Logica.Documentos
{
    public class DocumentosLogica
    {
        private readonly DocumentosDataContext _documentosDataContext;
        public DocumentosLogica()
        {
            _documentosDataContext = new DocumentosDataContext();
        }

        public List<Documento> ConsultarDocumentos(int id_usuario = 0)
        {
            var documentos = _documentosDataContext.ConsultarDocumentos(id_usuario);
            foreach (var item in documentos)
            {
                item.DescripcionEstado = new EstadosLogica().ConsultarEstados().Where(x => x.ID == item.Estado).ToList().Select(x => x.Estado).FirstOrDefault();
            }
            return documentos;
        }

        public void InsertDocumento(Documento documento)
        {
            _documentosDataContext.InsertarDocumento(documento);
        }

        public void ActualizarDocumento(Documento documento)
        {
            _documentosDataContext.ActualizarDocumento(documento);
        }

        public void BorrarDocumento(int id_doc, int id_user)
        {
            _documentosDataContext.BorrarDocumento(id_doc, id_user);
        }

        public void LegalizarDocumento(Documento documento)
        {
            _documentosDataContext.LegalizarDocumento(documento);
        }

        public decimal ConsultarTarifas(int id_doc)
        {
            return _documentosDataContext.ConsultarTarifa(id_doc);
        }

        public string ConvertirPDFtoBase64(string ruta)
        {
            Byte[] bytes = File.ReadAllBytes(ruta);
            String file = Convert.ToBase64String(bytes);
            return file;
        }

        public void ConvertirBase64toPDF(string base64, string ruta)
        {
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(ruta, bytes);
        }

        //Documentos Requeridos
        public List<Documento> ConsultarDocumentosRequeridos(int id_usuario = 0)
        {
            var documentos = _documentosDataContext.ConsultarDocumentosRequeridos(id_usuario);
            foreach (var item in documentos)
            {
                item.DescripcionEstado = new EstadosLogica().ConsultarEstados().Where(x => x.ID == item.Estado).ToList().Select(x => x.Estado).FirstOrDefault();
            }
            return documentos ;
        }

        public void InsertDocumentoRequerido(Documento documento)
        {
            _documentosDataContext.InsertarDocumentoRequeridos(documento);
        }

        public void ActualizarDocumentoRequerido(Documento documento)
        {
            _documentosDataContext.ActualizarDocumentoRequerido(documento);
        }

        public void BorrarDocumentoRequerido(int id_doc, int id_user)
        {
            _documentosDataContext.BorrarDocumentoRequerido(id_doc, id_user);
        }
    }
}