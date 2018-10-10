using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Conexion;
using System.Configuration;



namespace DataAccess
{
    public class DA_TAREO_EMPLEADO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();

        public DataTable SP_CONSULTAR_EMPLEADOS(string IDE_EMPRESA, string mes, string anio)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_EMPLEADOS", IDE_EMPRESA,mes,anio );

        }

        public DataTable SP_CONSULTAR_UBICACIONES(string ID_USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_UBICACION", ID_USUARIO);

        }

        public DataTable SP_VERIFICAR_ESTADO_TAREOEMP(string IDE_EMPRESA, string mes, string anio)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_ESTADO_TAREOEMP", IDE_EMPRESA, mes, anio);

        }

        public DataTable SP_CONSULTAR_JUNTA(  string junta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_JUNTA",  junta);

        }
        public DataTable SP_GRABAR_JUNTA(string junta, string juntan, string area, string serv, string line, string train)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_JUNTA", junta, juntan, area, serv, line, train);

        }
        public DataTable SP_GRABAR_JUNTA_NUEVA(string junta, string juntan, string area, string serv, string line, string train, string matc, string joint)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_JUNTA_NUEVA", junta, juntan, area, serv, line, train,matc,joint);

        }
        
    }
}
