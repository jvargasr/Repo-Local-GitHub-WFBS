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
    /// Lógica de interacción para MantenedorCompetencias.xaml
    /// </summary>
    public partial class MantenedorCompetencias : System.Windows.Controls.Page
    {

        public MantenedorCompetencias()
        {
            InitializeComponent();
        }

        private void dgCompetencias_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgCompetencias.ItemsSource = col.ReadAllCompetencias();
            dgCompetencias.Columns[4].Visibility = Visibility.Collapsed;
            dgCompetencias.Columns[5].Visibility = Visibility.Collapsed;
            dgCompetencias.Columns[6].Visibility = Visibility.Hidden;
            dgCompetencias.Columns[7].Header = "Obsoleta";
            dgCompetencias.Columns[8].Header = "Nivel Óptimo";
            /* dgCompetencias.Columns[0].Header = "ID Competencia";
             dgCompetencias.Columns[1].Header = "Nombre";
             dgCompetencias.Columns[2].Header = "Descripción";
             dgCompetencias.Columns[3].Header = "Sigla";
             dgCompetencias.Columns[4].Header = "Obsoleta";
             dgCompetencias.Columns[5].Header = "Nivel Óptimo"; */
            dgCompetencias.Columns[0].Visibility = Visibility.Collapsed;
            /*dgCompetencias.Columns[6].Visibility = Visibility.Collapsed;*/

        }
        private void dgCompetencias_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*Para cambiar nombre de cabecera*/
            if (e.Column.Header.ToString() == "Descripcion")
            {
                e.Column.Header = "Descripción";
            }
            if (e.Column.Header.ToString() == "Nivel_Optimo")
            {
                e.Column.Header = "Nivel Óptimo";
            }

        }

        private void btnAgregarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarCompetencia nextPage = new InsertarCompetencia();
            navService.Navigate(nextPage);
        }

        private void btnModificarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompetencias.SelectedItem != null)
            {
                Competencia com = (Competencia)dgCompetencias.SelectedItem;
                int id = Convert.ToInt32(com.Id_com);
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarCompetencia nextPage = new ModificarCompetencia(id);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Competencia antes. Aviso:");
            }
        }
        private void btnEliminarCompetencia_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompetencias.SelectedItem != null)
            {
                Competencia com = (Competencia)dgCompetencias.SelectedItem;
                if (com.Delete())
                {
                    MessageBox.Show("La Competencia seleccionada ha sido desactivada", "Éxito!");
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    MantenedorCompetencias nextPage = new MantenedorCompetencias();
                    navService.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Competencia antes. Aviso:");
            }
        }
        private void btnMantenerHabilidad_Click(object sender, RoutedEventArgs e)
        {
            if (dgCompetencias.SelectedItem != null)
            {
                Competencia com = (Competencia)dgCompetencias.SelectedItem;
                int id = Convert.ToInt32(com.Id_com);
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorHabilidades nextPage = new MantenedorHabilidades(id);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Competencia antes. Aviso:");
            }
        }

    }
}
