using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;

namespace Crud
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void frmPeliculas_Load(object sender, EventArgs e)
        {
            MostrarPeliculas();
        }

        private void MostrarPeliculas()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = Peliculas.CargarPeliculas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre =txtNombre.Text;
            p.FechaLanzamiento =dtpFecha.Value;
            p.Director =txtDirector.Text;
            p.InsertarPeliculas();
            MostrarPeliculas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());
            
            Peliculas p = new Peliculas();
            if (p.EliminarPeliculas(id) == true)
            {
                MessageBox.Show("Registro eliminado con satisfaccion", "Exito");
                MostrarPeliculas(); 
                    
            }
            else 
            {
                MessageBox.Show("Se produjo un herror","!!Advertencia!!");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre = txtNombre.Text;
            p.Director = txtDirector.Text;
            p. FechaLanzamiento = dtpFecha.Value;
            p.Id= int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());

            if (p.ActualizarPelicula() == true)
            {
                MostrarPeliculas();
            }
            else{

                MessageBox.Show("El registro no pudo ser aztualizado \n Advertencia!! ]");
             
            }

           
        }

        private void dgvPeliculas_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            txtDirector.Text = dgvPeliculas.CurrentRow.Cells [2].Value.ToString();
            dtpFecha.Value = DateTime.Parse(dgvPeliculas.CurrentRow.Cells[3].Value.ToString());
        }

    }
}
