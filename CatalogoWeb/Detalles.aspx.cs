using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Detalles : System.Web.UI.Page
    {
        //public List<Articulo> DetallesArt { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo DetallesArt = (negocio.Listar(id))[0];
                        FavoritoNegocio FavoritoNegocio = new FavoritoNegocio();
                        User Usuario = (User)Session["UsuarioActivo"];


                        //Carga
                        @Title = DetallesArt.Nombre;
                        txt2Nombre.Text = DetallesArt.Nombre;
                        txtCodigo.Text = DetallesArt.Codigo;
                        txtDescripcion.Text = DetallesArt.Descripcion;
                        txtPrecio.Text = DetallesArt.Precio.ToString();
                        txtCategoria.Text = DetallesArt.Categoria.Descripcion.ToString();
                        txtMarca.Text = DetallesArt.Marca.Descripcion.ToString();
                        imgUrl.ImageUrl = DetallesArt.ImageUrl.ToString();
                        if ((Session["UsuarioActivo"] != null))
                        {
                            if (FavoritoNegocio.IsFav(Usuario.Id, DetallesArt.Id))
                            {
                                chkFavorito.Checked = true;
                            }
                        }
                        else
                        { chkFavorito.Checked = false; }

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void chkFavorito_CheckedChanged(object sender, EventArgs e)
        {
            if ((Session["UsuarioActivo"] != null))
            {
                FavoritoNegocio FavoritoNegocio = new FavoritoNegocio();
                User Usuario = (User)Session["UsuarioActivo"];
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (chkFavorito.Checked)
                    FavoritoNegocio.AgregarFavorito(Usuario.Id, id);
                else
                    FavoritoNegocio.EliminarFavorito(Usuario.Id, id);
            }
            else
                Response.Redirect("Login.aspx", false);
        }
    }
}