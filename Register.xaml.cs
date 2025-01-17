using System.Data.SqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProyectoWPF
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ContrasenaCambio(object sender, RoutedEventArgs e)
        {
            string password = ContrasenaBox.Password;

            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                mayusCheck.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                mayusCheck.Foreground = new SolidColorBrush(Colors.Gray);
            }

            if (Regex.IsMatch(password, @"\d"))
            {
                numeroCheck.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                numeroCheck.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text.Trim();
            string contrasena = ContrasenaBox.Password.Trim();
            string confirmContrasena = ConfirmarContraBox.Password.Trim();

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

            if (contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener 5 o mas caracteres.");
                return;
            }

            if (!Regex.IsMatch(contrasena, @"[A-Z]"))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra mayúscula.");
                return;
            }

            if (!Regex.IsMatch(contrasena, @"\d"))
            {
                MessageBox.Show("La contraseña debe contener al menos un número.");
                return;
            }

            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True;";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

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
                    string consulta = "INSERT INTO Login (Usuario, Contrasena) VALUES (@Usuario, @Contrasena)";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contrasena", contrasena);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        MessageBox.Show("Registro exitoso.");
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

        private void YaTengoCuenta_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
