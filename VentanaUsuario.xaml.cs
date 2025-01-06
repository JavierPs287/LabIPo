using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoIPo
{
    public partial class VentanaUsuario : Window
    {
        private string username;
        private string profileImagePath;
        private DateTime lastAccessDate;

        public VentanaUsuario(string username, string profileImagePath, DateTime lastAccessDate)
        {
            InitializeComponent();
            this.username = username;
            this.profileImagePath = profileImagePath;
            this.lastAccessDate = lastAccessDate;
            MostrarDatosUsuario();
        }

        private void MostrarDatosUsuario()
        {
            txtNombreUsuario.Text = $"Usuario: {username}";
            txtUltimoAcceso.Text = $"Último acceso: {lastAccessDate}";

            if (!string.IsNullOrEmpty(profileImagePath))
            {
                try
                {
                    // Mensaje de depuración para verificar la ruta de la imagen
                    Console.WriteLine($"Cargando imagen desde: {profileImagePath}");
                    imgPerfil.Source = new BitmapImage(new Uri(profileImagePath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OnContinuarClick(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal(username, profileImagePath, lastAccessDate);
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}

