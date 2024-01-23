using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {

       public List<Categoria> Listar()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Categoria> ListaCategorias = new List<Categoria>();
            try
            {
                Datos.SetConsulta("Select  Id, Descripcion from CATEGORIAS");
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {
                    Categoria Cat = new Categoria();
                    Cat.Id = (int)Datos.Reader["Id"];
                    Cat.Descripcion = (string)Datos.Reader["Descripcion"];


                    ListaCategorias.Add(Cat);
                }

                return ListaCategorias;
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
