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

            // Check for at least one uppercase letter
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                mayusCheck.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                mayusCheck.Foreground = new SolidColorBrush(Colors.Gray);
            }

            // Check for at least one number
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
            if (mayusCheck.Foreground.ToString() == new SolidColorBrush(Colors.Green).ToString() &&
                numeroCheck.Foreground.ToString() == new SolidColorBrush(Colors.Green).ToString())
            {
                MessageBox.Show("¡La contraseña cumple con los criterios!");
            }
            else
            {
                MessageBox.Show("La contraseña debe cumplir con los criterios.");
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
