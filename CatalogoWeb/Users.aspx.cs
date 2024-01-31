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
    public partial class Users : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
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
                    UserNegocio negocio = new UserNegocio();
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                    if (id != "")
                    {
                        User Usuario = negocio.BuscarUser(id)[0];
                        Session.Add("UserSeleccionado", Usuario);
                        txtEmail.Text = Usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtApellido.Text = Usuario.Apellido;
                        txtNombre.Text = Usuario.Nombre;
                        if (!string.IsNullOrEmpty(Usuario.ImagePerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "../Image/Profile/" + Usuario.ImagePerfil;
                        }
                    }

                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            if (chkConfirmaEliminacion.Checked)
            {
                try
                {
                    UserNegocio Negocio = new UserNegocio();
                    User UsuarioSeleccionado = (User)Session["UserSeleccionado"];
                    Negocio.Eliminar(UsuarioSeleccionado.Id);
                    Response.Redirect("Administrador.aspx", false);

                }
                catch (Exception ex)
                {

                    Session.Add("Error", "Error al Eliminar @Users " + ex);
                    Response.Redirect("Error.aspx", false);

                }
            }
        }
    }
}