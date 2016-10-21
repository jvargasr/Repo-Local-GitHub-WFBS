using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class PeriodoEvaluacion : ICrud
    {
        public int idPeriodo { get; set; }
        public DateTime fechaInicio { get; set; }
        public int vigencia { get; set; }
        public int porcentajeE { get; set; }
        public int porcentajeAE { get; set; }

        public PeriodoEvaluacion()
        {
            this.Init();
        }

        private void Init()
        {
            this.idPeriodo = 0;
            this.fechaInicio = DateTime.Now;
            this.vigencia = 0;
            this.porcentajeE = 0;
            this.porcentajeAE = 0;
        }

        public bool Create()
        {
            try
            {
                Modelo.PERIODO_EVALUACION us = new PERIODO_EVALUACION();
                us.ID_PERIODO_EVALUACION = this.idPeriodo;
                us.FECHA_INICIO = this.fechaInicio;
                us.VIGENCIA = this.vigencia;
                us.PORCENTAJE_EVALUACION = this.porcentajeE;
                us.PORCENTAJE_AUTOEVALUACION = this.porcentajeAE;
                CommonBC.ModeloWfbs.PERIODO_EVALUACION.Add(us);
                CommonBC.ModeloWfbs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Modelo.PERIODO_EVALUACION periodo = CommonBC.ModeloWfbs.PERIODO_EVALUACION.First(b => b.ID_PERIODO_EVALUACION == this.idPeriodo);

                this.idPeriodo = Convert.ToInt32(periodo.ID_PERIODO_EVALUACION);
                this.fechaInicio = periodo.FECHA_INICIO;
                this.vigencia = Convert.ToInt32(periodo.VIGENCIA);
                this.porcentajeE = Convert.ToInt32(periodo.PORCENTAJE_EVALUACION);
                this.porcentajeAE = Convert.ToInt32(periodo.PORCENTAJE_AUTOEVALUACION);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Modelo.PERIODO_EVALUACION us = CommonBC.ModeloWfbs.PERIODO_EVALUACION.First(b => b.ID_PERIODO_EVALUACION == this.idPeriodo);
                us.ID_PERIODO_EVALUACION = this.idPeriodo;
                us.FECHA_INICIO = this.fechaInicio;
                us.VIGENCIA = this.vigencia;
                us.PORCENTAJE_EVALUACION = this.porcentajeE;
                us.PORCENTAJE_AUTOEVALUACION = this.porcentajeAE;

                CommonBC.ModeloWfbs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                Modelo.PERIODO_EVALUACION us = CommonBC.ModeloWfbs.PERIODO_EVALUACION.First(b => b.ID_PERIODO_EVALUACION == this.idPeriodo);
                us.VIGENCIA = 0;

                CommonBC.ModeloWfbs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
