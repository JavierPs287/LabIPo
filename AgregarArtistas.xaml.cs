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
                    case "txtHoraActuacion":
                        textBox.Text = "Hora de actuación (HH:mm)";
                        break;
                    case "txtFoto":
                        textBox.Text = "Foto del artista";
                        break;
                    case "txtDetallesArtista":
                        textBox.Text = "Detalles del artista";
                        break;
                }
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            // Validar campos obligatorios
            bool camposInvalidos = false;

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreArtista.Text) || txtNombreArtista.Text == "Nombre del artista")
            {
                txtNombreArtista.BorderBrush = Brushes.Red;
                txtNombreArtista.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtNombreArtista.ClearValue(TextBox.BorderBrushProperty);
                txtNombreArtista.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtDatosPersonales.Text) || txtDatosPersonales.Text == "Datos Personales")
            {
                txtDatosPersonales.BorderBrush = Brushes.Red;
                txtDatosPersonales.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtDatosPersonales.ClearValue(TextBox.BorderBrushProperty);
                txtDatosPersonales.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || txtCorreoElectronico.Text == "Correo Electrónico")
            {
                txtCorreoElectronico.BorderBrush = Brushes.Red;
                txtCorreoElectronico.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtCorreoElectronico.ClearValue(TextBox.BorderBrushProperty);
                txtCorreoElectronico.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (camposInvalidos)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos obligatorios", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Crear el objeto NuevoArtista solo si las validaciones son correctas
            // Convertir campos opcionales o "placeholders" a null si corresponden
            string datosPersonales = string.IsNullOrWhiteSpace(txtDatosPersonales.Text) || txtDatosPersonales.Text == "Datos Personales" ? null : txtDatosPersonales.Text;
            string correoElectronico = string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || txtCorreoElectronico.Text == "Correo Electrónico" ? null : txtCorreoElectronico.Text;
            string redesSociales = string.IsNullOrWhiteSpace(txtRedesSociales.Text) || txtRedesSociales.Text == "Redes Sociales" ? null : txtRedesSociales.Text;
            string cache = string.IsNullOrWhiteSpace(txtCache.Text) || txtCache.Text == "Caché" ? null : txtCache.Text;
            string alojamiento = string.IsNullOrWhiteSpace(txtLugarAlojamiento.Text) || txtLugarAlojamiento.Text == "Lugar de Alojamiento" ? null : txtLugarAlojamiento.Text;
            string peticionEspecial = string.IsNullOrWhiteSpace(txtPeticionEspecial.Text) || txtPeticionEspecial.Text == "Petición Especial" ? null : txtPeticionEspecial.Text;
            string detallesArtista = string.IsNullOrWhiteSpace(txtDetallesArtista.Text) || txtDatosPersonales.Text == "Detalles Artista" ? null : txtDatosPersonales.Text;
            string foto = string.IsNullOrWhiteSpace(txtFoto.Text) || txtFoto.Text == "Foto" ? null : txtFoto.Text;
            DateTime? fechaActuacion = dpFechaActuacion.SelectedDate;
            TimeSpan? horaActuacionInicio = (TimeSpan.TryParse(cbHoraInicio.SelectedItem?.ToString(), out var hInicio) && cbHoraInicio.SelectedItem?.ToString() != "Hora de inicio de la actuación") ? hInicio : (TimeSpan?)null;
            TimeSpan? horaActuacionFin = (TimeSpan.TryParse(cbHoraFin.SelectedItem?.ToString(), out var hFin) && cbHoraFin.SelectedItem?.ToString() != "Hora de fin de la actuación") ? hFin : (TimeSpan?)null;

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
                fechaActuacion,
                horaActuacionInicio,
                horaActuacionFin,
                "",
                alojamiento,
                peticionEspecial,
                "ACTIVO", // Estado
                foto,
                detallesArtista
            );

            DialogResult = true; // Todo está correcto, cerramos la ventana
            Close();
        }

        private void BuscarFoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txtFoto.Text = openFileDialog.FileName; // Asigna la ruta del archivo seleccionado
            }
        }

        private void OnHoraComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.Items.Count == 0)
            {
                for (int h = 0; h < 24; h++)
                {
                    for (int m = 0; m < 60; m += 30) // cada 30 minutos
                    {
                        comboBox.Items.Add($"{h:D2}:{m:D2}");
                    }
                }
            }
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejar cambios en la selección de estado si es necesario
        }
    }
}
