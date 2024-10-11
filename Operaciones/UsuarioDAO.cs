using apiLogisticafs.Context;

using apiLogisticafs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace apiLogisticafs.Operaciones
{
    public class UsuarioDAO
    {
        public LogisticafsContext contexto = new LogisticafsContext();

        public List<Usuario> seleccionarTodos()
        {
            var usuarios = contexto.Usuarios.ToList<Usuario>();
            return usuarios;
        }
        public Usuario seleccionar(int id)
        {
            var userSeleccionado = contexto.Usuarios.Where(a => a.UsuId == id).FirstOrDefault();
            return userSeleccionado;
        }
        public Usuario autenticar(string usu, string pass)
        {
            var userAuth = contexto.Usuarios.Where(u => u.UsuUsuario == usu & u.UsuPassword == pass).FirstOrDefault();
            return userAuth;
        }
        public int insertarUsuario(string nombre, string email, string telefono, string usuario, string clave)
        {
            //inserta usarios y devuelve el ID generado por la DB,
            //si quiero solo true o false cambiar el Int por Bool y cambiar los return
            try
            {
                Usuario user = new Usuario();
                LogEvento evento = new LogEvento();
                user.UsuNombre = nombre;
                user.UsuEmail = email;
                user.UsuTelefono = telefono;
                user.UsuUsuario = usuario;
                user.UsuPassword = clave;

                contexto.Usuarios.Add(user);
                contexto.SaveChanges();

                evento.Evento = "INSERTAR USUARIO";
                evento.Mensaje = "Insercion de usuario OK";
                evento.SessionId = 1001;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();


                return user.UsuId;
            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "INSERTAR USUARIO";
                evento.Mensaje = ex.Message;
                evento.SessionId = 1001;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return -1;
            }
        }//retorna ID
        public bool modificarUsuario(int id, string nombre, string email, string telefono, string usuario, string clave)
        {
            try
            {
                var user = seleccionar(id);
                if (user == null)
                {
                    LogEvento evento = new LogEvento();
                    evento.Evento = "MODIFICAR USUARIO";
                    evento.Mensaje = "USUARIO NO EXISTE";
                    evento.SessionId = 1002;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();
                    return false;
                }
                else
                {
                    LogEvento evento = new LogEvento();
                    user.UsuNombre = nombre;
                    user.UsuEmail = email;
                    user.UsuTelefono = telefono;
                    user.UsuUsuario = usuario;
                    user.UsuPassword = clave;


                    contexto.SaveChanges();

                    evento.Evento = "MODIFICAR USUARIO";
                    evento.Mensaje = "Usuario ID:" + id + " modificado correctamente";
                    evento.SessionId = 1002;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();
                    return true;
                }


            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "MODIFICAR USUARIO";
                evento.Mensaje = ex.Message;
                evento.SessionId = 1002;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return false;
            }
        }
        public bool eliminarUsuario(int id)
        {
            try
            {
                var user = seleccionar(id);
                if (user == null)
                {
                    LogEvento evento = new LogEvento();
                    evento.Evento = "ELIMINARAR USUARIO";
                    evento.Mensaje = "USUARIO NO EXISTE";
                    evento.SessionId = 1002;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();
                    return false;
                }
                else
                {
                    LogEvento evento = new LogEvento();
                    contexto.Usuarios.Remove(user);
                    contexto.SaveChanges();

                    evento.Evento = "ELIMINAR USUARIO";
                    evento.Mensaje = "Usuario ID:" + id + " eliminado correctamente";
                    evento.SessionId = 1002;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {

                return false;
            }

        }

       
    }
}
