using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
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
                    Window ventanaBienvenida = new Window
                    {
                        Title = "¡Bienvenido!",
                        Width = 400,
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
                        Text = "¡Bienvenido!",
                        FontSize = 24,
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
                    MessageBox.Show("Usuario o contraseña incorrectos.");
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

        private void NoTengoCuenta(object sender, RoutedEventArgs e)
        {
            Register ventanaRegister = new Register();
            ventanaRegister.Show();
            this.Close();
        }
    }
}
