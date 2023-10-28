using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //variables 
        bool existe = false;

        CapaDato cd= new CapaDato();
        Entidad ce = new Entidad();


        //Metodo para limpiar los campos de los inputs
       /* void limpiar()
        {
            textNombre.Text = string.Empty;
            textApellidos.Text = string.Empty;
            textDireccion.Text = string.Empty;
            Cbox_genero.Text = string.Empty;
            cbox_Ecivil.Text = string.Empty;
            textMovil.Text = string.Empty;
            textTelefono.Text = string.Empty;
            textEmail.Text = string.Empty;

        }*/


        public void listarDatos()
        {
            DataTable dt = cd.ListarContacto();
            dataGRegistro.DataSource = dt;
            MessageBox.Show("Que pasa");

        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            cd.probarConenexion();
        }
        //aqui es la pantalla para visualizar
        private void dataGRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             MessageBox.Show("Que pasa"); listarDatos();
        }
    }
}
