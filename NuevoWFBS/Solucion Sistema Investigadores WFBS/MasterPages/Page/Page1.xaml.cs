using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controlador;

namespace MasterPages.Page
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : System.Windows.Controls.Page
    {

        Usuario us;

        public Page1()
        {
            InitializeComponent();

        }


        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            us = new Usuario();

            us.Rut = txtUser.Text;
            us.Password = (string)txtPass.Password;

            if (txtUser.Text.Length > 0 && txtPass.Password.Length > 0)
            {
                if (us.ValidarUsuario())
                {
                    us.Read();
                    Global.RutUsuario = us.Rut;
                    Global.NombreUsuario = us.Nombre;
                    Global.AreaInvestigacion = "Por definir";
                    Global.JefeUsuario = us.Jefe;

                    NavigationService navService = NavigationService.GetNavigationService(this);
                    Page2 nextPage = new Page2();
                    navService.Navigate(nextPage);

                }
                else
                {
                    MessageBox.Show("Rut o contraseña inválidos. Asegúrese de entrar con perfil de administrador al sistema.", "Error!");
                }
            }
            else
            {
                
            }

        }
    }
}