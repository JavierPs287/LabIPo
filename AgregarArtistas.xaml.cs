using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace ProyectoIPo
{
    public partial class AgregarArtistas : Window
    {
        public Artista NuevoArtista { get; private set; }

        public AgregarArtistas()
        {
            InitializeComponent();
        }

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;

                switch (textBox.Name)
                {
                    case "txtNombreArtista":
                        textBox.Text = "Nombre del artista";
                        break;
                    case "txtGeneroMusical":
                        textBox.Text = "Género Musical";
                        break;
                    case "txtDatosPersonales":
                        textBox.Text = "Datos Personales";
                        break;
                    case "txtCorreoElectronico":
                        textBox.Text = "Correo Electrónico";
                        break;
                    case "txtRedesSociales":
                        textBox.Text = "Redes Sociales";
                        break;
                    case "txtCache":
                        textBox.Text = "Caché";
                        break;
                    case "txtLugarAlojamiento":
                        textBox.Text = "Lugar de Alojamiento";
                        break;
                    case "txtPeticionEspecial":
                        textBox.Text = "Petición Especial";
                        break;
                }
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreArtista.Text) || txtNombreArtista.Text == "Nombre del artista")
            {
                MessageBox.Show("El nombre del artista es obligatorio.", "Error");
                return; // Salir del método si la condición es verdadera
            }
            else if (string.IsNullOrWhiteSpace(txtGeneroMusical.Text) || txtGeneroMusical.Text == "Género Musical")
            {
                MessageBox.Show("El género musical es obligatorio.", "Error");
                return; // Salir del método si la condición es verdadera
            }
            // Crear el objeto NuevoArtista solo si las validaciones son correctas
            else
            {
                // Convertir campos opcionales o "placeholders" a null si corresponden
                string datosPersonales = string.IsNullOrWhiteSpace(txtDatosPersonales.Text) || txtDatosPersonales.Text == "Datos Personales" ? null : txtDatosPersonales.Text;
                string correoElectronico = string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || txtCorreoElectronico.Text == "Correo Electrónico" ? null : txtCorreoElectronico.Text;
                string redesSociales = string.IsNullOrWhiteSpace(txtRedesSociales.Text) || txtRedesSociales.Text == "Redes Sociales" ? null : txtRedesSociales.Text;
                string cache = string.IsNullOrWhiteSpace(txtCache.Text) || txtCache.Text == "Caché" ? null : txtCache.Text;
                string alojamiento = string.IsNullOrWhiteSpace(txtLugarAlojamiento.Text) || txtLugarAlojamiento.Text == "Lugar de Alojamiento" ? null : txtLugarAlojamiento.Text;
                string peticionEspecial = string.IsNullOrWhiteSpace(txtPeticionEspecial.Text) || txtPeticionEspecial.Text == "Petición Especial" ? null : txtPeticionEspecial.Text;

                // Obtener la fecha de inicio del festival y su duración (se hereda)
                DateTime fechaInicioFestival = DatosApp.FechaFestivalAct; // Supongamos que es un método que lo retorna
                int duracionFestival = DatosApp.DuracionFestivalAct; // Supongamos que es un método que lo retorna

                // Crear el objeto Artista
                NuevoArtista = new Artista(
                    txtNombreArtista.Text,
                    txtGeneroMusical.Text,
                    datosPersonales,
                    correoElectronico,
                    redesSociales,
                    cache,
                    fechaInicioFestival,
                    duracionFestival,
                    null,
                    null,
                    null,
                    null,
                    alojamiento,
                    peticionEspecial,
                    "ACTIVO" // Estado
                );

                DialogResult = true; // Todo está correcto, cerramos la ventana
                Close();
            }
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejar cambios en la selección de estado si es necesario
        }
    }
}
