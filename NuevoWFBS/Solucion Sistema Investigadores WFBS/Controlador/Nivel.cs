using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Controlador
{
    public class Nivel : ICrud
    {
        public int nota_Encuesta { get; set; }
        public string Nombre { get; set; }

        public Nivel()
        {
            this.Init();
        }

        private void Init()
        {
            this.nota_Encuesta = 0;
            this.Nombre = string.Empty;
        }

        public bool Create()
        {

            try
            {
                Modelo.NIVEL n = new NIVEL();

                n.NOTA_ENCUESTA = this.nota_Encuesta;
                n.NOMBRE = this.Nombre;

                CommonBC.ModeloWfbs.NIVEL.Add(n);
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
                Modelo.NIVEL n = CommonBC.ModeloWfbs.NIVEL.First(nn => nn.NOTA_ENCUESTA == this.nota_Encuesta);

                this.nota_Encuesta = Convert.ToInt32(n.NOTA_ENCUESTA);
                this.Nombre = n.NOMBRE;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
