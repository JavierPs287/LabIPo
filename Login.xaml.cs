using System;
using System.Windows;
using System.Windows.Input;

namespace ProyectoIPo
{
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

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e); // Llama al método de clic del botón
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e); // Llama al método de clic del botón
            }
        }

        // Evento del botón Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtPassword.Password;

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show($"Bienvenido {username}", "¡Login Exitoso!", MessageBoxButton.OK, MessageBoxImage.Information);

                // Datos del usuario autenticado
                string profileImagePath = "user-profile-icon-in-flat-style-member-avatar-illustration-on-isolated-background.jpg"; // Ruta de la imagen de perfil
                DateTime lastAccessDate = DateTime.Now;

                VentanaUsuario ventanaUsuario = new VentanaUsuario(username, profileImagePath, lastAccessDate);
                ventanaUsuario.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Registro fallido. Por favor, rellene todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show($"Bienvenido {username}", "¡Registro Exitoso!", MessageBoxButton.OK, MessageBoxImage.Information);

                // Datos del usuario registrado
                string profileImagePath = "recursos/user-profile-icon-in-flat-style-member-avatar-illustration-on-isolated-background.jpg"; // Ruta de la imagen de perfil
                DateTime lastAccessDate = DateTime.Now;

                VentanaUsuario ventanaUsuario = new VentanaUsuario(username, profileImagePath, lastAccessDate);
                ventanaUsuario.Show();
                this.Close();
            }
        }


    }
}


