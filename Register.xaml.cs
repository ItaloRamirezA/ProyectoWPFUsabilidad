using System.Data.SqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(confirmContrasena))
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
                MessageBox.Show("La contraseña debe tener 5 o más caracteres.");
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
                        Window ventanaBienvenida = new Window
                        {
                            Title = "¡Registro exitoso!",
                            Width = 500,
                            Height = 300,
                            ResizeMode = ResizeMode.NoResize,
                            WindowStartupLocation = WindowStartupLocation.CenterScreen,
                            Background = Brushes.White
                        };

                        StackPanel stackPanel = new StackPanel
                        {
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(10)
                        };

                        TextBlock textoBienvenida = new TextBlock
                        {
                            Text = "¡Te has registrado exitosamente!",
                            FontSize = 20,
                            FontWeight = FontWeights.Bold,
                            Foreground = new SolidColorBrush(Color.FromRgb(107, 108, 195)),
                            TextAlignment = TextAlignment.Center,
                            Margin = new Thickness(10)
                        };

                        Image imagenBienvenida = new Image
                        {
                            Source = new BitmapImage(new Uri("pack://application:,,,/Imagenes/Comun/bienvenido.png")),
                            Width = 150,
                            Height = 150,
                            Margin = new Thickness(10)
                        };

                        Button botonCerrar = new Button
                        {
                            Content = "Aceptar",
                            Width = 100,
                            Height = 30,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(10)
                        };
                        botonCerrar.Click += (s, ev) => { ventanaBienvenida.Close(); };

                        stackPanel.Children.Add(textoBienvenida);
                        stackPanel.Children.Add(imagenBienvenida);
                        stackPanel.Children.Add(botonCerrar);

                        ventanaBienvenida.Content = stackPanel;
                        ventanaBienvenida.ShowDialog();

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
