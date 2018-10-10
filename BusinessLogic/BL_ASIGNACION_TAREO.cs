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
    public  class BL_ASIGNACION_TAREO
    {
        public int Mant_Insert_Tareo(BE_ASIGNACION_TAREO oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_Tareo(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_TareasActividades(BE_ASIGNACION_TAREAS oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_TareasActividades(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_TareoFecha(int IDE_EMPRESA , string IDE_CECOS , string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Get_Listar_TareoFecha(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CerrarTareo_fecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, int ESTADO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().CerrarTareo_fecha(IDE_EMPRESA, IDE_CECOS, FEC_TAREO, ESTADO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC(string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC( IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
