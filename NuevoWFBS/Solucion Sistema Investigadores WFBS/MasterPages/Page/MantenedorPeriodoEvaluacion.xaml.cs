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
    /// Lógica de interacción para MantenedorPeriodoEvaluacion.xaml
    /// </summary>
    public partial class MantenedorPeriodoEvaluacion : System.Windows.Controls.Page
    {
        public MantenedorPeriodoEvaluacion()
        {
            InitializeComponent();
        }

        private void btnAgregarPeriodo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            InsertarPeriodo nextPage = new InsertarPeriodo();
            navService.Navigate(nextPage);
        }

        private void dgPeriodo_Loaded(object sender, RoutedEventArgs e)
        {
            Collections col = new Collections();
            dgPeriodo.ItemsSource = col.ReadAllPeriodos();
        }

        private void btnModificarPeriodo_Click(object sender, RoutedEventArgs e)
        {
            if (dgPeriodo.SelectedItem != null)
            {
                PeriodoEvaluacion us = (PeriodoEvaluacion)dgPeriodo.SelectedItem;
                //MessageBox.Show(us.Rut, "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                ModificarPeriodo nextPage = new ModificarPeriodo(us.idPeriodo);
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un periodo antes", "Aviso:");
            }
        }

        private void btnEliminarPeriodo_Click(object sender, RoutedEventArgs e)
        {
            if (dgPeriodo.SelectedItem != null)
            {
                PeriodoEvaluacion us = (PeriodoEvaluacion)dgPeriodo.SelectedItem;
                us.Delete();
                MessageBox.Show("El periodo seleccionado ha sido desactivada", "Éxito!");
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorPeriodoEvaluacion nextPage = new MantenedorPeriodoEvaluacion();
                navService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un periodo antes", "Aviso:");
            }
        }
    }
}
