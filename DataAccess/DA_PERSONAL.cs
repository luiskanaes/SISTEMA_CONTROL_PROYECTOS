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
    public class DA_PERSONAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public DataTable Get_Listar_disponibilidadPersonal(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_POR_DISPONIBILIDAD", obj.FLG_LIBRE , obj.IDE_CAPATAZ, obj.IDE_EMPRESA , obj.CENTRO_COSTO , obj.FECHA );
        }
        public DataTable Get_Listar_PersonalCC(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_CC", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.TIPO_TRABAJADOR );
        }
        public DataTable Get_Listar_Personal_Estados(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_ESTADO", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.TIPO_TRABAJADOR, obj.FLG_ESTADOS );
        }
        public DataTable Get_Listar_PersonalGrupo(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_GRUPO", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.IDE_GRUPO );
        }
        public DataTable Get_AsignarPersonal(string centro, int idPersona, int empresa, int estado, string capataz,string  ingeniero, string fecha )
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ASIGNAR_PERSONAL", centro, idPersona, empresa, estado, capataz,ingeniero, fecha);
        }
        public DataTable Get_AsignarPersonal_DNI(string centro, string  idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ASIGNAR_PERSONAL_DNI", centro, idPersona, empresa, estado, capataz, ingeniero, fecha);
        }
        public int Mant_Insert_Trabajadores_WCF(BE_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRES ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_PATERNO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_MATERNO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DOCUMENTO_IDENTIFICACION  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_TRABAJADOR  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_INGRESO  ,tgSQLFieldType.TEXT ),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspWCF_INS_PERSONAL", Parametros));
        }
        public int Mant_Insert_Trabajadores_WCF_DNI(BE_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRES ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_PATERNO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_MATERNO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DOCUMENTO_IDENTIFICACION  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_TRABAJADOR  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_INGRESO  ,tgSQLFieldType.TEXT ),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspWCF_INS_PERSONAL_DNI", Parametros));
        }
        public DataTable UpdateCategoria(int idPersona, int categoria, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_CATEGORIA", idPersona, categoria, centro);
        }
        public DataTable Get_Listar_Personal_x_Categoria(string Centro, int empresa, string grupo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_CATEGORIA_GRUPO", Centro, empresa , grupo);
        }
        public DataTable AsignarResponsable(string  idPersona, string ingeniero, int tipo, int empresa, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_ENCARGADO", idPersona, ingeniero, tipo, empresa, centro);
        }
        public DataTable Update_EstadoPersonal( int empresa, string centro,string TipoPersona)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCF_UPD_PERSONAL_ESTADO", empresa, centro, TipoPersona);
        }
        public DataTable Get_UpdateEstadoPersonal(string centro, int idPersona, int empresa, int estado)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ESTADO_PERSONAL", centro, idPersona, empresa, estado);
        }
        public DataTable SP_OBTENER_PERSONAL(string Centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL", Centro);
        }
        public DataTable uspUPD_PERSONAL_CATEGORIA_CAMBIO(int idPersona, int idPersonaNuevo, int categoria, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_CATEGORIA_CAMBIO", idPersona, idPersonaNuevo,categoria, centro);
        }
    }
}
