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
    public partial class Login : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] != null)
            {
                User Usuario = (User)Session["UsuarioActivo"];
                txtEmail.Text = Usuario.Email;
                txtEmail.ReadOnly = true;
                txtPass.Text = Usuario.Pass;
                txtPass.ReadOnly = true;
                btnIngresar.Enabled = false;

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
                UserNegocio UserNegocio = new UserNegocio();
                User Usuario = new User();
            try
            {

                if(Validacion.ValidacionTextoVacio(txtEmail) || Validacion.ValidacionTextoVacio(txtPass))
                {
                    Session.Add("Error", "Debes Completar Todos los campos...");
                    Response.Redirect("Error.aspx");
                }

                Usuario.Email = txtEmail.Text;
                Usuario.Pass = txtPass.Text;
                UserNegocio.Login(Usuario);
                Session.Add("UsuarioActivo", Usuario);

                if ((Session["UsuarioActivo"] != null))
                {
                    Session.Add("UsuarioActivo", Usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Email y/o Contraseña Incorrectos");
                    Response.Redirect("Error.aspx", false);
                }


            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex )
            {

                Session.Add("Error" , ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}