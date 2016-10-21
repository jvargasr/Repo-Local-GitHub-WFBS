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
    /// Lógica de interacción para ModificarArea.xaml
    /// </summary>
    public partial class ModificarArea : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Area us = new Area();
        public ModificarArea(int area)
        {
            InitializeComponent();

            us.id_area = area;
            us.Read();

            txtIdArea.Text = us.id_area.ToString();
            txtNombre.Text = us.area;
            txtAbreviacion.Text = us.abreviacion;
            txtObsoleta.Text = us.obsoleta.ToString();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtAbreviacion.Text = string.Empty;
            txtObsoleta.Text = string.Empty;

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            List<Area> areas = col.ReadAllAreas();
            try
            {
                Area us = new Area();
                us.id_area = int.Parse(txtIdArea.Text);
                if (us.Read())
                {
                    if (txtNombre.Text.Length > 0 && txtAbreviacion.Text.Length > 0 && txtObsoleta.Text.Length > 0)
                    {
                        us.area = txtNombre.Text;
                        us.abreviacion = txtAbreviacion.Text;
                        us.obsoleta = int.Parse(txtObsoleta.Text);
                        us.Update();
                        MessageBox.Show("Actualizado correctamente", "Éxito!");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        MantenedorArea nextPage = new MantenedorArea();
                        navService.Navigate(nextPage);


                    }
                    else
                    {
                        MessageBox.Show("Debe completar los campos antes de continuar", "Aviso");
                    }
                }
                else
                {
                    txtIdArea.Text = txtIdArea.Text + " - El area no existe";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se ha podido modificar el area, verifique que la información esté correcta", "Error");
            }

        }
    }
}
