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
    /// Lógica de interacción para IngresarPerfildeCargo.xaml
    /// </summary>
    public partial class IngresarPerfildeCargo : System.Windows.Controls.Page
    {
        Controlador.Collections col = new Collections();
        List<PerfilesdeCargo> perfiles = new List<PerfilesdeCargo>();
        List<Area> areas = new List<Area>();
        public IngresarPerfildeCargo()
        {
            InitializeComponent();
            areas= col.ReadAllAreas();
            foreach (Area item in areas)
            {
                lbArea.Items.Add(item.ToString());
            }                       
        }
        private void btnToRight_Click(object sender, RoutedEventArgs e)
        {
            lbAreaSeleccionadas.Items.Add(lbArea.SelectedItem);
            lbArea.Items.Remove(lbArea.SelectedItem);
            lbAreaSeleccionadas.Items.Refresh();
            lbArea.Items.Refresh();
            
        }
        private void btnToLeft_Click(object sender, RoutedEventArgs e)
        {
            lbArea.Items.Add(lbAreaSeleccionadas.SelectedItem);
            lbAreaSeleccionadas.Items.Remove(lbAreaSeleccionadas.SelectedItem);
            lbArea.Items.Refresh();            
            lbAreaSeleccionadas.Items.Refresh();

        }
        private void btnAgregarPerfildeCargo_click(object sender, RoutedEventArgs e)
        {
            List<Area> areasSelec = new List<Area>();
            areas = col.ReadAllAreas();
            foreach (string item in lbAreaSeleccionadas.Items)
            {
                foreach (Area a in areas)
                {
                    if(a.area==item)
                    {
                        areasSelec.Add(a);
                    }
                }
            }
            if (lbAreaSeleccionadas.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar las áreas para el perfil");
            }
            else
            {
                if (txtDescripcion.Text.Length == 0)
                {
                    MessageBox.Show("Debe Ingresar una descripción");
                }
                else
                {
                    try
                    {
                        PerfilesdeCargo pc = new PerfilesdeCargo();
                        pc.descripcion = txtDescripcion.Text;
                        pc.Create();
                        MessageBox.Show("Perfil creado");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        IngresarPerfildeCargo nextPage = new IngresarPerfildeCargo();
                        navService.Navigate(nextPage);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
        private void Limpiar()
        {
            txtDescripcion.Text = string.Empty;

        }
    }
}
