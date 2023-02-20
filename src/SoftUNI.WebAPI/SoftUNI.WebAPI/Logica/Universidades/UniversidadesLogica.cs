using SoftUNI.WebAPI.Datos.Universidades;
using SoftUNI.WebAPI.Models.Universidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Logica.Universidades
{
    public class UniversidadesLogica
    {
        private readonly UniversidadDataContext _universidadDataContext;
        public UniversidadesLogica()
        {
            _universidadDataContext = new UniversidadDataContext();
        }

        public List<Universidad >ConsultarUniversidades()
        {
            return _universidadDataContext.ConsultarUniversidad();
        }

        public List<Carrera> ConsultarCarrera()
        {
            return _universidadDataContext.ConsultarCarrera();
        }

        public void InsertarSolicitud(Universidad solicitud)
        {
            _universidadDataContext.InsertarSolicitud(solicitud);
        }
    }
}