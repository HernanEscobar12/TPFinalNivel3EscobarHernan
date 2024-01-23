using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNegocio
    {


        public List<Articulo> ListarFavoritos(int id)
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Articulo> ArticulosFavoritos = new List<Articulo>();
            try
            {
                Datos.SetConsulta("Select IdArticulo, Nombre, Codigo, A.Descripcion, Precio, ImagenUrl ,A.IdMarca, M.Descripcion Marca , A.IdCategoria, C.Descripcion Categoria from FAVORITOS F, ARTICULOS A, MARCAS M, CATEGORIAS C where  IdUser = @idUser and A.Id = F.IdArticulo and M.Id = A.IdMarca and C.Id = A.IdCategoria");
                Datos.SetearParametro("@idUser", id);
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {
                    Articulo Art = new Articulo();
                    Art.Codigo = (string)Datos.Reader["Codigo"];
                    Art.Nombre = (string)Datos.Reader["Nombre"];
                    Art.Descripcion = (string)Datos.Reader["Descripcion"];
                    Art.Precio = (decimal)Datos.Reader["Precio"];
                    Art.ImageUrl = (string)Datos.Reader["ImagenUrl"];
                    Art.Marca = new Marca();
                    Art.Marca.Id = (int)Datos.Reader["IdMarca"];
                    Art.Marca.Descripcion = (string)Datos.Reader["Marca"];
                    Art.Categoria = new Categoria();
                    Art.Categoria.Id = (int)Datos.Reader["IdCategoria"];
                    Art.Categoria.Descripcion = (string)Datos.Reader["Categoria"];

                    ArticulosFavoritos.Add(Art);

                }

                return ArticulosFavoritos;
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

        public void AgregarFavorito(int idUser , string idArticulo) 
        {
			AccesoDatos Datos = new AccesoDatos();

			try
			{
				Datos.SetConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@idUser , @idArt)");
				Datos.SetearParametro("@idUser", idUser);
				Datos.SetearParametro("@idArt", idArticulo);
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

		public bool IsFav(int id, int idArticulo)
		{
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetConsulta("select IdUser, IdArticulo from FAVORITOS WHERE IdUser = @idUser and IdArticulo = @idArt");
                Datos.SetearParametro("@idUser" , id);
                Datos.SetearParametro("@idArt" , idArticulo);
                Datos.EjecutarLectura();
                if (Datos.Reader.Read())
                    return true;
                else
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

        public void EliminarFavorito(int idUser, string idArticulo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("delete FAVORITOS where IdUser = @idUser and IdArticulo = @idArt");
                Datos.SetearParametro("@idUser", idUser);
                Datos.SetearParametro("@idArt", idArticulo);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }
    }
}
