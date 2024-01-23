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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Seguridad.SesionActiva(Session["UsuarioActivo"]))
                {
                    User Usuario = (User)Session["UsuarioActivo"];
                    FavoritoNegocio FavoritoNegocio = new FavoritoNegocio();
                    IdRepeater.DataSource = FavoritoNegocio.ListarFavoritos(Usuario.Id);
                    IdRepeater.DataBind();
                }
                else
                    Response.Redirect("Login.aspx", false);
            }
        }
    }
}