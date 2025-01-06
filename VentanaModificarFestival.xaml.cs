using System;
using System.Windows;

namespace ProyectoIPo
{
    public partial class VentanaModificarFestival : Window
    {
        private Festival festival;

        public VentanaModificarFestival(Festival festival)
        {
            InitializeComponent();
            this.festival = festival;
            CargarDatosFestival();
        }

        private void CargarDatosFestival()
        {
            txtNombre.Text = festival.Nombre;
            dpFecha.SelectedDate = festival.Fecha;
            txtUbicacion.Text = festival.Ubicacion;
        }

        private void OnGuardarClick(object sender, RoutedEventArgs e)
        {
            festival.Nombre = txtNombre.Text;
            festival.Fecha = dpFecha.SelectedDate ?? festival.Fecha;
            festival.Ubicacion = txtUbicacion.Text;

            DialogResult = true;
            Close();
        }
    }
}
