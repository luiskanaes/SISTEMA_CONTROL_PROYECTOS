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
    public class DA_ASIGNACION_TAREO
    {
        Util oUtilitarios = new Util();
        public int Mant_Insert_Tareo(BE_ASIGNACION_TAREO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREO_ASIGNACION ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CECOS   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_ANIO  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_MES  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_SEM  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_PROYECTO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FEC_TAREO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CLIENTE  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_UBICACIONES   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ESTADO   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TURNO    ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRE_DIA     ,tgSQLFieldType.TEXT ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ASIGNACION_TAREO", Parametros));
        }
        public int Mant_Insert_TareasActividades(BE_ASIGNACION_TAREAS oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREO_ASIGNACION ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ITEM_ACTIVIDAD   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ACTIVIDAD  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DET_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_FRENTE  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CTA_COSTO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_UNIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORA_INICIO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORA_FIN   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PROGRAMADO   ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ESTADO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.OBSERVACIONES   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_AREAS    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_INGCAMPO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CAPATAZ    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.RETRABAJO    ,tgSQLFieldType.BOOLEAN  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_ACTIVIDAD    ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_FRENTE    ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PK_TAREA     ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_DISCIPLINA     ,tgSQLFieldType.NUMERIC  ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ASIGNACION_TAREAS", Parametros));
        }
        public DataTable Get_Listar_TareoFecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREO_POR_FECHA", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
        }
        public DataTable CerrarTareo_fecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, int ESTADO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREO_PROCESAR", IDE_EMPRESA, IDE_CECOS, FEC_TAREO, ESTADO );
        }
        public int Mant_Insert_Estructura(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_INSUMO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESTRUCTURA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_TAREO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO  ,tgSQLFieldType.TEXT ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_M_ESTRUCTURA_INSUMO", Parametros));
        }
        public int Mant_Insert_Estructura_ING(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_INSUMO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESTRUCTURA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_TAREO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PK_TAREA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_INGENIERO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA  ,tgSQLFieldType.TEXT ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_M_ESTRUCTURA_INSUMO_ING", Parametros));
        }
        public DataTable SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC( string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC", IDE_CECOS, FEC_TAREO);
        }
    }
}
