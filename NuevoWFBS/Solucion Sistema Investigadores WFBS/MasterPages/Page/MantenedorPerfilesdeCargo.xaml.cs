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
    /// Lógica de interacción para MantenedorPerfilesdeCargo.xaml
    /// </summary>
    public partial class MantenedorPerfilesdeCargo : System.Windows.Controls.Page
    {
        public MantenedorPerfilesdeCargo()
        {
            InitializeComponent();
        }

        private void dgPerfildeCargo_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgPerfildeCargo.ItemsSource = col.ReadAllPerfilesdeCargo();
            dgPerfildeCargo.Columns[2].Visibility = Visibility.Collapsed;
            dgPerfildeCargo.Columns[0].Header = "ID";

        }
        private void dgPerfildeCargo_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*Para cambiar nombre de cabecera*/
            if (e.Column.Header.ToString() == "descripcion")
                e.Column.Header = "Descripción";


        }

        private void btnAgregaPerfildeCargo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            IngresarPerfildeCargo nextPage = new IngresarPerfildeCargo();
            navService.Navigate(nextPage);
        }

        private void btnModificarPerfildeCargo_Click(object sender, RoutedEventArgs e)
        {
            if (dgPerfildeCargo.SelectedItem != null)
            {
                PerfilesdeCargo pc = (PerfilesdeCargo)dgPerfildeCargo.SelectedItem;
                //MessageBox.Show(us.Rut, "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarPerfildeCargo nextPage = new ModificarPerfildeCargo(pc.id_perfil_de_cargo);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil de cargo antes", "Aviso:");
            }
        }
        private void btnEliminarPerfildeCargo_Click(object sender, RoutedEventArgs e)
        {
            if (dgPerfildeCargo.SelectedItem != null)
            {
                PerfilesdeCargo pc = (PerfilesdeCargo)dgPerfildeCargo.SelectedItem;
                pc.Delete();
                MessageBox.Show("El perfil de cargo seleccionado ha sido desactivado", "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorPerfilesdeCargo nextPage = new MantenedorPerfilesdeCargo();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil de cargo antes", "Aviso:");
            }
        }
    }
}
