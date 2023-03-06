using SoftUNI.WebAPI.Datos.Documentos;
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

        public List<Documento> ConsultarDocumentos(int id_usuario=0)
        {
            return _documentosDataContext.ConsultarDocumentos(id_usuario);
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
            _documentosDataContext.BorrarDocumento(id_doc,id_user);
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

        public void ConvertirBase64toPDF(string base64,string ruta)
        {
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(ruta, bytes);
        }
    }
}