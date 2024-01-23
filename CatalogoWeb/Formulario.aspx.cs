using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Formulario : System.Web.UI.Page
    {

        public bool EsNew { get; set; }
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            ConfirmaEliminacion=false;
            

            try
            {
                if(!IsPostBack)
                {

                    EsNew = true;
                    CategoriaNegocio CatNegocio = new CategoriaNegocio();
                    MarcaNegocio MarcaNegocio = new MarcaNegocio();

                    ddlCategoria.DataSource = CatNegocio.Listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = MarcaNegocio.Listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();



                    // Configuracion si es Modificacicón
                    string id = Request.QueryString["id"] != null ? Request.QueryString["Id"].ToString() : "";
                    if(id != "" && !IsPostBack)
                    {
                        EsNew = false;

                        ArticuloNegocio Negocio = new ArticuloNegocio();
                        Articulo Seleccionado = (Negocio.Listar(id))[0];

                        // Se Guarda En Session
                        Session.Add("ArtSeleccionado", Seleccionado);

                        // Precarga De Datos

                        TxtID.Text= Seleccionado.Id.ToString();
                        txtCodigo.Text = Seleccionado.Codigo;
                        txtImagenUrl.Text = Seleccionado.ImageUrl;
                        txtPrecio.Text = Convert.ToDouble(Seleccionado.Precio).ToString();
                        txtNombre.Text = Seleccionado.Nombre;
                        txtDescripcion.Text = Seleccionado.Descripcion;
                        ddlCategoria.SelectedValue = Seleccionado.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = Seleccionado.Marca.Id.ToString();
                        txtImagenUrl_TextChanged(sender, e);
                        
                    }

                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", "Hubo un Error" + ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaArticulo.aspx", false);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo Articulo = new Articulo();
                ArticuloNegocio Negocio = new ArticuloNegocio();

                Articulo.Codigo = txtCodigo.Text;
                Articulo.Nombre = txtNombre.Text;
                Articulo.Precio =  Decimal.Parse(txtPrecio.Text);
                Articulo.Descripcion = txtDescripcion.Text;
                Articulo.ImageUrl = txtImagenUrl.Text;
                Articulo.Categoria = new Categoria();
                Articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                Articulo.Marca = new Marca();
                Articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);


                if(Request.QueryString["id"] != null)
                {
                    Articulo.Id = int.Parse(TxtID.Text);
                    Negocio.Modificar(Articulo);
                }
                else
                {
                    Negocio.Agregar(Articulo);
                }

                Response.Redirect("ListaArticulo.aspx", false);

            }
            catch (Exception ex )
            {
                Session.Add("Error", "Hubo un Error a la hora de ingresar y/o Modificar un Articulo \r\\ " + ex);
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio Negocio = new ArticuloNegocio();
                Negocio.Eliminar(int.Parse(TxtID.Text));
                Response.Redirect("ListaArticulo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Hubo un Error a Eliminar " +  ex);
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}