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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                User Usuario = new User();
                UserNegocio Negocio = new UserNegocio();
                EmailService EmailService = new EmailService();
                Usuario.Nombre = TxtNombre.Text;
                Usuario.Apellido = txtApellido.Text;
                Usuario.Email = txtEmail.Text;
                Usuario.Pass = txtPassword.Text;
                Negocio.InsertNew(Usuario);               
                Session.Add("UsuarioActivo", Usuario);
                EmailService.ArmarCorreo(Usuario.Email, "Bienvenida/o al ecommerce Web", "Te damos la bienvenida al ecommerce, Tu tienda Virtual");
                EmailService.EnviarEmail();

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception)
            {
                Session.Add("Error", "Hubo un Error al Registrarse Vuelva a intentar.");
                Response.Redirect("Error.aspx", false);
            }


        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx" , false);
        }
    }
}