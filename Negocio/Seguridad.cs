using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Seguridad
    {

        public static bool SesionActiva(object user)
        {
            User Usuario = user != null ? (User)user : null;
            if (Usuario != null && Usuario.Id != 0)
                return true;
            else
                return false;
        }

        public static bool EsAdmin(object user)
        {
            User Usuario = user != null ? (User)user : null;
            return Usuario != null ? Usuario.Admin : false;
        }


    }
}
