using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProyectoIPo
{
    public partial class VentanaUsuario : Window
    {
        private string username;
        private DateTime lastAccessDate;
        public VentanaUsuario(string username, DateTime lastAccessDate)
        {
            InitializeComponent();
            this.username = username;
            this.lastAccessDate = lastAccessDate;
            MostrarDatosUsuario();
        }



        private void MostrarDatosUsuario()
        {
            txtNombreUsuario.Text = DatosApp.Usuarios[username].NombreUsuario;
            txtNombre.Text = DatosApp.Usuarios[username].Nombre;
            txtApellidos.Text = DatosApp.Usuarios[username].Apellidos;
            CorreoElectronico.Text = DatosApp.Usuarios[username].Correo;
            UltimoAcceso.Text = lastAccessDate.ToString("dd/MM/yyyy HH:mm");
            txtContraseña.Text = DatosApp.Usuarios[username].Contraseña;

        }



        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí puede observar los datos del usuario.\n" +
                "Para acceder al acceder al sistema, haga click en continuar.", "Ayuda Ventana Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool enEdicion = false; // pon esto como campo de la clase

        private void modificar_click(object sender, RoutedEventArgs e)
        {
            // Usamos sender para acceder al botón
            var boton = sender as Button;

            if (!enEdicion)
            {
                // Activar edición
                txtNombreUsuario.IsReadOnly = false;
                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                CorreoElectronico.IsReadOnly = false;
                UltimoAcceso.IsReadOnly = false;

                if (boton != null)
                    boton.Content = "Guardar";
                enEdicion = true;
            }
            else
            {
                // GUARDAR cambios
                var usuarioActual = DatosApp.Usuarios[username];
                bool hayCambios =
                    usuarioActual.NombreUsuario != txtNombreUsuario.Text ||
                    usuarioActual.Nombre != txtNombre.Text ||
                    usuarioActual.Apellidos != txtApellidos.Text ||
                    usuarioActual.Correo != CorreoElectronico.Text ||
                    usuarioActual.Contraseña != txtContraseña.Text;

                if (!hayCambios)
                {
                    MessageBox.Show("No se han realizado cambios.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    usuarioActual.NombreUsuario = txtNombreUsuario.Text;
                    usuarioActual.Nombre = txtNombre.Text;
                    usuarioActual.Apellidos = txtApellidos.Text;
                    usuarioActual.Correo = CorreoElectronico.Text;
                    usuarioActual.Contraseña = txtContraseña.Text;
                    usuarioActual.FechaUltimoAcceso = DateTime.Now;

                    if (username != txtNombreUsuario.Text)
                    {
                        DatosApp.Usuarios.Remove(username);
                        DatosApp.Usuarios.Add(txtNombreUsuario.Text, usuarioActual);

                        // ACTUALIZA el username en la ventana principal si existe:
                        var principal = Application.Current.Windows.OfType<VentanaPrincipal>().FirstOrDefault();
                        if (principal != null)
                        {
                            principal.Username = txtNombreUsuario.Text;
                        }

                        username = txtNombreUsuario.Text;
                    }

                    MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // Desactivar edición
                txtNombreUsuario.IsReadOnly = true;
                txtNombre.IsReadOnly = true;
                txtApellidos.IsReadOnly = true;
                CorreoElectronico.IsReadOnly = true;
                UltimoAcceso.IsReadOnly = true;

                if (boton != null)
                    boton.Content = "Modificar";
                enEdicion = false;
            }
        }
        private bool contraseñaVisible = false; // Variable para saber el estado

        private void visualizarContraseña_click(object sender, RoutedEventArgs e)
        {
            if (!contraseñaVisible)
            {
                txtContraseña.IsReadOnly = false; // Permitir escribir si quieres
                txtContraseña.Foreground = Brushes.Black;
                contraseñaVisible = true;
            }
            else
            {
                txtContraseña.IsReadOnly = true; // Volver a solo lectura
                txtContraseña.Foreground = Brushes.Gray;
                contraseñaVisible = false;
            }
        }
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtNombre)
                    textBox.Text = "Nombre";
                else if (textBox == txtApellidos)
                    textBox.Text = "Apellidos";
                else if (textBox == UltimoAcceso)
                    textBox.Text = "Último Acceso";
                else if (textBox == CorreoElectronico)
                    textBox.Text = "Correo Electrónico";
                else if (textBox == txtNombreUsuario)
                    textBox.Text = "Nombre de Usuario";
                else if (textBox == txtContraseña)
                    textBox.Text = "Contraseña";

                textBox.Foreground = Brushes.Gray;
            }
        }


    }
}

