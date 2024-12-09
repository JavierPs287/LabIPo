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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoIPo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string imagePath = @"Recursos\Login\FondoPantallaLogin.jpg";

            Uri imageUri = new Uri(imagePath, UriKind.Relative); // Usa UriKind.Relative si la ruta es relativa
            BitmapImage bitmap = new BitmapImage(imageUri);

            // Asignar la imagen como fondo
            this.Background = new ImageBrush(bitmap);
        }
    }
}
