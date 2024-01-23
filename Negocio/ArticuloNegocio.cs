using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using DataBase;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulo()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Articulo> ListaArticulos = new List<Articulo>();

            try
            {
                Datos.SetConsulta("select  A.Id , Codigo , Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca , A.IdCategoria , C.Descripcion Categoria , ImagenUrl , Precio  from ARTICULOS A , CATEGORIAS C , MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id");
                Datos.EjecutarLectura();
                while (Datos.Reader.Read())
                {
                    Articulo Articulo = new Articulo();
                    Articulo.Id = (int)Datos.Reader["Id"];
                    Articulo.Codigo = (string)Datos.Reader["Codigo"];
                    Articulo.Nombre = (string)Datos.Reader["Nombre"];
                    Articulo.Descripcion = (string)Datos.Reader["Descripcion"];
                    Articulo.Precio = (decimal)Datos.Reader["Precio"];
                    Articulo.ImageUrl = (string)Datos.Reader["ImagenUrl"];
                    Articulo.Marca = new Marca();
                    Articulo.Marca.Id = (int)Datos.Reader["IdMarca"];
                    Articulo.Marca.Descripcion = (string)Datos.Reader["Marca"];
                    Articulo.Categoria = new Categoria();
                    Articulo.Categoria.Id = (int)Datos.Reader["IdCategoria"];
                    Articulo.Categoria.Descripcion = (string)Datos.Reader["Categoria"];

                    ListaArticulos.Add(Articulo);
                }

                return ListaArticulos;
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

        public List<Articulo> Listar(string id)
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Articulo> DetalleArticulo = new List<Articulo>();
            try
            {
                Datos.SetConsulta("select  A.Id , Codigo , Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca , A.IdCategoria , C.Descripcion Categoria , ImagenUrl , Precio  from ARTICULOS A , CATEGORIAS C , MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id and A.Id = @id");
                Datos.SetearParametro("@id", id);
                Datos.EjecutarLectura();

                while (Datos.Reader.Read())
                {
                    Articulo Art = new Articulo();
                    Art.Id = (int)Datos.Reader["Id"];
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

                    DetalleArticulo.Add(Art);
                }
                return DetalleArticulo;

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

        public void Agregar(Articulo articulo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca , IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre , @Desc , @IdMarca , @IdCategoria , @Img , @precio)");
                Datos.SetearParametro("@Codigo", articulo.Codigo);
                Datos.SetearParametro("@Nombre", articulo.Nombre);
                Datos.SetearParametro("@Desc", articulo.Descripcion);
                Datos.SetearParametro("@IdMarca", articulo.Marca.Id);
                Datos.SetearParametro("@IdCategoria", articulo.Categoria.Id);
                Datos.SetearParametro("@Img", articulo.ImageUrl);
                Datos.SetearParametro("@precio", articulo.Precio);
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

        public void Modificar(Articulo articulo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("update ARTICULOS set Codigo = @Codigo , Nombre = @Nombre , Descripcion = @Desc , IdMarca = @IdMarca , IdCategoria = @IdCategoria , ImagenUrl = @Img , Precio = @Precio where Id = @Id");
                Datos.SetearParametro("@Codigo", articulo.Codigo);
                Datos.SetearParametro("@Nombre", articulo.Nombre);
                Datos.SetearParametro("@Desc", articulo.Descripcion);
                Datos.SetearParametro("@IdMarca", articulo.Marca.Id);
                Datos.SetearParametro("@IdCategoria", articulo.Categoria.Id);
                Datos.SetearParametro("@Img", articulo.ImageUrl);
                Datos.SetearParametro("@precio", articulo.Precio);
                Datos.SetearParametro("@Id", articulo.Id);
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

        public void Eliminar(int id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetConsulta("Delete ARTICULOS where Id = @id");
                Datos.SetearParametro("@id", id);
                Datos.EjecutarAccion();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public List<Articulo> Buscar(string campo, string criterio, string filtro)
        {
            List<Articulo> Lista = new List<Articulo>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                string consulta = "select  A.Id , Codigo , Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca , A.IdCategoria , C.Descripcion Categoria , ImagenUrl , Precio  from ARTICULOS A , CATEGORIAS C , MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";
                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " Nombre like  '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " Nombre like  '%" + filtro + "'";
                            break;
                        default:
                            consulta += " Nombre like  '%" + filtro + "%'";
                            break;
                    }
                }
                else if(campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a ":
                            consulta += " Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += " Precio < " + filtro;
                            break;
                        default:
                            consulta += " Precio = " + filtro;
                            break;
                    }
                }

                Datos.SetConsulta(consulta);
                Datos.EjecutarLectura();

                while (Datos.Reader.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)Datos.Reader["Id"];
                    art.Codigo = (string)Datos.Reader["Codigo"];
                    art.Nombre = (string)Datos.Reader["Nombre"];
                    art.Descripcion = (string)Datos.Reader["Descripcion"];
                    if (!(Datos.Reader["ImagenUrl"] is DBNull))
                        art.ImageUrl = (string)Datos.Reader["ImagenUrl"];
                    art.Precio = (decimal)Datos.Reader["Precio"];
                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)Datos.Reader["IdCategoria"];
                    art.Categoria.Descripcion = (string)Datos.Reader["Categoria"];
                    art.Marca = new Marca();
                    art.Marca.Id = (int)Datos.Reader["IdMarca"];
                    art.Marca.Descripcion = (string)Datos.Reader["Marca"];

                    Lista.Add(art);
                }

                return Lista;
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
