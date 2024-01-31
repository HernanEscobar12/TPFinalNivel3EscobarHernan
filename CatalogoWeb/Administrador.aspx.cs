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
    public partial class Administrador : System.Web.UI.Page
    {
        public List<User> Users { get; set; }
        public List<Articulo> Articulos { get; set; }
        public bool MenuUsuarios { get; set; } = false;
        public bool MenuMarca { get; set; } = false;
        public bool MenuArticulo { get; set; } = false;

        public bool MenuCategoria { get; set; } = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["UsuarioActivo"]))
            {
                Session.Add("Error", "!!Acceso Denegado¡¡ *DEBES SER ADMIN* ");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {

                    // Users Grid
                    UserNegocio UserNegocio = new UserNegocio();
                    Session.Add("ListaUser", Users = UserNegocio.ListaUsuario());
                    dgvUsuarios.DataSource = Users;
                    dgvUsuarios.DataBind();

                    // Marcas Grid
                    MarcaNegocio MarcaNegocio = new MarcaNegocio();
                    Session.Add("ListasMarcas", MarcaNegocio.Listar());
                    dgvMarcas.DataSource = Session["ListasMarcas"];
                    dgvMarcas.DataBind();

                    // Categorias Grid
                    CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
                    Session.Add("ListaCategorias", CategoriaNegocio.Listar());
                    dgvCategorias.DataSource = Session["ListaCategorias"];
                    dgvCategorias.DataBind();

                    //Articulos
                    ArticuloNegocio ArticuloNegocio = new ArticuloNegocio();
                    Session.Add("ListaArticulos", Articulos = ArticuloNegocio.ListarArticulo());
                    dgvArticulos.DataSource = Articulos;
                    dgvArticulos.DataBind();
                }
                else
                {
                    dgvUsuarios.DataSource = Session["ListaUser"];
                    dgvUsuarios.DataBind();
                    dgvArticulos.DataSource = Session["ListaArticulos"];
                    dgvArticulos.DataBind();
                }
            }



        }

        protected void GridView_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            ((GridView)(sender)).PageIndex = e.NewPageIndex;
            ((GridView)(sender)).DataBind();

        }

        protected void ChkUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            MenuUsuarios = ChkUsuarios.Checked;
        }

        protected void ChkMarcas_CheckedChanged(object sender, EventArgs e)
        {
            MenuMarca = ChkMarcas.Checked;
        }

        protected void ChkArticulos_CheckedChanged(object sender, EventArgs e)
        {
            MenuArticulo = ChkArticulos.Checked;
        }

        protected void ChkCategorias_CheckedChanged(object sender, EventArgs e)
        {
            MenuCategoria = ChkCategorias.Checked;
        }


        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id, false);
        }


        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("Users.aspx?id=" + id, false);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx", false);
        }
    }
}