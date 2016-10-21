using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class Usuario : ICrud
    {

        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Id_Area { get; set; }
        public int Id_Perfil { get; set; }
        public string Jefe { get; set; }
        public string Password { get; set; }
        public string Area { get; set; }
        public string Perfil { get; set; }

        public Usuario()
        {
            this.Init();
        }

        private void Init()
        {
            this.Rut = string.Empty;
            this.Nombre = string.Empty;
            this.Sexo = string.Empty;
            this.Id_Area = 0;
            this.Id_Perfil = 0;
            this.Jefe = string.Empty;
            this.Password = string.Empty;

        }

        public bool ValidarUsuario()
        {
            try
            {
                Modelo.USUARIO us = CommonBC.ModeloWfbs.USUARIO.First(b => b.RUT == this.Rut && b.PASSWORD == this.Password && b.ID_PERFIL==1);

                this.Rut = us.RUT;
                this.Nombre = us.NOMBRE;
                this.Sexo = us.SEXO;
                this.Id_Area = Convert.ToInt32(us.ID_AREA);
                this.Id_Perfil = Convert.ToInt32(us.ID_PERFIL);
                this.Jefe = us.JEFE_RESPECTIVO;
                this.Password = us.JEFE_RESPECTIVO;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Create()
        {
            try
            {
                Modelo.USUARIO us = new USUARIO();
                us.RUT = this.Rut;
                us.NOMBRE = this.Nombre;
                us.ID_AREA = this.Id_Area;
                us.ID_PERFIL = this.Id_Perfil;
                us.SEXO = this.Sexo;
                us.JEFE_RESPECTIVO = this.Jefe;
                us.PASSWORD = this.Password;
                CommonBC.ModeloWfbs.USUARIO.Add(us);
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
                Modelo.USUARIO us = CommonBC.ModeloWfbs.USUARIO.First(b => b.RUT == this.Rut);

                this.Rut = us.RUT;
                this.Nombre = us.NOMBRE;
                this.Sexo = us.SEXO;
                this.Id_Area = Convert.ToInt32(us.ID_AREA);
                this.Id_Perfil = Convert.ToInt32(us.ID_PERFIL);
                this.Jefe = us.JEFE_RESPECTIVO;
                this.Password = us.PASSWORD;

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
                Modelo.USUARIO us = CommonBC.ModeloWfbs.USUARIO.First(b => b.RUT == this.Rut);
                us.NOMBRE = this.Nombre;
                us.ID_AREA = this.Id_Area;
                us.ID_PERFIL = this.Id_Perfil;
                us.SEXO = this.Sexo;
                us.JEFE_RESPECTIVO = this.Jefe;
                us.PASSWORD = this.Password;

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
                Modelo.USUARIO us = CommonBC.ModeloWfbs.USUARIO.First(b => b.RUT == this.Rut);
                us.ID_PERFIL = 22;

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
