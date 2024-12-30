using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ProyectoIPo
{
    /// <summary>
    /// Lógica de interacción para VentanaAgregarFestival.xaml
    /// </summary>
    public partial class VentanaAgregarFestival : Window
    {
        public event EventHandler<Festival> FestivalAdded; // Declaración del evento

        public VentanaAgregarFestival()
        {
            InitializeComponent();
        }

        private void OnAgregarFestivalClick(object sender, RoutedEventArgs e)
        {
            var nombre = NombreTextBox.Text?.Trim();
            var ubicacion = UbicacionTextBox.Text?.Trim();
            var fecha = FechaDatePicker.SelectedDate;
            var artistasTexto = ArtistasTextBox.Text
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .Where(a => !string.IsNullOrWhiteSpace(a));

            // Validar que los campos "Nombre" y "Ubicación" estén llenos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ubicacion))
            {
                MessageBox.Show("Por favor, complete los campos Nombre y Ubicación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar que se haya seleccionado una fecha
            if (fecha == null)
            {
                MessageBox.Show("Por favor, seleccione una fecha válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Crear la lista de artistas a partir del texto ingresado
            var artistas = artistasTexto.ToList(); // Convertimos a lista de strings

            // Crear el nuevo festival
            var nuevoFestival = new Festival
            {
                Nombre = nombre,
                Ubicacion = ubicacion,
                Fecha = fecha.Value,
                Artistas = artistas,      // Lista de strings
            };

            // Confirmar al usuario y notificar que el festival ha sido agregado
            MessageBox.Show("Festival creado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            FestivalAdded?.Invoke(this, nuevoFestival); // Notificar que se ha agregado un nuevo festival
            Close(); // Cerrar la ventana
        }

        // Manejo de eventos KeyDown para agregar el festival al presionar Enter
        private void NombreTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }

        private void UbicacionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }

        private void ArtistasTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }
    }

}
