using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftUNI.WebAPI.Models.Documentos;

namespace SoftUNI.WebAPI.Datos.Documentos
{
    public class DocumentosDataContext
    {
        public List<Documento> ConsultarDocumentos(int id_usuario)
        {
            var lista = new List<Documento>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ConsultarDocumentos;
                cmd.Parameters.AddWithValue("id", id_usuario);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return lista;
                while (dr.Read())
                {
                    lista.Add(new Documento
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id_documento")) ? 0 : int.Parse(dr["id_documento"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre_Documento")) ? string.Empty : dr["Nombre_Documento"].ToString(),
                        Institucion = dr.IsDBNull(dr.GetOrdinal("Institucion")) ? string.Empty : dr["Institucion"].ToString(),
                        ID_Usuario = dr.IsDBNull(dr.GetOrdinal("ID_Usuario")) ? 0 : int.Parse(dr["ID_Usuario"].ToString()),
                        Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? new DateTime(1990, 1, 1) : DateTime.Parse(dr["Fecha"].ToString()),
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado_Documento")) ? "No Cargado" : dr["Estado_Documento"].ToString(),
                        Ruta = dr.IsDBNull(dr.GetOrdinal("Ruta")) ? string.Empty : dr["Ruta"].ToString(),
                        Tarifa = dr.IsDBNull(dr.GetOrdinal("Monto")) ? 0 : decimal.Parse(dr["Monto"].ToString()),
                    });
                }
                return lista;
            }
        }

        public void InsertarDocumento(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.InsertarDocumento;
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                cmd.Parameters.AddWithValue("Fecha", documento.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", documento.Estado);
                cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDocumento(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ActualizarDocumento;
                cmd.Parameters.AddWithValue("Fecha", documento.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", documento.Estado);
                cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                cmd.ExecuteNonQuery();
            }
        }

        public decimal ConsultarTarifa(int id_doc)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ObtenerTarifaDocumento;
                cmd.Parameters.AddWithValue("doc", id_doc);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return 0;
                dr.Read();
                return dr.IsDBNull(dr.GetOrdinal("Monto")) ? 0 : decimal.Parse(dr["Monto"].ToString());
            }
        }
    }
}