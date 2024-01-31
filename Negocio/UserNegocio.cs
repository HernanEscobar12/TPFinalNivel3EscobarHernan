using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UserNegocio
    {
        // Id
        // Email
        // Pass
        // Admin

        // Nombre, Apellido , Fecha, Imagen

        public void InsertNew(User Usuario)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetConsulta("insert into USERS (nombre, apellido ,email, pass ) values (@nombre, @apellido, @email, @pass)");
                Datos.SetearParametro("@nombre", Usuario.Nombre);
                Datos.SetearParametro("@apellido", Usuario.Apellido);
                Datos.SetearParametro("@email", Usuario.Email);
                Datos.SetearParametro("@pass", Usuario.Pass);
                Datos.EjecutarAccion();


            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }



        }
    
        public void Update (User user)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update USERS set email = @email, pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img where Id = @id");
                Datos.SetearParametro("@email" , user.Email);
                Datos.SetearParametro("@pass" , user.Pass);
                Datos.SetearParametro("@nombre" , user.Nombre);
                Datos.SetearParametro("@apellido" , user.Apellido);
                Datos.SetearParametro("@img", user.ImagePerfil);
                Datos.SetearParametro("@id", user.Id);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }

        }

        public bool Login(User user)
        {

            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil, admin  from USERS where email = @email And pass = @pass");
                Datos.SetearParametro("@email", user.Email);
                Datos.SetearParametro("@pass" , user.Pass);
                Datos.EjecutarLectura();
                if(Datos.Reader.Read())
                {
                    user.Id = (int)Datos.Reader["id"];
                    user.Admin = (bool)Datos.Reader["admin"];
                    if (!(Datos.Reader["nombre"] is DBNull))
                        user.Nombre = (string)Datos.Reader["nombre"];
                    if (!(Datos.Reader["apellido"] is DBNull))
                        user.Apellido = (string)Datos.Reader["apellido"];
                    if (!(Datos.Reader["urlImagenPerfil"] is DBNull))
                        user.ImagePerfil = (string)Datos.Reader["urlImagenPerfil"];

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }


        }

        public List<User> ListaUsuario()
        {
            List<User> ListaUser = new List<User>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS");
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {

                    User user = new User();
                    user.Id = (int)Datos.Reader["id"];
                    user.Admin = (bool)Datos.Reader["admin"];
                    user.Email = (string)Datos.Reader["email"];
                    if (!(Datos.Reader["nombre"] is DBNull))
                        user.Nombre = (string)Datos.Reader["nombre"];
                    if (!(Datos.Reader["apellido"] is DBNull))
                        user.Apellido = (string)Datos.Reader["apellido"];
                    if (!(Datos.Reader["urlImagenPerfil"] is DBNull))
                        user.ImagePerfil = (string)Datos.Reader["urlImagenPerfil"];
                    ListaUser.Add(user);
                }
                return ListaUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public List<User> BuscarUser(string id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                List<User> ListaUser = new List<User>();
                Datos.SetConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil, admin  from USERS where id = @id");
                Datos.SetearParametro("@id", id);
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {
                    User user = new User();
                    user.Id = (int)Datos.Reader["id"];
                    user.Admin = (bool)Datos.Reader["admin"];
                    user.Email = (string)Datos.Reader["email"];
                    if (!(Datos.Reader["nombre"] is DBNull))
                        user.Nombre = (string)Datos.Reader["nombre"];
                    if (!(Datos.Reader["apellido"] is DBNull))
                        user.Apellido = (string)Datos.Reader["apellido"];
                    if (!(Datos.Reader["urlImagenPerfil"] is DBNull))
                        user.ImagePerfil = (string)Datos.Reader["urlImagenPerfil"];
                    ListaUser.Add(user);
                }

                return ListaUser;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("DELETE USERS where id = @id");
                Datos.SetearParametro("@id", id);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }

        }

    }
}
