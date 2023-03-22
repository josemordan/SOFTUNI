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

        public Solicitud ConsultarSolicitud(int id_user)
        {
           return _universidadDataContext.ConsultarSolicitud(id_user);
        }

        public List<Solicitud> ConsultarTodasSolicitudes()
        {
            return _universidadDataContext.ConsultarTodasSolicitudes();
        }

        public void ActualizarSolicitud(int id_solicitud,int estado)
        {
            _universidadDataContext.ActualizarSolicitud(id_solicitud, estado);
        }

    }
}