using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ProyectoIPo
{
    public partial class Login : Window
    {
        private DateTime fechaUltimoAcceso;
        public Login()
        {
            InitializeComponent();
            fechaUltimoAcceso = DateTime.Now; // Inicializa la fecha del último acceso
        }

        // Manejo del foco para el cuadro de texto "Usuario"
        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            lblUsuario.Visibility = Visibility.Collapsed; // Oculta "Usuario" al ganar foco
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                lblUsuario.Visibility = Visibility.Visible; // Muestra "Usuario" si está vacío
            }
        }

        // Manejo del foco para el cuadro de texto "Contraseña"
        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            lblPassword.Visibility = Visibility.Collapsed; // Oculta "Contraseña" al ganar foco
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                lblPassword.Visibility = Visibility.Visible; // Muestra "Contraseña" si está vacío
            }
        }


        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtUsuario.Text)) // Solo si escribió algo
                {
                    txtPassword.IsEnabled = true; // Habilitamos la contraseña
                    txtPassword.Focus();          // Mandamos el foco a la contraseña
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese el nombre de usuario.", "Campo obligatorio", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e); // Llama al método de clic del botón
            }
        }

        // Evento del botón Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            stackPanelRegistro.Visibility = Visibility.Collapsed;
            stackPanelLogin.Visibility = Visibility.Visible;
            string username = txtUsuario.Text;
            string password = txtPassword.Password;
            Usuario user = new Usuario(username, password, "admin@gmail.com", "admin", "admin");
            // Limpiamos el mensaje de error anterior
            txtError.Text = "";
            txtError.Visibility = Visibility.Collapsed;

            if (username == "admin" && password == "admin")
            {
                // Datos del usuario autenticado
                VentanaPrincipal ventanaPrincipal = new VentanaPrincipal(username, fechaUltimoAcceso);
                DatosApp.Usuarios.Add(username, user);
                ventanaPrincipal.Show();
                this.Close();
            }
            else
            {
                int maxIntentos = 3;
                int error = 0;

                for (int i = 0; i < maxIntentos; i++)
                {
                    // Verificar si el usuario existe en el diccionario
                    if (DatosApp.Usuarios.ContainsKey(username))
                    {
                        // Verificar si la contraseña también existe y es correcta
                        if (DatosApp.Usuarios[username].Contraseña == password)
                        {
                            // Si el usuario y la contraseña son correctos
                            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal(username, fechaUltimoAcceso);
                            ventanaPrincipal.Show();
                            this.Close();
                            return;  // Salimos del método si ya se ha abierto la ventana
                        }
                        else
                        {
                            // Contraseña incorrecta
                            txtError.Text = "La contraseña no es válida.";
                            txtError.Visibility = Visibility.Visible;
                            btnOlvidarContraseña.Visibility = Visibility.Visible;
                            error++;
                        }
                    }
                    else
                    {
                        // Usuario no encontrado
                        txtError.Text = "El usuario no es válido.";
                        txtError.Visibility = Visibility.Visible;
                        btnOlvidarContraseña.Visibility = Visibility.Visible;
                        error++;
                    }

                    // Si hemos alcanzado el número máximo de intentos
                    if (error >= maxIntentos)
                    {
                        btnOlvidarContraseña.Visibility = Visibility.Visible;
                        // Llamar al método de recuperación de contraseña
                        break;  // Salimos del bucle después de llamar a la recuperación
                    }
                }

            }
        }
        private void btnOlvidarContraseña_Click(object sender, RoutedEventArgs e)
        {   
            OlvidarContraseña olvidarContraseña = new OlvidarContraseña();
            olvidarContraseña.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            stackPanelLogin.Visibility = Visibility.Collapsed;
            stackPanelRegistro.Visibility = Visibility.Visible;
            btnOlvidarContraseña.Visibility= Visibility.Collapsed;
        }

        private void btnLoginFormulario_Click(object sender, RoutedEventArgs e)
        {
            stackPanelLogin.Visibility = Visibility.Visible;
            stackPanelRegistro.Visibility = Visibility.Collapsed;
        }

        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Introduzca su usuario y contraseña en los cuadros para iniciar sesión.\n" +
                "En caso de querer crear un nuevo usuario, haga click en registrarse (NOTA: Necesitará estar con el administrador del sistema para darse de alta).\n" +
                "Si tiene algún problema con su usuario y contraseña contacte con el administrador del sistema.", "Ayuda Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Evento para lblRegistro got Focus y Lost Focus
        // Evento para lblregisterNombreApellidos GotFocus y LostFocus
        private void lblregisterNombreApellidos_GotFocus(object sender, RoutedEventArgs e)
        {
            lblregisterNombreApellidos.Visibility = Visibility.Collapsed;
        }
        private void lblRegisterNombreApellidos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreApellidos.Text))  // CAMBIADO
            {
                lblregisterNombreApellidos.Visibility = Visibility.Visible;
            }
        }

        // Evento para lblregisterNombreUsuario GotFocus y LostFocus
        private void lblregisterNombreUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            lblregisterNombreUsuario.Visibility = Visibility.Collapsed;
        }
        private void lblregisterNombreUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))  // CAMBIADO
            {
                lblregisterNombreUsuario.Visibility = Visibility.Visible;
            }
        }

        // Evento para lblregisterContraseña GotFocus y LostFocus
        private void lblregisterContraseña_GotFocus(object sender, RoutedEventArgs e)
        {
            lblregisterContraseña.Visibility = Visibility.Collapsed;
        }
        private void lblregisterContraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordRegistro.Password))  // CAMBIADO
            {
                lblregisterContraseña.Visibility = Visibility.Visible;
            }
        }

        // Evento para lblregisterCorreo GotFocus y LostFocus
        private void lblregisterCorreo_GotFocus(object sender, RoutedEventArgs e)
        {
            lblregisterCorreo.Visibility = Visibility.Collapsed;
        }
        private void lblregisterCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))  // CAMBIADO
            {
                lblregisterCorreo.Visibility = Visibility.Visible;
            }
        }
        private void btnRegisterFormulario_Click(object sender, RoutedEventArgs e)
        {
            // Limpiar errores anteriores
            txtErrorNombreApellidos.Visibility = Visibility.Collapsed;
            txtErrorNombreUsuario.Visibility = Visibility.Collapsed;
            txtErrorCorreo.Visibility = Visibility.Collapsed;
            txtErrorContraseña.Visibility = Visibility.Collapsed;

            bool hayError = false;

            // Validar Nombre y Apellidos
            if (string.IsNullOrWhiteSpace(txtNombreApellidos.Text))
            {
                txtErrorNombreApellidos.Text = "Debe ingresar su nombre y apellidos.";
                txtErrorNombreApellidos.Visibility = Visibility.Visible;
                hayError = true;
            }

            // Validar Nombre de Usuario
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                txtErrorNombreUsuario.Text = "Debe ingresar un nombre de usuario.";
                txtErrorNombreUsuario.Visibility = Visibility.Visible;
                hayError = true;
            }
            else if (DatosApp.Usuarios.ContainsKey(txtNombreUsuario.Text))
            {
                txtErrorNombreUsuario.Text = "Este nombre de usuario ya existe.";
                txtErrorNombreUsuario.Visibility = Visibility.Visible;
                hayError = true;
            }

            // Validar Correo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                txtErrorCorreo.Text = "Debe ingresar un correo electrónico válido.";
                txtErrorCorreo.Visibility = Visibility.Visible;
                hayError = true;
            }

            // Validar Contraseña
            if (string.IsNullOrWhiteSpace(txtPasswordRegistro.Password))
            {
                txtErrorContraseña.Text = "Debe ingresar una contraseña.";
                txtErrorContraseña.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (hayError)
                return; // Si hay errores, no seguir

            // Si todo está bien, registrar el usuario
            string nombreApellidos = txtNombreApellidos.Text;
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtPasswordRegistro.Password;
            string correo = txtCorreo.Text;

            DatosApp.Usuarios[nombreUsuario] = new Usuario(correo, nombreApellidos, correo, nombreUsuario, contraseña);

        }





    }
}


