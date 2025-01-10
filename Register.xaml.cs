using System;
using System.Data.SqlClient;
using System.Windows;

namespace ProyectoWPF
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text.Trim();
            string contrasena = PasswordBox.Password.Trim();
            string confirmContrasena = ConfirmPasswordBox.Password.Trim();

            if (usuario == "" || contrasena == "" || confirmContrasena == "")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (contrasena != confirmContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True;";
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                // Verificar si el usuario ya existe
                string consultaUsuario = "SELECT COUNT(*) FROM Login WHERE Usuario = @Usuario";
                SqlCommand comandoUsuario = new SqlCommand(consultaUsuario, conexion);
                comandoUsuario.Parameters.AddWithValue("@Usuario", usuario);
                int usuarioExistente = Convert.ToInt32(comandoUsuario.ExecuteScalar());

                if (usuarioExistente > 0)
                {
                    MessageBox.Show("Este usuario ya está registrado.");
                }
                else
                {
                    // Insertar el nuevo usuario
                    string consulta = "INSERT INTO Login (Usuario, Contrasena) VALUES (@Usuario, @Contrasena)";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contrasena", contrasena);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        MessageBox.Show("Registro exitoso.");
                        // Después del registro exitoso, puedes redirigir al Home o a otra página
                        Home ventanaHome = new Home();
                        ventanaHome.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en el registro. Intenta nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos. Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        // Evento que se dispara cuando se hace clic en el texto "Ya tengo cuenta"
        private void YaTengoCuenta_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Abrir la ventana de login
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
