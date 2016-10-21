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
    /// Lógica de interacción para InsertarArea.xaml
    /// </summary>
    public partial class InsertarArea : System.Windows.Controls.Page
    {
        public InsertarArea()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }
        private void Limpiar()
        {
            txtIdArea.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAbreviacion.Text = string.Empty;
            txtObsoleta.Text = string.Empty;

        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Area us = new Area();

                us.id_area = int.Parse(txtIdArea.Text);
                us.area = txtNombre.Text;
                us.abreviacion = txtAbreviacion.Text;
                us.obsoleta = int.Parse(txtObsoleta.Text);

                us.Create();
                MessageBox.Show("Agregado correctamente", "Éxito!");
                this.Limpiar();
                NavigationService navService = NavigationService.GetNavigationService(this);
                MantenedorArea nextPage = new MantenedorArea();
                navService.Navigate(nextPage);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar");
            }
        }
    }
}
