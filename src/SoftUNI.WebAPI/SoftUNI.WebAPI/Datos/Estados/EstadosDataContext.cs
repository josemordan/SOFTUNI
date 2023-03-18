using SoftUNI.WebAPI.Models.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Datos.Estados
{
    public class EstadosDataContext
    {
        public List<EstadosDocumentos> ConsultarDocumentos()
        {
            var lista = new List<EstadosDocumentos>();
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEstados.ConsultarEstados;
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return lista;
                while (dr.Read())
                {
                    lista.Add(new EstadosDocumentos
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? string.Empty : dr["Estado"].ToString()
                    });
                }
                return lista;
            }
        }
    }
}