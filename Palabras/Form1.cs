using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palabras
{
    public partial class Form1 : Form
    {
        string clave = "";
        CRUD objProceso;

        public Form1()
        {
            InitializeComponent();
            objProceso = new CRUD(dgvRegistros,txtIngles,txtTraduccion,txtBuscar,txtBuscar2,lblNumero  );

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objProceso.SelectDates();
            objProceso.Contar();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (objProceso.NoNull())
            {
                if (clave == "")
                {
                    string nuevo_registro = "" + txtIngles.Text + ";" + txtTraduccion.Text;
                    objProceso.Search_Term_add(nuevo_registro);
                    objProceso.SelectDates();
                    objProceso.EmptyElements();
                    clave = "";



                }
                else
                {
                    MessageBox.Show("Registro existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No deje campos vacios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            objProceso.Contar();
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex >-1)){return ;}

          txtIngles.Text = dgvRegistros.Rows[e.RowIndex].Cells[0].Value.ToString();
          txtTraduccion.Text = dgvRegistros.Rows[e.RowIndex].Cells[1].Value.ToString();
          clave= dgvRegistros.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (clave != "")
            {
                string nuevo_registro = "" + txtIngles.Text + ";" + txtTraduccion.Text;
                objProceso.UpdateDates(clave, nuevo_registro);
                objProceso.SelectDates();
                objProceso.EmptyElements();
                clave = "";
            }
            else
            {
                MessageBox.Show("Registro existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (clave != "")
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta==DialogResult.Yes)
                {
                    objProceso.DeleteDates(clave);
                    objProceso.SelectDates();
                    objProceso.EmptyElements();
                    clave = "";
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            objProceso.Contar();

        }

        private void btnBuscar_Click_2(object sender, EventArgs e)
        {
            objProceso.SearchTerm();//0000
            
          
        }

       

        private void lblNumero_Click(object sender, EventArgs e)
        {

            objProceso.Contar();

        }

        private void btnBuscar2_Click_1(object sender, EventArgs e)
        {
            objProceso.Buscar2();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clave != "")
            {

                objProceso.SelectDates();
                objProceso.EmptyElements();
                clave = "";
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          this.WindowState   =FormWindowState.Minimized ;
        }
    }
    
}
