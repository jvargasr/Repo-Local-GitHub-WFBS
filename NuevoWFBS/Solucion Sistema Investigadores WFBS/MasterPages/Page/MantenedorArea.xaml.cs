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
    /// Lógica de interacción para MantenedorArea.xaml
    /// </summary>
    public partial class MantenedorArea : System.Windows.Controls.Page
    {
        public MantenedorArea()
        {
            InitializeComponent();
        }

        private void btnModificarArea_Click(object sender, RoutedEventArgs e)
        {
            if (dgArea.SelectedItem != null)
            {
                Area us = (Area)dgArea.SelectedItem;
                //MessageBox.Show(us.Rut, "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarArea nextPage = new ModificarArea(us.id_area);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un área antes", "Aviso:");
            }
        }

        private void btnEliminarArea_Click(object sender, RoutedEventArgs e)
        {
            if (dgArea.SelectedItem != null)
            {
                Area us = (Area)dgArea.SelectedItem;
                us.Delete();
                MessageBox.Show("El área seleccionada ha sido desactivada", "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorArea nextPage = new MantenedorArea();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un área antes", "Aviso:");
            }
        }

        private void btnAgregarArea_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarArea nextPage = new InsertarArea();
            navService.Navigate(nextPage);
        }

        private void dgArea_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgArea.ItemsSource = col.ReadAllAreas();
            //dgArea.Columns[4].Visibility = Visibility.Collapsed;
        }
    }
}
