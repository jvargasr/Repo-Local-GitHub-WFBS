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
    /// Lógica de interacción para EliminarCompetencia.xaml
    /// </summary>
    public partial class EliminarCompetencia : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Competencia com = new Competencia();
        public EliminarCompetencia()
        {
            InitializeComponent();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (rbNo.IsChecked == false)
            {
                lbNivel.Visibility = Visibility.Hidden;
                cmbNivel.IsEnabled = false;
                cmbNivel.Visibility = Visibility.Hidden;
            }
            else
            {
                lbNivel.Visibility = Visibility.Visible;
                cmbNivel.IsEnabled = true;
                cmbNivel.Visibility = Visibility.Visible;
            }
        }

        private void cmbNivel_Loaded(object sender, RoutedEventArgs e)
        {

            cmbNivel.Items.Add("0");
            cmbNivel.Items.Add("1");
            cmbNivel.Items.Add("2");
            cmbNivel.Items.Add("3");
            cmbNivel.Items.Add("4");
            cmbNivel.Items.Add("5");
            cmbNivel.SelectedIndex = Convert.ToInt32(com.Nivel_Optimo);
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSigla.Text = string.Empty;
            cmbNivel.SelectedIndex = 0;
            rbNo.IsChecked = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            List<Nivel> niveles = col.ReadAllNiveles();
            try
            {
                Competencia com = new Competencia();
                com.Id_competencia = int.Parse(txtId_Competencia.Text);
                if (com.Read())
                {
                    com.Delete();
                    MessageBox.Show("Competencia desactivada correctamente. Éxito!");
                }

                else
                {
                    MessageBox.Show("La Competencia no existe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar una Competencia para poder desactivar");
            }
        }
    }
}
