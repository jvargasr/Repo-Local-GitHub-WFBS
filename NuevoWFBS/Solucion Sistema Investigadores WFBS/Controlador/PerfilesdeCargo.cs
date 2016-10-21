using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Controlador
{
    public class PerfilesdeCargo
    {
        public int id_perfil_de_cargo { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        //public List<Area> areas { get; set; }
        public PerfilesdeCargo()
        {
            this.Init();
        }

        private void Init()
        {
            this.descripcion = string.Empty;
            this.id_perfil_de_cargo = 0;
        }

        public bool Create()
        {
            MyDbContext db = new MyDbContext();
            try
            {
                Modelo.PERFIL_DE_CARGO pc = new PERFIL_DE_CARGO();
                pc.DESCRIPCION = this.descripcion;
                CommonBC.ModeloWfbs.PERFIL_DE_CARGO.Add(pc);
                CommonBC.ModeloWfbs.SaveChanges();

                /*
                PerfilesdeCargo perfil = new PerfilesdeCargo();
                perfil.descripcion = this.descripcion;
                perfil.Area = areas;
                db.PerfilesdeCargo.Add(perfil);
                db.SaveChanges();*/

                //int id = this.id_perfil_de_cargo;

                /*foreach (Area a in areas)
                {
                    using (var context = new MyDbContext())
                    {
                        var perfildecargo = context.PerfilesdeCargo.Find(id);
                        var area = context.Areas.Find(a.id_area);

                        // Establecer la relación entre el usuario y el compromiso
                        //area.PerfildeCargo.Add(perfildecargo);
                        perfildecargo.Area.Add(area);
                        area.PerfildeCargo.Add(perfildecargo);
                        context.SaveChanges();
                    }
                }*/

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
                Modelo.PERFIL_DE_CARGO pcargo = CommonBC.ModeloWfbs.PERFIL_DE_CARGO.First(pc => pc.ID_PERFIL_DE_CARGO == this.id_perfil_de_cargo);

                this.id_perfil_de_cargo = Convert.ToInt32(pcargo.ID_PERFIL_DE_CARGO);
                this.descripcion = pcargo.DESCRIPCION;

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
                Modelo.PERFIL_DE_CARGO pcargo = CommonBC.ModeloWfbs.PERFIL_DE_CARGO.First(pc => pc.ID_PERFIL_DE_CARGO == this.id_perfil_de_cargo);
                pcargo.ID_PERFIL_DE_CARGO = this.id_perfil_de_cargo;
                pcargo.DESCRIPCION = this.descripcion;


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
                Modelo.PERFIL_DE_CARGO pcargo = CommonBC.ModeloWfbs.PERFIL_DE_CARGO.First(pc => pc.ID_PERFIL_DE_CARGO == this.id_perfil_de_cargo);
               // pcargo.OBSOLETA = 1;

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
