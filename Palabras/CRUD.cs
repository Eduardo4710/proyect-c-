using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palabras
{

    class CRUD


    {
        string directorio = Directory.GetCurrentDirectory();
        ArrayList registro;
        DataGridView tabla;
        TextBox txt_ingles;
        TextBox txt_traduccion;
        TextBox txt_buscar;
        TextBox txt_buscar2;
        Label lbl_Numero;



        public CRUD(DataGridView DgvDatos, TextBox txtIngle, TextBox txtTraduccio, TextBox txtBuscar, TextBox txtBuscar2, Label lblNumero)
        {
            tabla = DgvDatos;
            txt_ingles = txtIngle;
            txt_traduccion = txtTraduccio;
            txt_buscar = txtBuscar;
            txt_buscar2 = txtBuscar2;
            lbl_Numero = lblNumero;


        }

        public void SelectDates()
        {
            StreamReader datosLectura = new StreamReader(directorio + "\\Registro.txt");
            string filas = "";
            string[] informacion;
            int contador = 0;

            tabla.Rows.Clear();
            do
            {
                filas = datosLectura.ReadLine();
                if (filas != null)
                {
                    informacion = filas.Split(';');
                    tabla.Rows.Insert(contador, informacion[0], informacion[1]);

                }
                contador++;

            } while (filas != null);

            datosLectura.Close();

        }

        /* public void InsertDates(string dates)
         {

             StreamWriter datosEscritura = new StreamWriter(directorio + "\\Registro.txt", true);
             datosEscritura.WriteLine(dates);
             MessageBox.Show("Registro guardado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
             datosEscritura.Close();
         }*/

        public void UpdateDates(string clave, string nuevoRegistro)
        {
            RemoveDates(clave);
            registro.Add(nuevoRegistro);
            InsertionDates();
            MessageBox.Show("Registro actualizado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        public void DeleteDates(string clave)
        {
            RemoveDates(clave);
            InsertionDates();

        }
        public bool NoNull()
        {
            bool todoOK = true;
            if (txt_ingles.Text.Equals(""))
            {
                todoOK = false;
            }
            else if (txt_traduccion.Text.Equals(""))
            {
                todoOK = false;
            }


            return todoOK;
        }
        public void EmptyElements()
        {
            txt_ingles.Text = "";
            txt_traduccion.Text = "";

        }

        public void SearchTerm() //Buscar palbras ingles
        {
            bool encontrar = false;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                if (((row.Cells[0].Value).ToString().ToLower()).Equals(txt_buscar.Text.ToLower()))
                {
                    encontrar = true;
                    row.Selected = true;
                    break;
                }

            }
            if (encontrar == false)
            {
                MessageBox.Show("Palabra no encontrada : (", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }
        //ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo
        public void Buscar2()//Buscar palabras Español
        {
            foreach (DataGridViewRow row in tabla.Rows)
            {
                if (((row.Cells[1].Value).ToString().ToLower()).Equals(txt_buscar2.Text.ToLower()))
                {
                    row.Selected = true;
                    break;
                }
            }

        }
        //ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo
        public void Contar()//conteo de palabras
        {
            lbl_Numero.Text = (tabla.Rows.Count.ToString()) + " Registros";
        }
        //ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo



        public void Search_Term_add(string dates) //Buscar palbras ingles
        {
            bool contrar = false;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                if (((row.Cells[0].Value).ToString().ToLower()).Equals(txt_ingles.Text.ToLower()))
                {

                    contrar = true;
                    MessageBox.Show("Palabra ya existente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            if (contrar == false)
            {
                StreamWriter datosEscritura = new StreamWriter(directorio + "\\Registro.txt", true);
                datosEscritura.WriteLine(dates);
                MessageBox.Show("Registro guardado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datosEscritura.Close();
            }




        }
        //ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo

        private void RemoveDates(string clave)
        {
            registro = new ArrayList();
            StreamReader datosLectura = new StreamReader(directorio + "\\Registro.txt");
            string filas = "";
            string[] informacion;
            do
            {
                filas = datosLectura.ReadLine();
                if (filas != null)
                {
                    informacion = filas.Split(';');
                    if (informacion[0] != clave)
                    {
                        registro.Add(filas);
                    }
                }
            } while (filas != null);
            datosLectura.Close();
        }
        private void InsertionDates()
        {
            StreamWriter datosEscritura = new StreamWriter(directorio + "\\Registro.txt");
            datosEscritura.Flush();

            foreach (string fila in registro)
            {
                datosEscritura.WriteLine(fila);
            }
            datosEscritura.Close();
        }

    }
}
