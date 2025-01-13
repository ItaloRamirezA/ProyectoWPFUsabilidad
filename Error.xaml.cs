using System.Windows;
using System.Windows.Controls;

namespace ProyectoWPF
{
    public partial class Error : Page
    {
        public Error()
        {
            InitializeComponent();
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No se puede regresar a la página anterior.");
            }
        }
    }
}
