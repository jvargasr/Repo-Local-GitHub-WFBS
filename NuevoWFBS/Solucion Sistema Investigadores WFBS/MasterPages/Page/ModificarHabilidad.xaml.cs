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
    /// Lógica de interacción para ModificarHabilidad.xaml
    /// </summary>
    public partial class ModificarHabilidad : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        Habilidad hab = new Habilidad();
        int id_comp;
        public ModificarHabilidad()
        {
            InitializeComponent();
        }

        public ModificarHabilidad(int id, int id_com)
        {
            InitializeComponent();

            hab.Id_Habilidad = id;
            hab.Read();
            id_comp = id_com;

            txtId_Habilidad.Text = hab.Id_Habilidad.ToString();
            /* cmbId_Competencia.SelectedIndex = hab.Id_Competencia;*/
            txtNombre.Text = hab.Nombre;
        }

        private void cmbId_Competencia_Loaded(object sender, RoutedEventArgs e)
        {
            int select = 0, i = 0;
            List<Competencia> competencias = col.ReadAllCompetencias();
            foreach (Competencia item in competencias)
            {
                if (item.Id_com == hab.Id_Competencia)
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            List<Competencia> competencias = col.ReadAllCompetencias();
            try
            {
                Habilidad hab = new Habilidad();
                hab.Id_Habilidad = int.Parse(txtId_Habilidad.Text);
                if (hab.Read())
                {
                    if (txtNombre.Text.Length > 0 && int.Parse(txtId_Habilidad.Text) > 0)
                    {

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
                        foreach (Competencia c in competencias)
                        {
                            if (c.Nombre == (string)cmbId_Competencia.SelectedItem)
                            {
                                hab.Id_Competencia = c.Id_competencia;
                            }
                        }
                        hab.Update();
                        MessageBox.Show("Actualizado correctamente. Éxito!");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        MantenedorHabilidades nextPage = new MantenedorHabilidades(id_comp);
                        navService.Navigate(nextPage);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos antes de continuar. Aviso");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No se ha podido modificar la Habilidad. Verifique que la información esté correcta", "Error");
            }
        }
    }
}

