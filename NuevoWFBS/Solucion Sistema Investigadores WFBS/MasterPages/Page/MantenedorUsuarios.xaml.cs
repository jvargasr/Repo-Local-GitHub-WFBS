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
    /// <summary>
    /// Lógica de interacción para MantenedorUsuarios.xaml
    /// </summary>
    public partial class MantenedorUsuarios : System.Windows.Controls.Page
    {

        public MantenedorUsuarios()
        {
            InitializeComponent();
        }

        private void dgUsuarios_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgUsuarios.ItemsSource = col.ReadAllUsuarios();
            dgUsuarios.Columns[3].Visibility = Visibility.Collapsed;
            dgUsuarios.Columns[4].Visibility = Visibility.Collapsed;
            dgUsuarios.Columns[6].Visibility = Visibility.Collapsed;


        }
        private void dgUsuarios_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*Para cambiar nombre de cabecera*/
             if (e.Column.Header.ToString() == "Area")
                e.Column.Header = "Área";
                
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarUsuario nextPage = new InsertarUsuario();
            navService.Navigate(nextPage);
        }

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null)
            {
                Usuario us = (Usuario)dgUsuarios.SelectedItem;
                //MessageBox.Show(us.Rut, "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarUsuario nextPage = new ModificarUsuario(us.Rut);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario antes", "Aviso:");
            }
        }
        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null)
            {
                Usuario us = (Usuario)dgUsuarios.SelectedItem;
                us.Delete();
                MessageBox.Show("El usuario seleccionado ha sido desactivado", "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorUsuarios nextPage = new MantenedorUsuarios();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario antes", "Aviso:");
            }
        }
    }
}
