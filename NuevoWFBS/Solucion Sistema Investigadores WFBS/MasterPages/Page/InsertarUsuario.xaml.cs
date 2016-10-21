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
using Controlador;
namespace MasterPages.Page
{
    /// <summary>holachao
    /// Lógica de interacción para InsertarUsuario.xaml
    /// </summary>
    public partial class InsertarUsuario : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        public InsertarUsuario()
        {
            InitializeComponent();
        }
        private void cmbSexo_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> sexo = new List<string>();
            sexo.Add("Masculino");
            sexo.Add("Femenino");
            var cmbSexo = sender as ComboBox;
            cmbSexo.ItemsSource = sexo;
            cmbSexo.SelectedIndex = 0;

        }
        private void cmbArea_Loaded(object sender, RoutedEventArgs e)
        {
            List<Area> areas = col.ReadAllAreas();
            foreach (Area item in areas)
            {
                cmbArea.Items.Add(item.area);
            }
            cmbArea.SelectedIndex = 0;
        }
        private void cmbJefe_Loaded(object sender, RoutedEventArgs e)
        {
            List<Usuario> jefes = col.ObtenerJefes();
            foreach (Usuario item in jefes)
            {
                cmbJefe.Items.Add(item.Nombre);
            }
            cmbJefe.SelectedIndex = 0;
        }
        private void cmbPerfil_Loaded(object sender, RoutedEventArgs e)
        {
            List<Perfil> perfiles = col.ReadAllPerfiles();
            foreach (Perfil item in perfiles)
            {
                cmbPerfil.Items.Add(item.perfil);
            }
            cmbPerfil.SelectedIndex = 2;
        }

        private void cmbPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPerfil.SelectedIndex != 2)
            {
                lbJefe.Visibility = Visibility.Hidden;
                cmbJefe.IsEnabled = false;
                cmbJefe.Visibility = Visibility.Hidden;
            }
            else
            {
                cmbJefe.IsEnabled = true;
                cmbJefe.Visibility = Visibility.Visible;
                lbJefe.Visibility = Visibility.Visible;
            }
            if (cmbPerfil.SelectedIndex == 0)
            {
                lbArea.Visibility = Visibility.Hidden;
                cmbArea.IsEnabled = false;
                cmbArea.Visibility = Visibility.Hidden;
            }
            else
            {
                lbArea.Visibility = Visibility.Visible;
                cmbArea.IsEnabled = true;
                cmbArea.Visibility = Visibility.Visible;
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtPassword2.Password = string.Empty;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            List<Area> areas = col.ReadAllAreas();
            List<Perfil> perfiles = col.ReadAllPerfiles();
            try
            {
                Usuario us = new Usuario();
                us.Rut = txtRut.Text;
                if (!us.Read())
                {
                    if (txtNombre.Text.Length > 0 && txtRut.Text.Length > 0 && txtPassword.Password.Length > 0)
                    {
                        if (txtPassword.Password == txtPassword2.Password)
                        {
                            us.Nombre = txtNombre.Text;
                            us.Password = txtPassword.Password;
                            if (cmbPerfil.SelectedIndex == 2)
                                us.Jefe = cmbJefe.SelectedItem.ToString();
                            else
                                us.Jefe = "";
                            if (cmbSexo.SelectedIndex == 0)
                                us.Sexo = "M";
                            else
                                us.Sexo = "F";
                            foreach (Area a in areas)
                            {
                                if (a.area == (string)cmbArea.SelectedItem)
                                {
                                    us.Id_Area = a.id_area;
                                }
                            }
                            foreach (Perfil p in perfiles)
                            {
                                if (p.perfil == (string)cmbPerfil.SelectedItem)
                                {
                                    us.Id_Perfil = p.id_pefil;
                                }
                            }
                            us.Create();
                            MessageBox.Show("Agregado correctamente", "Éxito!");
                            this.Limpiar();
                            NavigationService navService = NavigationService.GetNavigationService(this);
                            MantenedorUsuarios nextPage = new MantenedorUsuarios();
                            navService.Navigate(nextPage);
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden", "Error!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar los campos antes de ingresar", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("El rut ingresado ya posee un cuenta", "Error!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
