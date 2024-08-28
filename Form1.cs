using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaClase_CLASE_PARAMETRIZADA_
{
    public partial class Form1 : Form
    {
        //CREACION DE LISTAS 
        int x;
        List<Producto<int>> ListaAbarrotes = new List<Producto<int>>();
        List<Producto<double>> ListaDeFrutas = new List<Producto<double>>();
        //instancias
        Producto<int> miProductoEntero = new Producto<int>();
        Producto<double> miProductoDoble = new Producto<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {

            //TRY CATCH QUE VALIDA TODOS LOS TEXBOX PARA QUE ESTEN LLENOS Y NO VACIOS
            try
            {
                bool dblEspacioVacio = false;

                foreach (Control C in gpoProducto.Controls)
                {
                    if (C is TextBox)
                    {
                        if (C.Text == "")
                        {
                            dblEspacioVacio = true;
                        }
                    }
                }

                if (dblEspacioVacio == false)
                {
                    //VARIABLES LOCALES QUE ALMACENARAN LOS DATOS DE LOS TEXBOX
                    int Clave = Convert.ToInt32(txtClave.Text);
                    string Descripcion = txtDescripcion.Text;
                    string Departamento = cboDepartamento.SelectedItem.ToString();
                    int indice = cboDepartamento.SelectedIndex;
                    //if que valida el tipo de producto para despues poder almacenar el punto de reorden
                    if (indice == 1)
                    {
                        miProductoDoble.PuntoReorden = Convert.ToDouble(txtPuntoReorden.Text);
                        //creo un nuevo producto con la informacion capturada
                        miProductoDoble = new Producto<double>(Clave, Descripcion, Departamento, miProductoDoble.PuntoReorden);
                        //se agrega el objeto a la lista
                        ListaDeFrutas.Add(miProductoDoble);

                        //agrego los datos al datagrid
                        dtgProductos.Rows.Add(miProductoDoble.Clave, miProductoDoble.Descripcion, miProductoDoble.Departamento, miProductoDoble.PuntoReorden);


                        //limpio los texbox
                        dtgProductos.ClearSelection();
                        txtClave.Clear();
                        txtDescripcion.Clear();
                        txtPuntoReorden.Clear();
                        cboDepartamento.SelectedIndex = -1;
                    }
                    else
                    {
                        miProductoEntero.PuntoReorden = Convert.ToInt32(txtPuntoReorden.Text);
                        //creo un nuevo producto con la informacion capturada
                        miProductoEntero = new Producto<int>(Clave, Descripcion, Departamento, miProductoEntero.PuntoReorden);
                        //se agrega el objeto a la lista
                        ListaAbarrotes.Add(miProductoEntero);

                        //agrego los datos al datagrid
                        dtgProductos.Rows.Add(miProductoEntero.Clave, miProductoEntero.Descripcion, miProductoEntero.Departamento, miProductoEntero.PuntoReorden);
                        //limpio los texbox
                     
                        txtClave.Clear();
                        txtDescripcion.Clear();
                        txtPuntoReorden.Clear();
                        cboDepartamento.SelectedIndex = -1;
                    }
                }

            }
            catch (OverflowException ex)//CATCH QUE HACE QUE NO SE DESBORDE LA VARIABLE TIPO INT
            {
                MessageBox.Show("INGRESO UN VALOR MUY GRANDE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex) //CATCH QUE HACE QUE NO SE CAPTUREN MAL LOS TIPOS DE DATOS
            {
                MessageBox.Show("CAPTURO TECLAS QUE NO CORRESPONDEN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIO UN ERROR" + ex.Message, "ERROR GENERAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPuntoReorden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

