using SoftUNI.WebAPI.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Datos.Usuarios
{
    public class UsuarioDataContext
    {

        public Usuario ConsultarInfoDumy(string cedula)
        {

            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ConsultarInfoUsuarioDumy;
                cmd.Parameters.AddWithValue("cedula", cedula);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                dr.Read();
                var usuario = new Usuario
                {
                    Nombres = dr.IsDBNull(dr.GetOrdinal("Nombres")) ? string.Empty : dr["Nombres"].ToString(),
                    Apellidos = dr.IsDBNull(dr.GetOrdinal("Apellidos")) ? string.Empty : dr["Apellidos"].ToString(),
                    Identificacion = dr.IsDBNull(dr.GetOrdinal("Identificacion")) ? string.Empty : dr["Identificacion"].ToString(),

                    Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString(),
                    Celular = dr.IsDBNull(dr.GetOrdinal("Celular")) ? string.Empty : dr["Celular"].ToString(),
                    Fecha_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Fecha_Nacimiento")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Nacimiento"].ToString()),
                    Lugar_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Lugar_Nacimiento")) ? string.Empty : dr["Lugar_Nacimiento"].ToString(),
                    Nacionalidad = dr.IsDBNull(dr.GetOrdinal("Nacionalidad")) ? string.Empty : dr["Nacionalidad"].ToString(),
                    Region = dr.IsDBNull(dr.GetOrdinal("Region")) ? string.Empty : dr["Region"].ToString(),
                    Provincia = dr.IsDBNull(dr.GetOrdinal("Provincia")) ? string.Empty : dr["Provincia"].ToString(),
                    Municipio = dr.IsDBNull(dr.GetOrdinal("Municipio")) ? string.Empty : dr["Municipio"].ToString(),
                    Sector = dr.IsDBNull(dr.GetOrdinal("Sector")) ? string.Empty : dr["Sector"].ToString(),
                    Residencia = dr.IsDBNull(dr.GetOrdinal("Residencia")) ? string.Empty : dr["Residencia"].ToString()
                };
                return usuario;
            }
        }

        public Usuario ConsultarUsuario(int id)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ConsultaUsuario;
                cmd.Parameters.AddWithValue("id", id);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                dr.Read();
                var usuario = new Usuario
                {
                    ID_Usuario = dr.IsDBNull(dr.GetOrdinal("ID_Usuario")) ? 0 : int.Parse(dr["ID_Usuario"].ToString()),
                    Nombres = dr.IsDBNull(dr.GetOrdinal("Nombres")) ? string.Empty : dr["Nombres"].ToString(),
                    Apellidos = dr.IsDBNull(dr.GetOrdinal("Apellidos")) ? string.Empty : dr["Apellidos"].ToString(),
                    Identificacion = dr.IsDBNull(dr.GetOrdinal("Identificacion")) ? string.Empty : dr["Identificacion"].ToString(),
                    Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? string.Empty : dr["Correo"].ToString(),
                    Clave = dr.IsDBNull(dr.GetOrdinal("Clave")) ? string.Empty : dr["Clave"].ToString(),
                    Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString(),
                    Celular = dr.IsDBNull(dr.GetOrdinal("Celular")) ? string.Empty : dr["Celular"].ToString(),
                    Fecha_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Fecha_Nacimiento")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Nacimiento"].ToString()),
                    Lugar_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Lugar_Nacimiento")) ? string.Empty : dr["Lugar_Nacimiento"].ToString(),
                    Nacionalidad = dr.IsDBNull(dr.GetOrdinal("Nacionalidad")) ? string.Empty : dr["Nacionalidad"].ToString(),
                    Region = dr.IsDBNull(dr.GetOrdinal("Region")) ? string.Empty : dr["Region"].ToString(),
                    Provincia = dr.IsDBNull(dr.GetOrdinal("Provincia")) ? string.Empty : dr["Provincia"].ToString(),
                    Municipio = dr.IsDBNull(dr.GetOrdinal("Municipio")) ? string.Empty : dr["Municipio"].ToString(),
                    Sector = dr.IsDBNull(dr.GetOrdinal("Sector")) ? string.Empty : dr["Sector"].ToString(),
                    Residencia = dr.IsDBNull(dr.GetOrdinal("Residencia")) ? string.Empty : dr["Residencia"].ToString(),
                    Matricula = dr.IsDBNull(dr.GetOrdinal("Matricula")) ? string.Empty : dr["Matricula"].ToString(),
                    Tipo = dr.IsDBNull(dr.GetOrdinal("Tipo")) ? 0 : int.Parse(dr["Tipo"].ToString())
                };
                return usuario;
            }
        }

        public bool ExisteUsuario(string cedula)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ValidaExisteUser;
                cmd.Parameters.AddWithValue("cedula", cedula);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return false;
                return true;
            }
        }

        public void EliminarUsuario(int id)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.EliminarUsuario;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.InsertarUsuario;
                cmd.Parameters.AddWithValue("Nombre", usuario.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("Identificacion", usuario.Identificacion);
                cmd.Parameters.AddWithValue("Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("Fecha_Nacimiento", usuario.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("Lugar_Nacimiento", usuario.Lugar_Nacimiento);
                cmd.Parameters.AddWithValue("Nacionalidad", usuario.Nacionalidad);
                cmd.Parameters.AddWithValue("Region", usuario.Region);
                cmd.Parameters.AddWithValue("Provincia", usuario.Provincia);
                cmd.Parameters.AddWithValue("Municipio", usuario.Municipio);
                cmd.Parameters.AddWithValue("Sector", usuario.Sector);
                cmd.Parameters.AddWithValue("Residencia", usuario.Residencia);
                cmd.Parameters.AddWithValue("Tipo", usuario.Tipo);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ActualizarUsuario;
                //cmd.Parameters.AddWithValue("Nombre", usuario.Nombres);
                //cmd.Parameters.AddWithValue("Apellidos", usuario.Apellidos);
                //cmd.Parameters.AddWithValue("Identificacion", usuario.Identificacion);
                //cmd.Parameters.AddWithValue("Correo", usuario.Correo);
                //cmd.Parameters.AddWithValue("Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("Celular", usuario.Celular);
                //cmd.Parameters.AddWithValue("Fecha_Nacimiento", usuario.Fecha_Nacimiento);
                //cmd.Parameters.AddWithValue("Lugar_Nacimiento", usuario.Lugar_Nacimiento);
                //cmd.Parameters.AddWithValue("Nacionalidad", usuario.Nacionalidad);
                cmd.Parameters.AddWithValue("Region", usuario.Region);
                cmd.Parameters.AddWithValue("Provincia", usuario.Provincia);
                cmd.Parameters.AddWithValue("Municipio", usuario.Municipio);
                cmd.Parameters.AddWithValue("Sector", usuario.Sector);
                cmd.Parameters.AddWithValue("Residencia", usuario.Residencia);
                cmd.Parameters.AddWithValue("id", usuario.ID_Usuario);
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario ValidaLogin(string user, string clave)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ValidaLoginUsuario;
                cmd.Parameters.AddWithValue("user", user);
                cmd.Parameters.AddWithValue("clave", clave);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return null;
                dr.Read();
                var usuario = new Usuario
                {
                    ID_Usuario = dr.IsDBNull(dr.GetOrdinal("ID_Usuario")) ? 0 : int.Parse(dr["ID_Usuario"].ToString()),
                    Nombres = dr.IsDBNull(dr.GetOrdinal("Nombres")) ? string.Empty : dr["Nombres"].ToString(),
                    Apellidos = dr.IsDBNull(dr.GetOrdinal("Apellidos")) ? string.Empty : dr["Apellidos"].ToString(),
                    Identificacion = dr.IsDBNull(dr.GetOrdinal("Identificacion")) ? string.Empty : dr["Identificacion"].ToString(),
                    Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? string.Empty : dr["Correo"].ToString(),
                    Clave = dr.IsDBNull(dr.GetOrdinal("Clave")) ? string.Empty : dr["Clave"].ToString(),
                    Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString(),
                    Celular = dr.IsDBNull(dr.GetOrdinal("Celular")) ? string.Empty : dr["Celular"].ToString(),
                    Fecha_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Fecha_Nacimiento")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Nacimiento"].ToString()),
                    Lugar_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Lugar_Nacimiento")) ? string.Empty : dr["Lugar_Nacimiento"].ToString(),
                    Nacionalidad = dr.IsDBNull(dr.GetOrdinal("Nacionalidad")) ? string.Empty : dr["Nacionalidad"].ToString(),
                    Region = dr.IsDBNull(dr.GetOrdinal("Region")) ? string.Empty : dr["Region"].ToString(),
                    Provincia = dr.IsDBNull(dr.GetOrdinal("Provincia")) ? string.Empty : dr["Provincia"].ToString(),
                    Municipio = dr.IsDBNull(dr.GetOrdinal("Municipio")) ? string.Empty : dr["Municipio"].ToString(),
                    Sector = dr.IsDBNull(dr.GetOrdinal("Sector")) ? string.Empty : dr["Sector"].ToString(),
                    Residencia = dr.IsDBNull(dr.GetOrdinal("Residencia")) ? string.Empty : dr["Residencia"].ToString()
                };
                return usuario;
            }
        }

        public long GenerarMatricula(int Id_Usuario)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.GenerarMatricula;
                var dr = cmd.ExecuteReader();
                dr.Read();
                return dr.IsDBNull(dr.GetOrdinal("Matricula")) ? 0 : long.Parse(dr["Matricula"].ToString());
            }
        }

        public void InsertarMatricula(long Matricula)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.InsertarMatricula;
                cmd.Parameters.AddWithValue("matricula", Matricula);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarMatriculaUsuario(int id_user, long matricula)
        {
            using (var cnn = new Conexion().ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ActualizarMatriculaUsuario;
                cmd.Parameters.AddWithValue("matricula", matricula);
                cmd.Parameters.AddWithValue("id", id_user);
                cmd.ExecuteNonQuery();
            }
        }

    }
}