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
            NuevoArtista = new EstadoArtista
            {
                GeneroMusical = txtGeneroMusical.Text,
                DatosPersonales = txtDatosPersonales.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                RedesSociales = txtRedesSociales.Text,
                Cache = txtCache.Text,
                DiaHoraActuacion = txtDiaHoraActuacion.Text,
                Escenario = txtEscenario.Text,
                LugarAlojamiento = txtLugarAlojamiento.Text,
                PeticionEspecial = txtPeticionEspecial.Text,
                Estado = cbEstado.Text // Obtener el valor del ComboBox
            };
            if (cbTipoArtista.SelectedItem != null && cbTipoArtista.SelectedItem.ToString() == "Grupo")
            {
                int cantidadMiembros;
                if (int.TryParse(txtCantidadMiembros.Text, out cantidadMiembros))
                {
                    for (int i = 0; i < cantidadMiembros; i++)
                    {
                        var agregarArtistaWindow = new AgregarArtistas();
                        agregarArtistaWindow.ShowDialog();
                        // Aquí puedes manejar la información de cada miembro
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido para la cantidad de miembros.");
                    return;
                }
            }

            DialogResult = true;
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
