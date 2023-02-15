using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Datos
{
    public class Conexion
    {
        private string ConexionDB()
        {
            var conexion = ConfigurationManager.ConnectionStrings["mssql"];
            return conexion.ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConexionDB());
        }
    }
}