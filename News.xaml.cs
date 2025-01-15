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
using System.Windows.Shapes;

namespace ProyectoWPF
{
    /// <summary>
    /// Lógica de interacción para News.xaml
    /// </summary>
    public partial class News : Window
    {
        public News()
        {
            InitializeComponent();
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

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
