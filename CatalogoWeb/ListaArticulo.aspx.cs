using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class ListaArticulo : System.Web.UI.Page
    {

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {          
            FiltroAvanzado = ChkAvanzado.Checked;
            if (!IsPostBack)
            {
                try
                {
                    ArticuloNegocio Negocio = new ArticuloNegocio();
                    Session.Add("ListaArticulo", Negocio.ListarArticulo());
                    dgvArticulos.DataSource = Session["ListaArticulo"];
                    dgvArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", "Hubo Un Error" + ex);
                    Response.Redirect("Error.aspx", false);

                }
            }
        }


        // Vista : 5 Art x Page
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> Lista = (List<Articulo>)Session["ListaArticulo"];
            List<Articulo> ListaFiltrada = Lista.FindAll(x => x.Nombre.ToUpper().Contains(TxtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = ListaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void ChkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = ChkAvanzado.Checked;
            TxtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx", false);
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                txtFiltroAvanzado.Enabled = false;
                ddlCriterio.Items.Add("Celulares");
                ddlCriterio.Items.Add("Televisores");
                ddlCriterio.Items.Add("Media");
                ddlCriterio.Items.Add("Audio");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }




        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!txtFiltroAvanzado.Enabled)
                {
                    List<Articulo> Lista = (List<Articulo>)Session["ListaArticulo"];
                    List<Articulo> Filtro = Lista.FindAll(x => x.Categoria.Descripcion.Contains(ddlCriterio.SelectedItem.ToString()));
                    dgvArticulos.DataSource = Filtro;
                    dgvArticulos.DataBind();
                }
                else
                {
                    ArticuloNegocio Negocio = new ArticuloNegocio();
                    dgvArticulos.DataSource = Negocio.Buscar(
                        ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(),
                        txtFiltroAvanzado.Text);
                    dgvArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Hubo un Error" + ex);
                Response.Redirect("Error.aspx", false);
                 
            }


        }
    }
}