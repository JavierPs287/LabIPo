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
                string.IsNullOrWhiteSpace(txtFoto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
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
            txtFoto.Clear();
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
        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Introduzca los datos del escenario a agregar y haga click al boton 'Agregar'.", "Ayuda Agregar Escenario", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}