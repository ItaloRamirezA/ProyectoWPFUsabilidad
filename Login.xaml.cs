using System;
using System.Data.SqlClient;
using System.Windows;

namespace ProyectoWPF
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text.Trim();
            string contrasena = PasswordBox.Password.Trim();

            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True;";
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Login WHERE Usuario = @Usuario AND Contrasena = @Contrasena";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);

                int resultado = Convert.ToInt32(comando.ExecuteScalar());

                if (resultado == 1)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    Home ventanaHome = new Home();
                    ventanaHome.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch
            {
                MessageBox.Show("No se pudo conectar con la base de datos.");
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
