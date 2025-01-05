using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ProyectoIPo
{
    public partial class AgregarArtistas : Window
    {
        public EstadoArtista NuevoArtista { get; private set; }

        public AgregarArtistas()
        {
            InitializeComponent();
        }

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == Brushes.Gray)
            {
                // Borrar el texto solo si es el texto de marcador
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; // Cambiar el color del texto a negro
            }
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Restaurar el texto de marcador si el campo quedó vacío
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
                    case "txtDiaHoraActuacion":
                        textBox.Text = "Día y Hora de Actuación";
                        break;
                    case "txtEscenario":
                        textBox.Text = "Escenario";
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
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGeneroMusical.Text) || txtGeneroMusical.Text == "Género Musical")
            {
                MessageBox.Show("El género musical es obligatorio.", "Error");
                return;
            }

            // Crear el objeto NuevoArtista solo si las validaciones son correctas
            NuevoArtista = new EstadoArtista
            {
                Nombre = txtNombreArtista.Text,
                GeneroMusical = txtGeneroMusical.Text,
                DatosPersonales = txtDatosPersonales.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                RedesSociales = txtRedesSociales.Text,
                Cache = txtCache.Text,
                DiaHoraActuacion = txtDiaHoraActuacion.Text,
                Escenario = txtEscenario.Text,
                LugarAlojamiento = txtLugarAlojamiento.Text,
                PeticionEspecial = txtPeticionEspecial.Text,
                Estado = cbEstado.SelectedItem?.ToString()
            };

            // Manejo especial para grupos
            if (cbTipoArtista.SelectedItem != null && cbTipoArtista.SelectedItem.ToString() == "Grupo")
            {
                int cantidadMiembros;
                if (int.TryParse(txtCantidadMiembros.Text, out cantidadMiembros) && cantidadMiembros > 0)
                {
                    // Aquí puedes implementar lógica para agregar miembros del grupo
                    MessageBox.Show($"Grupo creado con {cantidadMiembros} miembros. Implementa lógica adicional aquí.", "Información");
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido para la cantidad de miembros.", "Error");
                    return;
                }
            }

            DialogResult = true; // Todo está correcto, cerramos la ventana
            Close();
        }


        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbTipoArtista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spGrupo == null)
            {
                // Handle the null case, possibly log an error or initialize spGrupo
                return;
            }

            if (cbTipoArtista.SelectedItem.ToString() == "Grupo")
            {
                spGrupo.Visibility = Visibility.Visible;
            }
            else
            {
                spGrupo.Visibility = Visibility.Collapsed;
            }
        }



    }
}
