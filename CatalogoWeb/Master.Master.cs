using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CatalogoWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_960_720.png";
            if(!(Page is Login || Page is Registro || Page is Error || Page is Detalles|| Page is Default2 || Page is ListaArticulo))
            {
                if (!(Seguridad.SesionActiva(Session["UsuarioActivo"])))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    User Usuario = new User();
                    Usuario = (User)Session["UsuarioActivo"];
                    lblUser.Text = Usuario.Nombre;
                    if (!string.IsNullOrEmpty(Usuario.ImagePerfil))
                        imgAvatar.ImageUrl = "../Image/Profile/" + Usuario.ImagePerfil;
                }
            }
            else if((Seguridad.SesionActiva(Session["UsuarioActivo"]))) {
                User Usuario = new User();
                Usuario = (User)Session["UsuarioActivo"];
                lblUser.Text = Usuario.Nombre;
                if (!string.IsNullOrEmpty(Usuario.ImagePerfil))
                    imgAvatar.ImageUrl = "../Image/Profile/" + Usuario.ImagePerfil;

            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }

        protected void PanelDeControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx", false);
        }
    }
}