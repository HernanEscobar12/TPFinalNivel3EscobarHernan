using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Marca> ListaMarca = new List<Marca>();
            try
            {
                Datos.SetConsulta("Select Id , Descripcion from MARCAS");
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {
                    Marca Marca = new Marca();
                    Marca.Id = (int)Datos.Reader["Id"];
                    Marca.Descripcion = (string)Datos.Reader["Descripcion"];
                    ListaMarca.Add(Marca);
                }
                return ListaMarca;
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
