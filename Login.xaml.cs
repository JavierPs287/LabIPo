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
using System.Windows.Shapes;

namespace ProyectoIPo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        // Manejo del foco para el cuadro de texto "Usuario"
        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            lblUsuario.Visibility = Visibility.Collapsed; // Oculta "Usuario" al ganar foco
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                lblUsuario.Visibility = Visibility.Visible; // Muestra "Usuario" si está vacío
            }
        }

        // Manejo del foco para el cuadro de texto "Contraseña"
        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            lblPassword.Visibility = Visibility.Collapsed; // Oculta "Contraseña" al ganar foco
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                lblPassword.Visibility = Visibility.Visible; // Muestra "Contraseña" si está vacío
            }
        }

        // Evento del botón Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtPassword.Password;

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("¡Login exitoso!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                ventanaPrincipal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
