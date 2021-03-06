﻿using System;
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
    /// Lógica de interacción para ModificarPeriodo.xaml
    /// </summary>
    public partial class ModificarPeriodo : System.Windows.Controls.Page
    {
        Collections col = new Collections();
        PeriodoEvaluacion us = new PeriodoEvaluacion();
        public ModificarPeriodo()
        {
            InitializeComponent();
        }

        public ModificarPeriodo(int id)
        {
            InitializeComponent();

            us.idPeriodo = id;
            us.Read();

            DatePeriodo.Text = us.fechaInicio.ToString();
            txtVigencia.Text = us.vigencia.ToString();
            cmbPorcentajeAE.SelectedIndex = us.porcentajeAE;
            cmbPorcentajeE.SelectedIndex = us.porcentajeE;
        }

        private void cmbPorcentajeE_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPorcentajeE.Items.Add("10%");
            cmbPorcentajeE.Items.Add("20%");
            cmbPorcentajeE.Items.Add("30%");
            cmbPorcentajeE.Items.Add("40%");
            cmbPorcentajeE.Items.Add("50%");
            cmbPorcentajeE.Items.Add("60%");
            cmbPorcentajeE.Items.Add("70%");
            cmbPorcentajeE.Items.Add("80%");
            cmbPorcentajeE.Items.Add("90%");
            cmbPorcentajeE.Items.Add("100%");
            cmbPorcentajeE.SelectedItem = "30%";
        }

        private void cmbPorcentajeAE_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPorcentajeAE.Items.Add("10%");
            cmbPorcentajeAE.Items.Add("20%");
            cmbPorcentajeAE.Items.Add("30%");
            cmbPorcentajeAE.Items.Add("40%");
            cmbPorcentajeAE.Items.Add("50%");
            cmbPorcentajeAE.Items.Add("60%");
            cmbPorcentajeAE.Items.Add("70%");
            cmbPorcentajeAE.Items.Add("80%");
            cmbPorcentajeAE.Items.Add("90%");
            cmbPorcentajeAE.Items.Add("100%");
            cmbPorcentajeAE.SelectedItem = "70%";
        }



        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            List<PeriodoEvaluacion> periodos = col.ReadAllPeriodos();
            try
            {
                PeriodoEvaluacion per = new PeriodoEvaluacion();
                per.idPeriodo = int.Parse(txtIdPerido.Text);
                if (per.Read())
                {
                    if (DatePeriodo.SelectedDate == null && txtVigencia.Text.Length > 0)
                    {

                        per.vigencia = int.Parse(txtVigencia.Text);
                        #region porcentaje E
                        switch (cmbPorcentajeE.SelectedIndex + 1)
                        {
                            case 1:
                                per.porcentajeE = 10;
                                break;
                            case 2:
                                per.porcentajeE = 20;
                                break;
                            case 3:
                                per.porcentajeE = 30;
                                break;
                            case 4:
                                per.porcentajeE = 40;
                                break;
                            case 5:
                                per.porcentajeE = 50;
                                break;
                            case 6:
                                per.porcentajeE = 60;
                                break;
                            case 7:
                                per.porcentajeE = 70;
                                break;
                            case 8:
                                per.porcentajeE = 80;
                                break;
                            case 9:
                                per.porcentajeE = 90;
                                break;
                            case 10:
                                per.porcentajeE = 100;
                                break;


                            default:
                                per.porcentajeE = 10;
                                break;
                        }
                        #endregion
                        #region Porcentaje AE
                        switch (cmbPorcentajeAE.SelectedIndex + 1)
                        {
                            case 1:
                                per.porcentajeAE = 10;
                                break;
                            case 2:
                                per.porcentajeAE = 20;
                                break;
                            case 3:
                                per.porcentajeAE = 30;
                                break;
                            case 4:
                                per.porcentajeAE = 40;
                                break;
                            case 5:
                                per.porcentajeAE = 50;
                                break;
                            case 6:
                                per.porcentajeAE = 60;
                                break;
                            case 7:
                                per.porcentajeAE = 70;
                                break;
                            case 8:
                                per.porcentajeAE = 80;
                                break;
                            case 9:
                                per.porcentajeAE = 90;
                                break;
                            case 10:
                                per.porcentajeAE = 100;
                                break;


                            default:
                                per.porcentajeAE = 10;
                                break;
                        }
                        #endregion


                        per.Update();
                        MessageBox.Show("Actualizado correctamente. Éxito!");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        MantenedorPeriodoEvaluacion nextPage = new MantenedorPeriodoEvaluacion();
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

                MessageBox.Show("No se ha podido modificar el periodo. Verifique que la información esté correcta", "Error");
            }
        }
    }
}
