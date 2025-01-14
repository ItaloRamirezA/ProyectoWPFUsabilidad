using System.Windows;

namespace ProyectoWPF
{
    public partial class Error : Window
    {
        public Error()
        {
            InitializeComponent();
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
