using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class User
    {
        public int Id { get; set; }
        private string email;
        public string Email
        {
            get { return email; }
            set 
            {
                if (value != "")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("Email Vacio en el dominio...");
                }
            
            }
           
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public string ImagePerfil { get; set; }
        public bool Admin { get; set; }








    }
}
