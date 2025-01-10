using System;
using System.Windows;

namespace ProyectoIPo
{
    public partial class IntroducirDatosAdmin : Window
    {
        public IntroducirDatosAdmin()
        {
            InitializeComponent();
            this.KeyDown += IntroducirDatosAdmin_KeyDown;
        }

        private void IntroducirDatosAdmin_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ComprobarDatosAdmin();
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ComprobarDatosAdmin();
        }

        private void ComprobarDatosAdmin()
        {
            string adminUsuario = txtAdminUsuario.Text;
            string adminPassword = txtAdminPassword.Password;

            if (adminUsuario == "admin" && adminPassword == "admin")
            {
                MessageBox.Show("Datos Correctos. Agregando Usuario", "¡Éxito!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
