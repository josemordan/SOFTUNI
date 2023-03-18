using SoftUNI.WebAPI.Datos.Estados;
using SoftUNI.WebAPI.Models.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Logica.Estados
{
    public class EstadosLogica
    {
        private readonly EstadosDataContext _estadosDataContext;
        public EstadosLogica()
        {
            _estadosDataContext = new EstadosDataContext();
        }

        public List<EstadosDocumentos> ConsultarEstados()
        {
            return _estadosDataContext.ConsultarDocumentos();
        }
    }
}