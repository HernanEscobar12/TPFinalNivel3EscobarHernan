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
    public partial class Default2 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Carga de cards
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.ListarArticulo();
                    Session.Add("ListaArticulos", ListaArticulos);
                    IdRepeater.DataSource = Session["ListaArticulos"];
                    IdRepeater.DataBind();
                }


                ////Boton administrador
                //if (Seguridad.administradorSesionActiva(Session["usuarioActivo"]) == true)
                //    btnAdinistrador.Visible = true;
                //else
                //    btnAdinistrador.Visible = false;

            }
            catch (Exception ex)
            {

                Session.Add("Error", "Hubo Error en pantalla" + ex);
                Response.Redirect("Error.aspx", false);
            }


        }


        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((Button)sender).CommandArgument;
                Response.Redirect("Detalles.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Hubo un Erorr en 'Detalles '" + ex);
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void Filtro(object sender, ImageClickEventArgs e)
        {
            string filtro = ((ImageButton)sender).CommandArgument;
            List<Articulo> Lista = (List<Articulo>)Session["ListaArticulos"];
            List<Articulo> ListaFiltrada = Lista.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            IdRepeater.DataSource = ListaFiltrada;
            IdRepeater.DataBind();
        }

       
    }
    
}