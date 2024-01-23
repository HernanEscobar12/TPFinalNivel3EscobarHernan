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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioActivo"] != null)
                {
                    User Usuario = (User)Session["UsuarioActivo"];
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UserNegocio Negocio = new UserNegocio();
                User Usuario = (User)(Session["UsuarioActivo"]);

                //Escrbir img

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Image/Profile/");
                    txtImagen.PostedFile.SaveAs(ruta + "Perfil" + Usuario.Id + ".jpg");
                    Usuario.ImagePerfil = "Perfil" + Usuario.Id + ".jpg";
                }         
                
                Usuario.Nombre = txtNombre.Text;
                Usuario.Apellido = txtApellido.Text;
                Negocio.Update(Usuario);

                //Leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "../Image/Profile/" + Usuario.ImagePerfil;
                Response.Redirect("MiPerfil.aspx", false);


            }
            catch (Exception ex )
            {
                Session.Add("Error", "Hubo un error en mi perfil" + ex);
                Response.Redirect("Error.aspx", false);
                
            }


        }


    }
}