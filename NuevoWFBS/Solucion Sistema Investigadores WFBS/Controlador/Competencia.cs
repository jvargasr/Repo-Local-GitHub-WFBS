using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class Competencia : ICrud
    {
        public int Id_competencia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public int Obsoleta { get; set; }
        public int Nivel_Optimo { get; set; }
        public decimal Id_com { get; set; }
        public string Obs { get; set; }
        public decimal Nivel_O { get; set; }

        public Competencia()
        {
            this.Init();
        }

        private void Init()
        {
            this.Id_competencia = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.Sigla = string.Empty;
            this.Obsoleta = 0;
            this.Nivel_Optimo = 0;
        }

        //Crea una nueva instancia de WFBSentities y almacena en esta la nueva instancia de modelo competencia
        public bool Create()
        {
            try
            {
                Modelo.WFBSEntities compe = new Modelo.WFBSEntities();
                Modelo.COMPETENCIA com = new COMPETENCIA();

                com.ID_COMPETENCIA = this.Id_competencia;
                com.NOMBRE = this.Nombre;
                com.DESCRIPCION = this.Descripcion;
                com.SIGLA = this.Sigla;
                com.OBSOLETA = this.Obsoleta;
                com.NIVEL_OPTIMO_ESPERADO = this.Nivel_Optimo;

                compe.COMPETENCIA.Add(com);
                compe.SaveChanges();
                //CommonBC.ModeloWfbs.COMPETENCIA.Add(com);
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
                Modelo.COMPETENCIA com = CommonBC.ModeloWfbs.COMPETENCIA.First(b => b.ID_COMPETENCIA == this.Id_competencia);

                this.Id_competencia = Convert.ToInt32(com.ID_COMPETENCIA);
                this.Nombre = com.NOMBRE;
                this.Descripcion = com.DESCRIPCION;
                this.Sigla = com.SIGLA;
                this.Obsoleta = Convert.ToInt32(com.OBSOLETA);
                this.Nivel_Optimo = Convert.ToInt32(com.NIVEL_OPTIMO_ESPERADO);

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
                Modelo.COMPETENCIA com = CommonBC.ModeloWfbs.COMPETENCIA.First(c => c.ID_COMPETENCIA == this.Id_competencia);

                com.ID_COMPETENCIA = this.Id_competencia;
                com.NOMBRE = this.Nombre;
                com.DESCRIPCION = this.Descripcion;
                com.SIGLA = this.Sigla;
                com.OBSOLETA = this.Obsoleta;
                com.NIVEL_OPTIMO_ESPERADO = this.Nivel_Optimo;

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
                Modelo.COMPETENCIA com = CommonBC.ModeloWfbs.COMPETENCIA.First(c => c.ID_COMPETENCIA == this.Id_com);
                com.OBSOLETA = 1;
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
