﻿using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media;

namespace ProyectoWPF
{
    public partial class Home : Window
    {
        private int segundosRestantes;
        private Timer temporizador;

        public Home()
        {
            InitializeComponent();

            segundosRestantes = 43200;
            temporizador = new Timer(ActualizarTemporizador, null, 0, 1000);
        }

        private void ActualizarTemporizador(object state)
        {
            if (segundosRestantes > 0)
            {
                segundosRestantes--;
                TimeSpan tiempo = TimeSpan.FromSeconds(segundosRestantes);
                Dispatcher.Invoke(() => {
                    TemporizadorText.Text = tiempo.ToString(@"hh\:mm\:ss");
                });
            }
            else
            {
                Dispatcher.Invoke(() => {
                    TemporizadorText.Text = "Offers expired!";
                    TemporizadorText.Foreground = new SolidColorBrush(Colors.Gray);
                });
                temporizador.Dispose();
            }
        }

        private void ProductoButton_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            if (boton != null)
            {
                int idProducto = Convert.ToInt32(boton.Tag);
                Producto producto = ObtenerProducto(idProducto);
                if (producto != null)
                {
                    InformacionProducto ventana = new InformacionProducto(producto);
                    this.Close();
                    ventana.Show();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto.");
                }
            }
        }

        private Producto ObtenerProducto(int id)
        {
            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True";
            string consulta = "SELECT * FROM Productos WHERE Id = @Id";
            Producto producto = null;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                producto = new Producto
                {
                    Id = Convert.ToInt32(lector["Id"]),
                    Nombre = lector["Nombre"].ToString(),
                    Tamano = Convert.ToInt32(lector["Tamano"]),
                    Descripcion = lector["Descripcion"].ToString(),
                    Precio = Convert.ToSingle(lector["Precio"]),
                    ImagenPath = lector["ImagenPath"].ToString()
                };
            }

            lector.Close();
            conexion.Close();

            return producto;
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Checkout");
        }

        private void AbrirVentanaHome(object sender, RoutedEventArgs e)
        {
            Home ventanaHome = new Home();
            ventanaHome.Show();
            this.Close();
        }

        private void AbrirVentanaError(object sender, RoutedEventArgs e)
        {
            Error ventanaError = new Error();
            ventanaError.Show();
            this.Close();
        }

        private void AbrirVentanaNews(object sender, RoutedEventArgs e)
        {
            News ventantaNews = new News();
            ventantaNews.Show();
            this.Close();
        }


    }
}
