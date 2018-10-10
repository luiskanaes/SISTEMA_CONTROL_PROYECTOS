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
    public class BL_TAREO_EMPLEADO
    {

        public DataTable SP_CONSULTAR_EMPLEADOS(string IDE_EMPRESA, string mes, string anio)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_EMPLEADOS("",mes,anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_UBICACIONES(string id_usuario)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_UBICACIONES(id_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_VERIFICAR_ESTADO_TAREOEMP(string IDE_EMPRESA, string mes, string anio)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_VERIFICAR_ESTADO_TAREOEMP("", mes, anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_JUNTA(  string junta)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_JUNTA(junta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GRABAR_JUNTA(string junta, string juntan, string area, string serv, string line, string train)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_GRABAR_JUNTA(junta, juntan, area, serv, line, train);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GRABAR_JUNTA_NUEVA(string junta, string juntan, string area, string serv, string line, string train, string matc, string joint)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_GRABAR_JUNTA_NUEVA(junta, juntan, area, serv, line, train,matc,joint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


    }
}
