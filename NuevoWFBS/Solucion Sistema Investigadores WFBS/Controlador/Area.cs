using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Controlador
{
    public class Area : ICrud
    {
        public int id_area { get; set; }
        public string area { get; set; }
        public string abreviacion { get; set; }
        public int obsoleta { get; set; }
        public virtual ICollection<PerfilesdeCargo> PerfildeCargo {get;set;}
        //public List<PerfilesdeCargo> perfilesdecargo { get; set; }
        public Area()
        {
            this.Init();
        }

        private void Init()
        {
            this.abreviacion = string.Empty;
            this.area = string.Empty;
            this.id_area = 0;
            this.obsoleta = 0;
        }

        public bool Create()
        {
            try
            {
                Modelo.AREA us = new AREA();
                us.ID_AREA = this.id_area;
                us.NOMBRE = this.area;
                us.ABREVIACION = this.abreviacion;
                us.OBSOLETA = this.obsoleta;
                CommonBC.ModeloWfbs.AREA.Add(us);
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
                Modelo.AREA area = CommonBC.ModeloWfbs.AREA.First(b => b.ID_AREA == this.id_area);

                this.id_area = Convert.ToInt32(area.ID_AREA);
                this.area = area.NOMBRE;
                this.abreviacion = area.ABREVIACION;
                this.obsoleta = Convert.ToInt32(area.OBSOLETA);

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
                Modelo.AREA us = CommonBC.ModeloWfbs.AREA.First(b => b.ID_AREA == this.id_area);
                us.NOMBRE = this.area;
                us.ID_AREA = this.id_area;
                us.ABREVIACION = this.abreviacion;
                us.OBSOLETA = this.obsoleta;

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
                Modelo.AREA us = CommonBC.ModeloWfbs.AREA.First(b => b.ID_AREA == this.id_area);
                us.OBSOLETA = 1;

                CommonBC.ModeloWfbs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}",this.area);
        }
    }
}
