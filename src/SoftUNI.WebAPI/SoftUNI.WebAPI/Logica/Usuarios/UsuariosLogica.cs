using SoftUNI.WebAPI.Datos.Usuarios;
using SoftUNI.WebAPI.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Logica.Usuarios
{
    public class UsuariosLogica
    {
        public readonly UsuarioDataContext _usuarioData;
        public UsuariosLogica()
        {
            _usuarioData = new UsuarioDataContext();
        }

        public Usuario ConsultaUsuario(int id)
        {
            var usuario = _usuarioData.ConsultarUsuario(id);
            usuario.Clave = DesEncriptarClave(usuario.Clave);
            return usuario;
        }

        public Usuario ConsultaUsuarioDumy(string cedula)
        {
            return _usuarioData.ConsultarInfoDumy(cedula);
        }

        public void InsertarUsuario(Usuario usuario)
        {
            usuario.Clave = EncriptarClave(usuario.Clave);
            _usuarioData.InsertarUsuario(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioData.ActualizarUsuario(usuario);
        }

        public bool ExisteUsuario(string cedula)
        {
            return _usuarioData.ExisteUsuario(cedula);
        }

        public void EliminarUsuario(int id)
        {
            _usuarioData.EliminarUsuario(id);
        }

        /////////////// Login
        public Usuario ValidaLogin(string user, string clave)
        {
            var usuario = _usuarioData.ValidaLogin(user, EncriptarClave(clave));
            if (usuario != null) usuario.Clave = DesEncriptarClave(usuario.Clave);
            return usuario;
        }

        public string EncriptarClave(string clave)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(clave);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string DesEncriptarClave(string clave)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(clave);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}