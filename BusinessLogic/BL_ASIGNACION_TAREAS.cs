using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UserCode;
using System.Web;

namespace BusinessLogic
{
   public class BL_ASIGNACION_TAREAS
    {
        public DataTable Listar_ActividadAsignadas(string  IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ, string IDE_INGCAMPO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Listar_ActividadAsignadas(IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(string IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ, string IDE_INGCAMPO, int disciplina)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO, disciplina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string  ID_CATEGORIA, string IDE_CAPATAZ)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Listar_PersonalCategoria(P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable EliminarTareas(int id)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_EliminarTareas(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConsultarTareasRealizadas(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_ConsultarTareasRealizadas(IDE_EMPRESA,  IDE_CECOS,  FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable obtener_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string  ID_CATEGORIA, string IDE_CAPATAZ, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_obtener_PersonalCategoria(P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PERSONAL_TODO_X_FECHA(string P_PROYECTO, int IDE_EMPRESA, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PERSONAL_TODO_X_FECHA(P_PROYECTO, IDE_EMPRESA,  FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PLANILLA_PERSONAL_OBRERO(string P_PROYECTO, int IDE_EMPRESA, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PLANILLA_PERSONAL_OBRERO(P_PROYECTO, IDE_EMPRESA, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Tareo_x_persona(string centro, int empresa, string fecha, string personal, string capataz)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Tareo_x_persona(centro, empresa, fecha, personal, capataz );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Lista_Personal_tareas_x_fecha(string P_PROYECTO, int IDE_EMPRESA, string IDE_CAPATAZ, string FECHA,string dateString)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Lista_Personal_tareas_x_fecha(P_PROYECTO, IDE_EMPRESA, IDE_CAPATAZ, FECHA, dateString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable OBTENER_PERSONAL_RESPONSABLES_TAREO(string P_PROYECTO, int IDE_EMPRESA,string FECHA, int Tipo, string Ide_personal)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().OBTENER_PERSONAL_RESPONSABLES_TAREO(P_PROYECTO, IDE_EMPRESA, FECHA, Tipo, Ide_personal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(string P_PROYECTO,  string FECHA,string CAPATAZ )
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(P_PROYECTO, FECHA, CAPATAZ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA(string P_PROYECTO, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA(P_PROYECTO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_ASIGNACION_TAREAS_FECHA_ING(string IDE_EMPRESA, string IDE_CECOS,  string FEC_TAREO,string IDE_INGCAMPO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_ASIGNACION_TAREAS_FECHA_ING(IDE_EMPRESA, IDE_CECOS, FEC_TAREO, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_ASIGNACION_TAREAS> f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(BE_ASIGNACION_TAREAS obj)
        {
            return new DA_ASIGNACION_TAREAS().f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(obj);
        }
        public DataTable LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO( string IDE_CECOS, string CODIGO_AREA, int IDE_DISCIPLINA, string DET_TAREA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO(IDE_CECOS, CODIGO_AREA, IDE_DISCIPLINA, DET_TAREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
