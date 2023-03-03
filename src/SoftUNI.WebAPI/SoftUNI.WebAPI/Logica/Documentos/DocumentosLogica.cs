using SoftUNI.WebAPI.Datos.Documentos;
using SoftUNI.WebAPI.Models.Documentos;
using System;
using System.Collections.Generic;
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
    }
}