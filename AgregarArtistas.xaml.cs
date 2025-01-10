using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

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
                    case "txtDiaHoraInicioActuacion":
                        textBox.Text = "Día y Hora del Inicio de la Actuación";
                        break;
                    case "txtDiaHoraFinActuacion":
                        textBox.Text = "Día y Hora del Fin de la Actuación";
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
                NuevoArtista = new Artista(
                    txtNombreArtista.Text,
                    txtGeneroMusical.Text,
                    string.IsNullOrWhiteSpace(txtDatosPersonales.Text) || txtDatosPersonales.Text == "Datos Personales" ? null : txtDatosPersonales.Text,
                    string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || txtCorreoElectronico.Text == "Correo Electrónico" ? null : txtCorreoElectronico.Text,
                    string.IsNullOrWhiteSpace(txtRedesSociales.Text) || txtRedesSociales.Text == "Redes Sociales" ? null : txtRedesSociales.Text,
                    string.IsNullOrWhiteSpace(txtCache.Text) || txtCache.Text == "Caché" ? null : txtCache.Text,
                    null,
                    null,  // DiaYHoraInicioActuacion
                    null,  // DiaYHoraFinActuacion
                    string.IsNullOrWhiteSpace(txtEscenario.Text) || txtEscenario.Text == "Escenario" ? null : txtEscenario.Text,
                    string.IsNullOrWhiteSpace(txtLugarAlojamiento.Text) || txtLugarAlojamiento.Text == "Lugar de Alojamiento" ? null : txtLugarAlojamiento.Text,
                    string.IsNullOrWhiteSpace(txtPeticionEspecial.Text) || txtPeticionEspecial.Text == "Petición Especial" ? null : txtPeticionEspecial.Text,
                    cbEstado.SelectedItem.ToString() // Estado
                );


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
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejar cambios en la selección de estado si es necesario
        }

        private void cbTipoArtista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipoArtista.SelectedItem?.ToString() == "Grupo")
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
