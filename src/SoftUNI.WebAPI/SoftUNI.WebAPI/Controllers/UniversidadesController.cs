using SoftUNI.WebAPI.Logica.Universidades;
using SoftUNI.WebAPI.Models.Universidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftUNI.WebAPI.Controllers
{
    public class UniversidadesController : ApiController
    {
        private readonly UniversidadesLogica _universidadesLogica;

        public UniversidadesController()
        {
            _universidadesLogica = new UniversidadesLogica();
        }

        // GET: api/Universidades
        public ResponseUniversidad Get()
        {
            ResponseUniversidad respuesta = new ResponseUniversidad();
            try
            {
                var universidades = _universidadesLogica.ConsultarUniversidades();
                var carreras = _universidadesLogica.ConsultarCarrera();
                foreach (var item in universidades)
                {
                    item.Carreras = carreras.Where(x => x.ID_Universidad == item.ID).ToList();
                }
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Universidades Consultadas Con Exito";
                respuesta.Universidades = universidades;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // GET: api/Universidades/5
        public ResponseUniversidad Get(int id)
        {
            ResponseUniversidad respuesta = new ResponseUniversidad();
            try
            {
                var universidades = _universidadesLogica.ConsultarUniversidades().Where(x=>x.ID==id).ToList();
                universidades[0].Carreras = _universidadesLogica.ConsultarCarrera().Where(x=>x.ID_Universidad == universidades[0].ID).ToList();              
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Universidades Consultadas Con Exito";
                respuesta.Universidades = universidades;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public ResponseUniversidad GetSolicitud(int id_user)
        {
            ResponseUniversidad respuesta = new ResponseUniversidad();
            try
            {
                var solicitud = _universidadesLogica.ConsultarSolicitud(id_user);
                if (solicitud == null)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Usaurio No Posee Solicitud Activa";
                    return respuesta;
                }
                var universidades = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == solicitud.ID_Universidad).ToList();
                universidades[0].Carreras = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == solicitud.ID_Carrera).ToList();
                universidades[0].ID_Carrera = solicitud.ID_Carrera;
                universidades[0].ID_Usuario = solicitud.ID_Usuario;
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Solicitud Consultada Con Exito";
                respuesta.Universidades = universidades;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        // POST: api/Universidades
        public ResponseUniversidad Post([FromBody] Universidad universidad)
        {
            ResponseUniversidad respuesta = new ResponseUniversidad();
            try
            {
                _universidadesLogica.InsertarSolicitud(universidad);
                var universidades = _universidadesLogica.ConsultarUniversidades();
                var carreras = _universidadesLogica.ConsultarCarrera();
                foreach (var item in universidades)
                {
                    item.Carreras = carreras.Where(x => x.ID_Universidad == item.ID).ToList();
                }
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Solicitud Guardada Con Existo";
                respuesta.Universidades = universidades;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        //// PUT: api/Universidades/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/Universidades/5
        //public void Delete(int id)
        //{
        //}
        
    }
}
