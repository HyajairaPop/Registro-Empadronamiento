using System.Data;
using System;
using System.Data.SqlClient;
using TSE;
using System.Data.Common;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TSE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarDatos();

        }

        private void GuardarDatos()
        {
            // Obtener los valores de los campos de entrada

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string FechaNa = txtFecha.Text;
            string dpi = txtDpi.Text;
            string depto = txtDepto.Text;
            string municipio = txtMunicipio.Text;
            string correo = txtCorreo.Text;

            txtNombre.Text = "";
            txtApellido.Text= "";
            txtFecha.Text ="";
            txtDpi.Text = "";
            txtDepto.Text="";
            txtMunicipio.Text ="";
            txtCorreo.Text ="";

            //Conexion a la Base de datos usando la clase Conexion

            string connectionString = Conexion.MiCadena();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //Crear una consulta para insertar datos

                string query = "INSERT INTO RegistroCiudadanos (nombre, apellido, dpi, fechadenacimiento, departamentoderesidencia, municipioderesidencia, correoelectronico) VALUES (@nombre, @apellido, @dpi, @fechadenacimiento, @departamentoderesidencia, @municipioderesidencia, @correoelectronico)";

                // Crear un comando SQL y asignar los parámetros

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@dpi", dpi);
                    command.Parameters.AddWithValue("@fechadenacimiento", FechaNa);
                    command.Parameters.AddWithValue("@departamentoderesidencia", depto);
                    command.Parameters.AddWithValue("@municipioderesidencia", municipio);
                    command.Parameters.AddWithValue("@correoelectronico", correo);

                    // Ejecutar Comando SQL

                    command.ExecuteNonQuery();
                }

                //CERRAR CONEXION
                connection.Close();

            }
            MessageBox.Show("Los Datos se han guardado correctamente");
        }

        private void MostrarDatos()
        {
            
            string connectionString = Conexion.MiCadena();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Crear una consulta SQL para obtener los datos de la tabla
                string query = "SELECT * FROM RegistroCiudadanos";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                //CERRAR LA CONEXION
                connection.Close();

            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = Conexion.MiCadena();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string cod = txtNombre.Text;
                string cadena = "delete from RegistroCiudadanos where codigo = " + cod;
                SqlCommand comando = new SqlCommand(cadena, connection);
                int nombre;
                nombre = comando.ExecuteNonQuery();
                if (nombre == 1)
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtFecha.Text = "";
                    txtDpi.Text = "";
                    txtDepto.Text = "";
                    txtMunicipio.Text = "";
                    txtCorreo.Text = "";
                                        
                    MessageBox.Show("Se borró el Registro");
                }
                else
                    MessageBox.Show("No existe registro ingresado");
                connection.Close();

                //button2.Enabled = false;
            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}