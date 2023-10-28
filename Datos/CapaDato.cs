using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Datos
{
    public class CapaDato
    {
        // conexion de la base de datos

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

      

        public void probarConenexion()
        {
            try
            {
                conn.Open();
                MessageBox.Show("conectados");
            }
            catch (Exception ex)
            {
                throw(ex);
                
            }finally { conn.Close(); }
        }



        public DataTable ListarConexion()
        {
            SqlCommand cmd = new SqlCommand("sp_Listar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void CrearContacto()
        {
            
        }

        public void Eliminar()
        {

        }

        public void Actualizar()
        {

        }
    }
}
