using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ProyectoWPF
{
    public partial class InformacionProducto : Window
    {
        public InformacionProducto(Producto producto)
        {
            InitializeComponent();
            NombreProducto.Text = producto.Nombre;
            TamanoProducto.Text = $"{producto.Tamano} cm";
            DescripcionProducto.Text = producto.Descripcion;
            PrecioProducto.Text = $"${producto.Precio:F2}";

            ImagenProducto.Source = new BitmapImage(new Uri(producto.ImagenPath, UriKind.Relative));
        }
        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

