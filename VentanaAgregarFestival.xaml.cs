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

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ubicacion))
            {
                MessageBox.Show("Por favor, complete los campos Nombre y Ubicación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (fecha == null)
            {
                MessageBox.Show("Por favor, seleccione una fecha válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(PrecioEstandarTextBox.Text?.Trim(), out decimal precioEstandar))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para Precio Estándar.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(PrecioVIPTextBox.Text?.Trim(), out decimal precioVIP))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para Precio VIP.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var nuevoFestival = new Festival
            {
                Nombre = nombre,
                Ubicacion = ubicacion,
                Fecha = fecha.Value,
                PrecioEstandar = precioEstandar,
                PrecioVIP = precioVIP
            };

            MessageBox.Show("Festival creado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            FestivalAdded?.Invoke(this, nuevoFestival);
            Close(); // Cerrar la ventana
        }

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

        private void DatePicker(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                datePicker.DisplayDateStart = DateTime.Today.AddDays(1);
            }
        }

    }

}
