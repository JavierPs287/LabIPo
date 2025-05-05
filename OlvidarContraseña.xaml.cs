using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para OlvidarContraseña.xaml
    /// </summary>
    public partial class OlvidarContraseña : Window
    {
        public OlvidarContraseña()
        {
            InitializeComponent();
        }
        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            string correo = CorreoTextBox.Text.Trim();

            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("Por favor, introduce un correo válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Simulación de envío de correo
            MessageBox.Show($"Se ha enviado un correo de recuperación de contraseña a {correo}", "Correo enviado", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool EsCorreoValido(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
