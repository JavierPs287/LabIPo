using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            bool camposInvalidos = false;
            int aforoMax = 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.BorderBrush = Brushes.Red;
                txtNombre.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtNombre.ClearValue(TextBox.BorderBrushProperty);
                txtNombre.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtAforo.Text) || !int.TryParse(txtAforo.Text, out aforoMax))
            {
                txtAforo.BorderBrush = Brushes.Red;
                txtAforo.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtAforo.ClearValue(TextBox.BorderBrushProperty);
                txtAforo.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtEntradasSalidas.Text))
            {
                txtEntradasSalidas.BorderBrush = Brushes.Red;
                txtEntradasSalidas.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtEntradasSalidas.ClearValue(TextBox.BorderBrushProperty);
                txtEntradasSalidas.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtServiciosMedicos.Text))
            {
                txtServiciosMedicos.BorderBrush = Brushes.Red;
                txtServiciosMedicos.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtServiciosMedicos.ClearValue(TextBox.BorderBrushProperty);
                txtServiciosMedicos.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtAseos.Text))
            {
                txtAseos.BorderBrush = Brushes.Red;
                txtAseos.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtAseos.ClearValue(TextBox.BorderBrushProperty);
                txtAseos.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtSeguridad.Text))
            {
                txtSeguridad.BorderBrush = Brushes.Red;
                txtSeguridad.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtSeguridad.ClearValue(TextBox.BorderBrushProperty);
                txtSeguridad.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (string.IsNullOrWhiteSpace(txtFoto.Text))
            {
                txtFoto.BorderBrush = Brushes.Red;
                txtFoto.BorderThickness = new Thickness(2);
                camposInvalidos = true;
            }
            else
            {
                txtFoto.ClearValue(TextBox.BorderBrushProperty);
                txtFoto.ClearValue(TextBox.BorderThicknessProperty);
            }

            if (camposInvalidos)
                return;

            var nuevoEscenario = new Escenario
            {
                Nombre = txtNombre.Text,
                AforoMax = aforoMax,
                LocalizacionEntradasSalidas = txtEntradasSalidas.Text,
                ServiciosMedicos = txtServiciosMedicos.Text,
                Aseos = txtAseos.Text,
                Seguridad = txtSeguridad.Text,
                FotoPath = txtFoto.Text
            };

            // Añadir el escenario a la colección observable
            NuevosEscenarios.Add(nuevoEscenario);

            MessageBox.Show("Escenario añadido correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true;
            this.Close();
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