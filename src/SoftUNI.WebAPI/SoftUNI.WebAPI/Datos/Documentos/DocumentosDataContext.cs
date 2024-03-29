﻿using System;
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
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado_Documento")) ? 1 : int.Parse(dr["Estado_Documento"].ToString()),
                        Ruta = dr.IsDBNull(dr.GetOrdinal("Ruta")) ? string.Empty : dr["Ruta"].ToString(),
                        Legalizacion = dr.IsDBNull(dr.GetOrdinal("Legalizacion")) ? false : Boolean.Parse( dr["Legalizacion"].ToString()),
                        Tarifa = dr.IsDBNull(dr.GetOrdinal("Monto")) ? 0 : decimal.Parse(dr["Monto"].ToString()),
                        Fisico = dr.IsDBNull(dr.GetOrdinal("Fisico")) ? false : Boolean.Parse(dr["Fisico"].ToString()),
                        Legalizar = dr.IsDBNull(dr.GetOrdinal("Legalizado")) ? false : Boolean.Parse(dr["Legalizado"].ToString()),
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
                //cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.Parameters.AddWithValue("Fisico", documento.Fisico);
                cmd.Parameters.AddWithValue("Legalizar", documento.Legalizar);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDocumento(SolicitudDocumento solicitud)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ActualizarDocumento;
                cmd.Parameters.AddWithValue("Fecha", solicitud.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", solicitud.Estado);
                cmd.Parameters.AddWithValue("Ruta", solicitud.Ruta);
                cmd.Parameters.AddWithValue("id", solicitud.ID);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void BorrarDocumento(int id_doc, int id_user)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.BorrarDocumento;
                cmd.Parameters.AddWithValue("ID_Documento", id_doc);
                cmd.Parameters.AddWithValue("ID_Usuario", id_user);
                cmd.ExecuteNonQuery();
            }
        }

        public void LegalizarDocumento(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.LegalizarDocumento;
                cmd.Parameters.AddWithValue("Fecha", documento.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", documento.Estado);
                cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                cmd.ExecuteNonQuery();
            }
        }

        public bool ExisteDocumentoSolicitud(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ExisteDocumentoSolicitud;
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return false;
                return true;
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

        public List<Documento> ConsultarDocumentosRequeridos(int id_usuario)
        {
            var lista = new List<Documento>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ConsutlarDocumentosRequeridos;
                cmd.Parameters.AddWithValue("id", id_usuario);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return lista;
                while (dr.Read())
                {
                    lista.Add(new Documento
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id_documento")) ? 0 : int.Parse(dr["id_documento"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                        Institucion = dr.IsDBNull(dr.GetOrdinal("Institucion")) ? string.Empty : dr["Institucion"].ToString(),
                        ID_Usuario = dr.IsDBNull(dr.GetOrdinal("ID_Usuario")) ? 0 : int.Parse(dr["ID_Usuario"].ToString()),
                        Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? new DateTime(1990, 1, 1) : DateTime.Parse(dr["Fecha"].ToString()),
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado_Documento")) ? 1 : int.Parse(dr["Estado_Documento"].ToString()),
                        Ruta = dr.IsDBNull(dr.GetOrdinal("Ruta")) ? string.Empty : dr["Ruta"].ToString()
                    });
                }
                return lista;
            }
        }

        public void InsertarDocumentoRequeridos(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.InsertarDocumentoRequerido;
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                cmd.Parameters.AddWithValue("Fecha", documento.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", documento.Estado);
                cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDocumentoRequerido(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ActualizarDocumentoRequerido;
                cmd.Parameters.AddWithValue("Fecha", documento.Fecha);
                cmd.Parameters.AddWithValue("Estado_Documento", documento.Estado);
                //cmd.Parameters.AddWithValue("Ruta", documento.Ruta);
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarDocumentoRequerido(int id_doc, int id_user)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.BorrarDocumentoRequerido;
                cmd.Parameters.AddWithValue("ID_Documento", id_doc);
                cmd.Parameters.AddWithValue("ID_Usuario", id_user);
                cmd.ExecuteNonQuery();
            }
        }

        public bool ExisteDocumentoRequerido(Documento documento)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ExisteDocumentoRequerido;
                cmd.Parameters.AddWithValue("ID_Documento", documento.ID);
                cmd.Parameters.AddWithValue("ID_Usuario", documento.ID_Usuario);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return false;
                return true;
            }
        }
    
        public List<SolicitudDocumento> ConsultarSolicitudes()
        {
            var lista = new List<SolicitudDocumento>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysDocumentos.ConsultarTodasSolicitudes;
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return lista;
                while (dr.Read())
                {
                    lista.Add(new SolicitudDocumento
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        ID_Documento = dr.IsDBNull(dr.GetOrdinal("id_documento")) ? 0 : int.Parse(dr["id_documento"].ToString()),
                        ID_Usuario = dr.IsDBNull(dr.GetOrdinal("ID_Usuario")) ? 0 : int.Parse(dr["ID_Usuario"].ToString()),
                        Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? new DateTime(1990, 1, 1) : DateTime.Parse(dr["Fecha"].ToString()),
                        Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? 1 : int.Parse(dr["estado"].ToString()),
                        Ruta = dr.IsDBNull(dr.GetOrdinal("Ruta")) ? string.Empty : dr["Ruta"].ToString(),
                        Fisico = dr.IsDBNull(dr.GetOrdinal("Fisico")) ? false : Boolean.Parse(dr["Fisico"].ToString()),
                        Legalizar = dr.IsDBNull(dr.GetOrdinal("Legalizado")) ? false : Boolean.Parse(dr["Legalizado"].ToString()),
                    });
                }
                return lista;
            }
        }
    
    }
}