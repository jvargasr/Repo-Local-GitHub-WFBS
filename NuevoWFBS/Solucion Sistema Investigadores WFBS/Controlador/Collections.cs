using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class Collections
    {
        /* Usuario */
        public List<Usuario> ReadAllUsuarios()
        {
            var usuariosBDD = from u in CommonBC.ModeloWfbs.USUARIO
                              join a in CommonBC.ModeloWfbs.AREA on u.ID_AREA equals a.ID_AREA
                              join p in CommonBC.ModeloWfbs.PERFIL on u.ID_PERFIL equals p.ID_PERFIL

                              select new Usuario
                              {
                                  Rut = u.RUT,
                                  Nombre = u.NOMBRE,
                                  Sexo = (u.SEXO=="M"?"Masculino": u.SEXO == "F" ? "Femenino":"No determinado"),
                                  Jefe = u.JEFE_RESPECTIVO,
                                  Area = a.NOMBRE,
                                  Perfil=p.TIPO_USUARIO,
                                  Password = u.PASSWORD
                              };
            return usuariosBDD.ToList();
        }


        private List<Controlador.Usuario> GenerarListado(List<Modelo.USUARIO> usuariosBDD)
        {
            List<Controlador.Usuario> usuariosController = new List<Usuario>();

            foreach (Modelo.USUARIO item in usuariosBDD)
            {
                Controlador.Usuario us = new Usuario();

                us.Rut = item.RUT;
                us.Nombre = item.NOMBRE;
                us.Sexo = item.SEXO;
                us.Id_Area = Convert.ToInt32(item.ID_AREA);
                us.Id_Perfil = Convert.ToInt32(item.ID_PERFIL);
                us.Jefe = item.JEFE_RESPECTIVO;


                usuariosController.Add(us);
            }

            return usuariosController;

        }

        /* Area */
        public List<Area> ReadAllAreas()
        {
            List<Modelo.AREA> areasBDD = CommonBC.ModeloWfbs.AREA.ToList();
            return GenerarListado(areasBDD);
        }

        private List<Controlador.Area> GenerarListado(List<Modelo.AREA> areasBDD)
        {
            List<Controlador.Area> areasController = new List<Area>();

            foreach (Modelo.AREA item in areasBDD)
            {
                Controlador.Area ar = new Area();

                ar.id_area = Convert.ToInt32(item.ID_AREA);
                ar.obsoleta = Convert.ToInt32(item.OBSOLETA);
                ar.abreviacion = item.ABREVIACION;
                ar.area = item.NOMBRE;

                areasController.Add(ar);
            }

            return areasController;
        }

        /* Perfiles de cargo */
        public List<PerfilesdeCargo> ReadAllPerfilesdeCargo()
        {
            List<Modelo.PERFIL_DE_CARGO> perfilesdecargoBDD = CommonBC.ModeloWfbs.PERFIL_DE_CARGO.ToList();
            return GenerarListado(perfilesdecargoBDD);
        }

        private List<Controlador.PerfilesdeCargo> GenerarListado(List<Modelo.PERFIL_DE_CARGO> perfilesdecargoBDD)
        {
            List<Controlador.PerfilesdeCargo> perfilesdecargoController = new List<PerfilesdeCargo>();

            foreach (Modelo.PERFIL_DE_CARGO item in perfilesdecargoBDD)
            {
                Controlador.PerfilesdeCargo pc = new PerfilesdeCargo();

                pc.id_perfil_de_cargo = Convert.ToInt32(item.ID_PERFIL_DE_CARGO);
                pc.descripcion = item.DESCRIPCION;

                perfilesdecargoController.Add(pc);
            }

            return perfilesdecargoController;
        }

        /* Perfil */
        public List<Perfil> ReadAllPerfiles()
        {
            List<Modelo.PERFIL> perfilesBDD = CommonBC.ModeloWfbs.PERFIL.ToList();
            return GenerarListadoPerfil(perfilesBDD);
        }

        private List<Perfil> GenerarListadoPerfil(List<PERFIL> perfilesBDD)
        {
            List<Controlador.Perfil> perfilesController = new List<Perfil>();

            foreach (Modelo.PERFIL item in perfilesBDD)
            {
                Controlador.Perfil p = new Perfil();

                p.id_pefil = Convert.ToInt32(item.ID_PERFIL);
                p.perfil = item.TIPO_USUARIO;

                perfilesController.Add(p);
            }

            return perfilesController;
        }

        /* Usuario Jefe */
        public List<Usuario> ObtenerJefes()
        {
            var Jefes = CommonBC.ModeloWfbs.USUARIO.Where(usu => usu.ID_PERFIL == 2);
            return (GenerarListado(Jefes.ToList()));
        }

        /* Competencia */
        public List<Competencia> ReadAllCompetencias()
        {
            /*List<Modelo.COMPETENCIA> CompetenciasBDD = CommonBC.ModeloWfbs.COMPETENCIA.ToList();
            return GenerarListadoCompetencia(CompetenciasBDD);*/

            var CompetenciasBDD = from c in CommonBC.ModeloWfbs.COMPETENCIA /*usuariosBDD*/

                                  select new Competencia
                                  {
                                      Id_com = c.ID_COMPETENCIA,
                                      Nombre = c.NOMBRE,
                                      Descripcion = c.DESCRIPCION,
                                      Sigla = c.SIGLA,
                                      Obs = (c.OBSOLETA == 0 ? "No" : c.OBSOLETA == 1 ? "Si" : "No determinado"),
                                      Nivel_O = c.NIVEL_OPTIMO_ESPERADO
                                  };
            return CompetenciasBDD.ToList();
        }

        private List<Controlador.Competencia> GenerarListadoCompetencia(List<Modelo.COMPETENCIA> CompetenciaBDD)
        {
            List<Controlador.Competencia> competenciasController = new List<Competencia>();

            foreach (Modelo.COMPETENCIA item in CompetenciaBDD)
            {
                Controlador.Competencia com = new Competencia();

                com.Id_competencia = Convert.ToInt32(item.ID_COMPETENCIA);
                com.Nombre = item.NOMBRE;
                com.Descripcion = item.DESCRIPCION;
                com.Sigla = item.SIGLA;
                com.Obsoleta = Convert.ToInt32(item.OBSOLETA);
                com.Nivel_Optimo = Convert.ToInt32(item.NIVEL_OPTIMO_ESPERADO);

                competenciasController.Add(com);
            }

            return competenciasController;
        }

        /* Nivel */
        public List<Nivel> ReadAllNiveles()
        {
            List<Modelo.NIVEL> nivelesBDD = CommonBC.ModeloWfbs.NIVEL.ToList();
            return GenerarListado(nivelesBDD);
        }

        private List<Controlador.Nivel> GenerarListado(List<Modelo.NIVEL> nivelesBDD)
        {
            List<Controlador.Nivel> nivelesController = new List<Nivel>();

            foreach (Modelo.NIVEL item in nivelesBDD)
            {
                Controlador.Nivel nivel = new Nivel();

                nivel.nota_Encuesta = Convert.ToInt32(item.NOTA_ENCUESTA);
                nivel.Nombre = item.NOMBRE;

                nivelesController.Add(nivel);
            }

            return nivelesController;
        }

        public List<PeriodoEvaluacion> ReadAllPeriodos()
        {
            List<Modelo.PERIODO_EVALUACION> periodosBDD = CommonBC.ModeloWfbs.PERIODO_EVALUACION.ToList();
            return GenerarListadoPeriodos(periodosBDD);
        }

        private List<Controlador.PeriodoEvaluacion> GenerarListadoPeriodos(List<Modelo.PERIODO_EVALUACION> periodosBDD)
        {
            List<Controlador.PeriodoEvaluacion> periodosController = new List<PeriodoEvaluacion>();

            foreach (Modelo.PERIODO_EVALUACION item in periodosBDD)
            {
                Controlador.PeriodoEvaluacion ar = new PeriodoEvaluacion();

                ar.idPeriodo = Convert.ToInt32(item.ID_PERIODO_EVALUACION);
                ar.fechaInicio = item.FECHA_INICIO;
                ar.vigencia = Convert.ToInt32(item.VIGENCIA);
                ar.porcentajeE = Convert.ToInt32(item.PORCENTAJE_EVALUACION);
                ar.porcentajeAE = Convert.ToInt32(item.PORCENTAJE_AUTOEVALUACION);

                periodosController.Add(ar);
            }

            return periodosController;
        }


        /* Habilidad */
        public List<Habilidad> ReadAllHabilidades()
        {
            List<Modelo.HABILIDAD> habilidadesBDD = CommonBC.ModeloWfbs.HABILIDAD.ToList();
            return GenerarListado(habilidadesBDD);
        }

        private List<Controlador.Habilidad> GenerarListado(List<Modelo.HABILIDAD> habilidadesBDD)
        {
            List<Controlador.Habilidad> habilidadesController = new List<Habilidad>();

            foreach (Modelo.HABILIDAD item in habilidadesBDD)
            {
                Controlador.Habilidad hab = new Habilidad();

                hab.Id_Habilidad = Convert.ToInt32(item.ID_HABILIDAD);
                hab.Id_Competencia = Convert.ToInt32(item.ID_COMPETENCIA);
                hab.Nombre = item.NOMBRE;
                hab.Nota_Encuesta = Convert.ToInt32(item.NOTA_ENCUESTA);

                habilidadesController.Add(hab);
            }

            return habilidadesController;

        }

        public List<Habilidad> ObtenerHabPorCom(int id)
        {
            var habilidad = CommonBC.ModeloWfbs.HABILIDAD.Where(h => h.ID_COMPETENCIA == id);
            return (GenerarListado(habilidad.ToList()));
        }

    }
}
