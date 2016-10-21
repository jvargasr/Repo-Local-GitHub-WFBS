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
    /// Lógica de interacción para InsertarHabilidad.xaml
    /// </summary>
    public partial class InsertarHabilidad : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Habilidad hab = new Habilidad();
        int id_comp;
        public InsertarHabilidad(int id_com)
        {
            InitializeComponent();

            id_comp = id_com;

        }

        private void cmbId_Competencia_Loaded(object sender, RoutedEventArgs e)
        {
            int select = 0, i = 0;
            List<Competencia> competencias = col.ReadAllCompetencias();
            foreach (Competencia item in competencias)
            {
                if (item.Id_com == id_comp)
                {
                    cmbId_Competencia.Items.Add(item.Nombre);
                    select = i;
                    i++;
                }
            }
            cmbId_Competencia.SelectedIndex = select;
            cmbId_Competencia.IsEnabled = false;

        }


        private void cmbNota_Loaded(object sender, RoutedEventArgs e)
        {
            cmbNota.Items.Add("0");
            cmbNota.Items.Add("1");
            cmbNota.Items.Add("2");
            cmbNota.Items.Add("3");
            cmbNota.Items.Add("4");
            cmbNota.Items.Add("5");
            cmbNota.SelectedIndex = 0;
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            cmbId_Competencia.SelectedIndex = 0;
            txtNombre.Text = string.Empty;
            cmbNota.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            try
            {
                Habilidad hab = new Habilidad();

                foreach (Competencia c in competencias)
                {
                    if (c.Nombre == (string)cmbId_Competencia.SelectedItem)
                    {
                        hab.Id_Competencia = Convert.ToInt32(c.Id_com);
                    }
                }
                hab.Nombre = txtNombre.Text;
                switch (cmbNota.SelectedIndex)
                {
                    case 0:
                        hab.Nota_Encuesta = 0;
                        break;
                    case 1:
                        hab.Nota_Encuesta = 1;
                        break;
                    case 2:
                        hab.Nota_Encuesta = 2;
                        break;
                    case 3:
                        hab.Nota_Encuesta = 3;
                        break;
                    case 4:
                        hab.Nota_Encuesta = 4;
                        break;
                    case 5:
                        hab.Nota_Encuesta = 5;
                        break;

                    default:
                        hab.Nota_Encuesta = 0;
                        break;
                }
                if (hab.Create())
                {
                    MessageBox.Show("Agregado correctamente. Éxito!");
                    this.Limpiar();
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    MantenedorHabilidades nextPage = new MantenedorHabilidades(hab.Id_Competencia);
                    navService.Navigate(nextPage);
                }
                else
                {
                    MessageBox.Show("No se ha podido agregar la Habilidad, verifique que los datos sean correctos");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se pudo agregar la Habilidad!");
            }
        }
    }
}
