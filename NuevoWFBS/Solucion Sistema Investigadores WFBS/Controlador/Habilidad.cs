using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class Habilidad : ICrud
    {
        public int Id_Habilidad { get; set; }
        public int Id_Competencia { get; set; }
        public string Nombre { get; set; }
        public int Nota_Encuesta { get; set; }

        public Habilidad()
        {
            this.Init();
        }

        private void Init()
        {
            this.Id_Competencia = 0;
            this.Id_Competencia = 0;
            this.Nombre = string.Empty;
            this.Nota_Encuesta = 0;
        }

        //Crea una nueva instancia de WFBSentities y almacena en esta la nueva instancia de modelo habilidad
        public bool Create()
        {
            try
            {
                Modelo.WFBSEntities habi = new Modelo.WFBSEntities();
                Modelo.HABILIDAD hab = new HABILIDAD();
                hab.ID_HABILIDAD = this.Id_Habilidad;
                hab.ID_COMPETENCIA = this.Id_Competencia;
                hab.NOMBRE = this.Nombre;
                hab.NOTA_ENCUESTA = this.Nota_Encuesta;

                habi.HABILIDAD.Add(hab);
                habi.SaveChanges();
                //CommonBC.ModeloWfbs.HABILIDAD.Add(hab);
                //CommonBC.ModeloWfbs.SaveChanges();
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
                Modelo.HABILIDAD hab = CommonBC.ModeloWfbs.HABILIDAD.First(h => h.ID_HABILIDAD == this.Id_Habilidad);

                this.Id_Habilidad = Convert.ToInt32(hab.ID_HABILIDAD);
                this.Id_Competencia = Convert.ToInt32(hab.ID_COMPETENCIA);
                this.Nombre = hab.NOMBRE;
                this.Nota_Encuesta = Convert.ToInt32(hab.NOTA_ENCUESTA);

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
                Modelo.HABILIDAD hab = CommonBC.ModeloWfbs.HABILIDAD.First(h => h.ID_HABILIDAD == this.Id_Habilidad);

                hab.ID_HABILIDAD = this.Id_Habilidad;
                hab.ID_COMPETENCIA = this.Id_Competencia;
                hab.NOMBRE = this.Nombre;
                hab.NOTA_ENCUESTA = this.Nota_Encuesta;

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
                Modelo.HABILIDAD hab = CommonBC.ModeloWfbs.HABILIDAD.First(h => h.ID_HABILIDAD == this.Id_Habilidad);
                CommonBC.ModeloWfbs.HABILIDAD.Remove(hab);
                CommonBC.ModeloWfbs.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
