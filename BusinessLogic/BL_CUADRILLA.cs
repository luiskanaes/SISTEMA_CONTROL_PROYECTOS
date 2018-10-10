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
    public class BL_CUADRILLA
    {
        public DataTable SP_LISTAR_CUADRILLA_OBRERO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_CUADRILLA().SP_LISTAR_CUADRILLA_OBRERO(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA(string IDE_CECOS, int IDE_EMPRESA, string CAPATAZ , string FECHA)
        {
            try
            {
                return new DA_CUADRILLA().SP_OBTENER_CUADRILLA_X_FECHA(IDE_CECOS, IDE_EMPRESA, CAPATAZ, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
