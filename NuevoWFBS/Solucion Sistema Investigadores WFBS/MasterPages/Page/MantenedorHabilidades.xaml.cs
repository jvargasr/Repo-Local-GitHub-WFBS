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
    public partial class MantenedorHabilidades : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Habilidad hab = new Habilidad();
        Competencia com = new Competencia();
        int id_com;
        public MantenedorHabilidades()
        {
            InitializeComponent();
        }

        public MantenedorHabilidades(int id)
        {
            InitializeComponent();
            com.Id_competencia = id;
            id_com = id;
            /*
            hab.Id_Competencia = id;
            hab.Read();*/

            dgHabilidades.ItemsSource = col.ObtenerHabPorCom(id);
        }

        private void dgHabilidades_Loaded(object sender, RoutedEventArgs e)
        {
            /*Collections col = new Collections();
            Habilidad hab = new Habilidad();
            Habilidad habi = (Habilidad)dgHabilidades.SelectedItem;*/
            /*
            dgHabilidades.Columns[0].Header = "ID Habilidad";
            dgHabilidades.Columns[1].Header = "ID Competecia";
            dgHabilidades.Columns[2].Header = "Descripcion";
            dgHabilidades.Columns[3].Header = "Nota Encuesta";*/
            /*dgHabilidades.Columns[0].Visibility = Visibility.Hidden; */

        }
        private void dgHabilidades_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*Para cambiar nombre de cabecera*/
            if (e.Column.Header.ToString() == "Id_Habilidad")
            {
                e.Column.Header = "ID Habilidad";
            }
            if (e.Column.Header.ToString() == "Id_Competencia")
            {
                e.Column.Header = "ID Competencia";
            }
            if (e.Column.Header.ToString() == "Descripcion")
            {
                e.Column.Header = "Descripción";
            }
            if (e.Column.Header.ToString() == "Nota_Encuesta")
            {
                e.Column.Header = "Nota Encuesta";
            }

        }

        private void btnAgregarHabilidad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarHabilidad nextPage = new InsertarHabilidad(id_com);
            navService.Navigate(nextPage);
        }

        private void btnModificarHabilidad_Click(object sender, RoutedEventArgs e)
        {
            if (dgHabilidades.SelectedItem != null)
            {
                Habilidad hab = (Habilidad)dgHabilidades.SelectedItem;
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarHabilidad nextPage = new ModificarHabilidad(hab.Id_Habilidad, id_com);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Habilidad antes. Aviso:");
            }
        }
        private void btnEliminarHabilidad_Click(object sender, RoutedEventArgs e)
        {
            if (dgHabilidades.SelectedItem != null)
            {
                Habilidad hab = (Habilidad)dgHabilidades.SelectedItem;
                hab.Delete();
                MessageBox.Show("La Habilidad seleccionada ha sido eliminada. Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorHabilidades nextPage = new MantenedorHabilidades();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Habilidad antes", "Aviso:");
            }
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            MantenedorCompetencias nextPage = new MantenedorCompetencias();
            navService.Navigate(nextPage);
        }
    }
}
