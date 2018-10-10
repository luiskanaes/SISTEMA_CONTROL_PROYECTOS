using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DataAccess.Conexion;

namespace DataAccess
{
    public class DA_CUADRILLA
    {
        Util oUtilitarios = new Util();

        public DataTable SP_LISTAR_CUADRILLA_OBRERO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_LISTAR_CUADRILLA_OBRERO", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA(string IDE_CECOS, int IDE_EMPRESA, string CAPATAZ, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_CUADRILLA_X_FECHA", IDE_CECOS, IDE_EMPRESA, CAPATAZ, FECHA);
        }
    }
}
