using System;
using System.Windows;
using System.Windows.Input;
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Verifica si se presionó la tecla Enter
            {
                OnContinuarClick(sender, null);
            }
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

                    // Cargar la imagen usando la ruta relativa con pack URI
                    Uri imageUri = new Uri($"pack://application:,,,/{profileImagePath}", UriKind.Absolute);
                    imgPerfil.Source = new BitmapImage(imageUri);
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
        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí puede observar los datos del usuario.\n" +
                "Para acceder al acceder al sistema, haga click en continuar." , "Ayuda Ventana Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

