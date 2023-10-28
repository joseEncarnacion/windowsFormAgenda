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
    public class Entidad
    {
        public int idPersona { get; set; }
        public string nom { get; set; }
        public string Apellido { get; set; }
        public string nacimiento { get; set; }
        public string dir { get; set; }
        public string generoid { get; set; }
        public string estadoCivil { get; set; }
        public string movil { get; set; }
        public string tell { get; set; }
        public string correo { get; set; }

    }



    public class CapaDato
    {
        // conexion de la base de datos

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

      
        //Probar la conexion de la db
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

        // 

        public DataTable ListarContacto()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void CrearContacto(Entidad arg)
        {
            SqlCommand cmd = new SqlCommand("sp_crear", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", arg.nom);
            cmd.Parameters.AddWithValue("@apell", arg.Apellido);
            cmd.Parameters.AddWithValue("@nac", arg.nacimiento);
            cmd.Parameters.AddWithValue("@dir", arg.dir);
            cmd.Parameters.AddWithValue("@genero", arg.generoid);
            cmd.Parameters.AddWithValue("@ecivil", arg.estadoCivil);
            cmd.Parameters.AddWithValue("@movil", arg.movil);
            cmd.Parameters.AddWithValue("@tell", arg.tell);
            cmd.Parameters.AddWithValue("@correo", arg.correo);
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarPorIdPersona", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPer", id);
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Actualizar(Entidad arg)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarPorIdPersona", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idper", arg.idPersona);
            cmd.Parameters.AddWithValue("@nom", arg.nom);
            cmd.Parameters.AddWithValue("@apell", arg.Apellido);
            cmd.Parameters.AddWithValue("@nac", arg.nacimiento);
            cmd.Parameters.AddWithValue("@dir", arg.dir);
            cmd.Parameters.AddWithValue("@genero", arg.generoid);
            cmd.Parameters.AddWithValue("@ecivil", arg.estadoCivil);
            cmd.Parameters.AddWithValue("@movil", arg.movil);
            cmd.Parameters.AddWithValue("@tell", arg.tell);
            cmd.Parameters.AddWithValue("@correo", arg.correo);
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
