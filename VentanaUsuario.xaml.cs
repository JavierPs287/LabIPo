using System;
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
        private void modificar_click(object sender, RoutedEventArgs e)
        {
            txtNombreUsuario.IsReadOnly = false;
            txtNombre.IsReadOnly = false;
            txtApellidos.IsReadOnly = false;
            CorreoElectronico.IsReadOnly = false;
            UltimoAcceso.IsReadOnly = false;

            DatosApp.Usuarios[username].NombreUsuario = txtNombreUsuario.Text;
            DatosApp.Usuarios[username].Nombre = txtNombre.Text;
            DatosApp.Usuarios[username].Apellidos = txtApellidos.Text;
            DatosApp.Usuarios[username].Correo = CorreoElectronico.Text;
            DatosApp.Usuarios[username].Contraseña = txtContraseña.Text;
            DatosApp.Usuarios[username].FechaUltimoAcceso = DateTime.Now; // Actualiza la fecha de último acceso


            if (DatosApp.Usuarios[username].NombreUsuario != txtNombreUsuario.Text ||
                DatosApp.Usuarios[username].Nombre != txtNombre.Text ||
                DatosApp.Usuarios[username].Apellidos != txtApellidos.Text ||
                DatosApp.Usuarios[username].Correo != CorreoElectronico.Text ||
                DatosApp.Usuarios[username].Contraseña != txtContraseña.Text)
            {
                DatosApp.Usuarios.Remove(username); // Elimina el usuario anterior
                DatosApp.Usuarios.Add(txtNombreUsuario.Text, DatosApp.Usuarios[txtNombreUsuario.Text]); // Agrega el nuevo usuario
                DatosApp.Usuarios.Add(txtNombre.Text, DatosApp.Usuarios[txtNombre.Text]); // Actualiza el nombre de usuario
                DatosApp.Usuarios.Add(txtApellidos.Text, DatosApp.Usuarios[txtApellidos.Text]); // Actualiza el apellido
                DatosApp.Usuarios.Add(CorreoElectronico.Text, DatosApp.Usuarios[CorreoElectronico.Text]); // Actualiza el correo
                DatosApp.Usuarios.Add(txtContraseña.Text, DatosApp.Usuarios[txtContraseña.Text]); // Actualiza la contraseña
                DatosApp.Usuarios.Add(UltimoAcceso.Text, DatosApp.Usuarios[UltimoAcceso.Text]); // Actualiza la fecha de último acceso


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

