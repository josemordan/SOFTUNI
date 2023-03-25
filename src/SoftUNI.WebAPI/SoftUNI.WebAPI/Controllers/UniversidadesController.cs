using SoftUNI.WebAPI.Logica.Estados;
using SoftUNI.WebAPI.Logica.Universidades;
using SoftUNI.WebAPI.Logica.Usuarios;
using SoftUNI.WebAPI.Models.Universidades;
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

        public ResponseSolicitud GetSolicitud(int id_user)
        {
            ResponseSolicitud respuesta = new ResponseSolicitud();
            try
            {
                //var solicitud = _universidadesLogica.ConsultarSolicitud(id_user);
                var solicitud = _universidadesLogica.ConsultarTodasSolicitudes().Where(x=>x.ID_Usuario ==id_user).ToList();
                if (solicitud == null)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "Usuario No Posee Solicitud Activa";
                    return respuesta;
                }
                solicitud[0].Universidad = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == solicitud[0].ID_Universidad).FirstOrDefault();
                solicitud[0].NombreCarrera = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == solicitud[0].ID_Carrera).Select(x => x.Nombre).FirstOrDefault();
                solicitud[0].NombreUniversidad = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == solicitud[0].ID_Universidad).Select(x => x.Nombre).FirstOrDefault();
                solicitud[0].NombreUsuario = new UsuariosLogica().ConsultaUsuario(solicitud[0].ID_Usuario).Nombres;
                solicitud[0].DescripcionEstado = new EstadosLogica().ConsultarEstados().Where(x => x.ID == solicitud[0].Estado).FirstOrDefault().Estado;
                solicitud[0].Universidad.Carreras = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == solicitud[0].ID_Carrera).ToList();
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Solicitud Consultada Con Exito";
                respuesta.Solcitudes = solicitud;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public ResponseSolicitud GetTodasSolicitudes(int id_uni)
        {
            ResponseSolicitud respuesta = new ResponseSolicitud();
            try
            {
                var solicitudes = _universidadesLogica.ConsultarTodasSolicitudes();
                if (id_uni != 0) solicitudes = solicitudes.Where(x => x.ID_Universidad == id_uni).ToList();
                if (solicitudes == null || solicitudes.Count==0)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "No hay Solicitudes Activas";
                    return respuesta;
                }
                foreach (var item in solicitudes)
                {
                    item.NombreCarrera = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == item.ID_Carrera).Select(x => x.Nombre).FirstOrDefault();
                    item.NombreUniversidad = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == item.ID_Universidad).Select(x => x.Nombre).FirstOrDefault();
                    item.NombreUsuario = new UsuariosLogica().ConsultaUsuario(item.ID_Usuario).Nombres;
                    item.DescripcionEstado = new EstadosLogica().ConsultarEstados().Where(x => x.ID == item.Estado).FirstOrDefault().Estado;
                    item.Universidad = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == item.ID_Universidad).FirstOrDefault();
                    item.Universidad.Carreras = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == item.ID_Carrera).ToList();
                }
                
                respuesta.Respuesta = true;
                respuesta.Mensaje = "Solicitudes Consultadas Con Exito";
                respuesta.Solcitudes = solicitudes;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public int GetCantidadSolicitudes(int estado)
        {
            var solicitudes = _universidadesLogica.ConsultarTodasSolicitudes().Where(x=>x.Estado==estado).ToList();
            return solicitudes.Count();
        }


        // POST: api/Universidades
        public ResponseUniversidad Post([FromBody] Solicitud solicitud)
        {
            ResponseUniversidad respuesta = new ResponseUniversidad();
            try
            {
                solicitud.Estado = 6;
                solicitud.Fecha = DateTime.Now;
                _universidadesLogica.InsertarSolicitud(solicitud);
                new UsuariosLogica().InscribirUsuario(solicitud.ID_Usuario);
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

        // PUT: api/Universidades/5
        public ResponseSolicitud Put(int id_solicitud,int estado)
        {
            ResponseSolicitud respuesta = new ResponseSolicitud();
            try
            {
                _universidadesLogica.ActualizarSolicitud(id_solicitud, estado);
                var solicitudes = _universidadesLogica.ConsultarTodasSolicitudes();
                if (solicitudes == null || solicitudes.Count == 0)
                {
                    respuesta.Respuesta = false;
                    respuesta.Mensaje = "No hay Solicitudes Activas";
                    return respuesta;
                }
                foreach (var item in solicitudes)
                {
                    item.NombreCarrera = _universidadesLogica.ConsultarCarrera().Where(x => x.ID == item.ID_Carrera).Select(x => x.Nombre).FirstOrDefault();
                    item.NombreUniversidad = _universidadesLogica.ConsultarUniversidades().Where(x => x.ID == item.ID_Universidad).Select(x => x.Nombre).FirstOrDefault();
                    item.NombreUsuario = new UsuariosLogica().ConsultaUsuario(item.ID_Usuario).Nombres;
                    item.DescripcionEstado = new EstadosLogica().ConsultarEstados().Where(x => x.ID == item.Estado).FirstOrDefault().Estado;
                }

                respuesta.Respuesta = true;
                respuesta.Mensaje = "Solicitudes Consultadas Con Exito";
                respuesta.Solcitudes = solicitudes;
            }
            catch (Exception ex)
            {
                respuesta.Respuesta = false;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        //// DELETE: api/Universidades/5
        //public void Delete(int id)
        //{
        //}

    }
}
