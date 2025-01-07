using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoIPo
{
    public partial class AgregarEscenarios : Window
    {
        // Propiedad ObservableCollection para los nuevos escenarios
        public ObservableCollection<Escenario> NuevosEscenarios { get; private set; } = new ObservableCollection<Escenario>();

        public AgregarEscenarios()
        {
            InitializeComponent();
            // Iniciar la lista observable para los nuevos escenarios
        }

        private void AgregarEscenario_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtAforo.Text) ||
                string.IsNullOrWhiteSpace(txtEntradasSalidas.Text) ||
                string.IsNullOrWhiteSpace(txtServiciosMedicos.Text) ||
                string.IsNullOrWhiteSpace(txtAseos.Text) ||
                string.IsNullOrWhiteSpace(txtSeguridad.Text) ||
                dpDiaActuacion.SelectedDate == null || // Verifica que se haya seleccionado una fecha
                string.IsNullOrWhiteSpace(txtHoraActuacion.Text) ||
                string.IsNullOrWhiteSpace(txtFoto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validar formato de la hora
            if (!TimeSpan.TryParse(txtHoraActuacion.Text, out TimeSpan horaActuacion))
            {
                MessageBox.Show("El formato de la hora es inválido. Use HH:mm.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Crear un nuevo escenario
                var nuevoEscenario = new Escenario
                {
                    Nombre = txtNombre.Text,
                    AforoMax = txtAforo.Text,
                    LocalizacionEntradasSalidas = txtEntradasSalidas.Text,
                    ServiciosMedicos = txtServiciosMedicos.Text,
                    Aseos = txtAseos.Text,
                    Seguridad = txtSeguridad.Text,
                    DiaHoraActuacion = dpDiaActuacion.SelectedDate.Value.Add(horaActuacion),
                    FotoPath = txtFoto.Text
                };

                // Agregar el nuevo escenario a la lista observable
                NuevosEscenarios.Add(nuevoEscenario);

                // Limpiar los campos del formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtAforo.Clear();
            txtEntradasSalidas.Clear();
            txtServiciosMedicos.Clear();
            txtAseos.Clear();
            txtSeguridad.Clear();
            txtHoraActuacion.Clear();
            txtFoto.Clear();
            dpDiaActuacion.SelectedDate = null;
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana
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
    }

    // Clase de escenario
    public class Escenario
    {
        public string Nombre { get; set; }
        public string AforoMax { get; set; }
        public string LocalizacionEntradasSalidas { get; set; }
        public string ServiciosMedicos { get; set; }
        public string Aseos { get; set; }
        public string Seguridad { get; set; }
        public DateTime DiaHoraActuacion { get; set; } // Día y hora de la actuación
        public string FotoPath { get; set; } // Ruta de la foto
    }
}