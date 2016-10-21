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
    /// Lógica de interacción para EliminarHabilidad.xaml
    /// </summary>
    public partial class EliminarHabilidad : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Habilidad hab = new Habilidad();
        public EliminarHabilidad()
        {
            InitializeComponent();
        }

        public EliminarHabilidad(int id)
        {
            InitializeComponent();

            hab.Id_Habilidad = id;
            hab.Read();

            txtId_Habilidad.Text = hab.Id_Habilidad.ToString();
            cmbId_Competencia.SelectedIndex = hab.Id_Competencia;
            txtNombre.Text = hab.Nombre;
        }

        private void cmbId_Competencia_Loaded(object sender, RoutedEventArgs e)
        {
            int select = 0, i = 0;
            List<Competencia> competencias = col.ReadAllCompetencias();
            foreach (Competencia item in competencias)
            {
                cmbId_Competencia.Items.Add(item.Nombre);
                if (item.Id_competencia == hab.Id_Competencia)
                    select = i;
                i++;
            }
            cmbId_Competencia.SelectedIndex = select;
        }
        private void cmbNota_Loaded(object sender, RoutedEventArgs e)
        {
            cmbNota.Items.Add("0");
            cmbNota.Items.Add("1");
            cmbNota.Items.Add("2");
            cmbNota.Items.Add("3");
            cmbNota.Items.Add("4");
            cmbNota.Items.Add("5");
            cmbNota.SelectedIndex = hab.Nota_Encuesta;
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            List<Habilidad> habilidades = col.ReadAllHabilidades();
            try
            {
                Habilidad hab = new Habilidad();
                hab.Id_Habilidad = int.Parse(txtId_Habilidad.Text);
                if (hab.Read())
                {
                    hab.Delete();
                    MessageBox.Show("Habilidad desactivada correctamente. Éxito!");
                }

                else
                {
                    MessageBox.Show("La Habilidad no existe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar una Habilidad para poder desactivar");
            }
        }
    }
}

