using SoftUNI.WebAPI.Models.Universidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Datos.Universidades
{
    public class UniversidadDataContext
    {
        public List<Universidad> ConsultarUniversidad()
        {
            var lista = new List<Universidad>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.ConsultarUniversidades;
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                while (dr.Read())
                {
                    lista.Add(new Universidad
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                        Region = dr.IsDBNull(dr.GetOrdinal("Region")) ? string.Empty : dr["Region"].ToString(),
                        Provincia = dr.IsDBNull(dr.GetOrdinal("Provincia")) ? string.Empty : dr["Provincia"].ToString(),
                        Municipio = dr.IsDBNull(dr.GetOrdinal("Municipio")) ? string.Empty : dr["Municipio"].ToString(),
                        Sector = dr.IsDBNull(dr.GetOrdinal("Sector")) ? string.Empty : dr["Sector"].ToString(),
                        Residencia = dr.IsDBNull(dr.GetOrdinal("Residencia")) ? string.Empty : dr["Residencia"].ToString(),
                        Imagen = dr.IsDBNull(dr.GetOrdinal("Imagen")) ? string.Empty : dr["Imagen"].ToString()
                    });
                }
                return lista;
            }
        }

        public List<Carrera> ConsultarCarrera()
        {
            var lista = new List<Carrera>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.ConsultarCarreras;
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                while (dr.Read())
                {
                    lista.Add(new Carrera
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        ID_Universidad = dr.IsDBNull(dr.GetOrdinal("ID_Universidad")) ? 0 : int.Parse(dr["ID_Universidad"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                    });
                }
                return lista;
            }
        }

        public void InsertarSolicitud(Solicitud solicitud)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.InsertarSolicitud;
                cmd.Parameters.AddWithValue("ID_Estudiante", solicitud.ID_Usuario);
                cmd.Parameters.AddWithValue("ID_Universidad", solicitud.ID_Universidad);
                cmd.Parameters.AddWithValue("ID_Carrera", solicitud.ID_Carrera);
                cmd.Parameters.AddWithValue("Fecha", solicitud.Fecha);
                cmd.Parameters.AddWithValue("Estado", solicitud.Estado);
                var dr = cmd.ExecuteReader();
            }
        }

        public Solicitud ConsultarSolicitud(int id_user)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.ConsultarSolicitudes;
                cmd.Parameters.AddWithValue("id", id_user);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                dr.Read();
                Solicitud solicitud = new Solicitud
                {
                    ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                    ID_Usuario = dr.IsDBNull(dr.GetOrdinal("us")) ? 0 : int.Parse(dr["us"].ToString()),
                    ID_Universidad = dr.IsDBNull(dr.GetOrdinal("uni")) ? 0 : int.Parse(dr["uni"].ToString()),
                    ID_Carrera = dr.IsDBNull(dr.GetOrdinal("carr")) ? 0 : int.Parse(dr["carr"].ToString()),
                    Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? 0 : int.Parse(dr["Estado"].ToString())

                };
                return solicitud;
            }
        }

        public List<Solicitud> ConsultarTodasSolicitudes()
        {
            List<Solicitud> lista = new List<Solicitud>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.ConsultarTodasLasSolicitudes;
                //cmd.Parameters.AddWithValue("id", id_user);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                while (dr.Read())
                {
                    lista.Add(new Solicitud
                    {

                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        ID_Usuario = dr.IsDBNull(dr.GetOrdinal("us")) ? 0 : int.Parse(dr["us"].ToString()),
                        ID_Universidad = dr.IsDBNull(dr.GetOrdinal("uni")) ? 0 : int.Parse(dr["uni"].ToString()),
                        ID_Carrera = dr.IsDBNull(dr.GetOrdinal("carr")) ? 0 : int.Parse(dr["carr"].ToString()),
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? 0 : int.Parse(dr["Estado"].ToString()),
                        Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? new DateTime(2000,1,1) : DateTime.Parse(dr["Fecha"].ToString())
                    });
                }
                return lista;
            }
        }

        public void ActualizarSolicitud(int id_solicitud, int estado)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUniversidades.ActualizarEstadoSolicitud;
                cmd.Parameters.AddWithValue("estado", estado);
                cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("id", id_solicitud);
              cmd.ExecuteNonQuery();
            }
        }
    }
}