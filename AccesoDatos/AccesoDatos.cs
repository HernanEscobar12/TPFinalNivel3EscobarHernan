using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;

        private SqlCommand Cmd;

        private SqlDataReader Read;

        public SqlDataReader Reader { get { return Read; } }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("server= .\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            Cmd = new SqlCommand();
        }

        public void SetConsulta(string Query)
        {
            Cmd.CommandType = System.Data.CommandType.Text;
            Cmd.CommandText = Query;
        }

        public void SetearParametro(string nombre, object valor)
        {
            Cmd.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarLectura()
        {   
            try
            {
                Cmd.Connection = Conexion;
                Conexion.Open();
                Read = Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjecutarAccion() 
        {
            Cmd.Connection = Conexion;
            try
            {
                Conexion.Open();
                Cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (Read != null)
            {
                Read.Close();
                Conexion?.Close();         
            }
        }

    }
}
