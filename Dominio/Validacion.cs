using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Dominio
{
    public static class Validacion
    {
        public static bool ValidacionTextoVacio (Object Control)
        {
            if(Control is TextBox Texto)
            {
                if (string.IsNullOrEmpty(Texto.Text))
                    return true;
                else
                    return false;
            }

            return false;
        }





    }
}
