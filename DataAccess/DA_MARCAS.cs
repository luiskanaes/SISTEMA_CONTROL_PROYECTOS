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
 public   class DA_MARCAS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();

        public DataTable SP_CONSULTAR_DATOS(string ceco, string unit, string line, string train,  string servicio, string finicio, string ffin, string indfecha, string iv, string filtro, string txtfiltro, string indValidos,string indValidosProgramar)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS", ceco,unit,line,train,servicio, finicio, ffin, indfecha,iv, filtro,txtfiltro,indValidos, indValidosProgramar);
        }
        public DataTable SP_CONSULTAR_COLUMNAS_ANTES(string col_1, string col_x)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_ANTES", col_1, col_x);
        }
        public DataTable SP_CONSULTAR_COLUMNAS_ANTES_SPOOL(string col_1, string col_x)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_ANTES_SPOOL", col_1, col_x);
        }

        public DataTable SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES(string ceco, string cboFiltro, string txtFiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES", ceco,cboFiltro,txtFiltro);
        }
        public DataTable SP_CONSULTAR_REPORTES(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES", nombrereporte);
        }

        public DataTable SP_CONSULTAR_REPORTES_CS(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES_CS", nombrereporte);
        }
        public DataTable SP_CONSULTAR_REPORTES_SPOOL(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES_SPOOL", nombrereporte);
        }

        public DataTable SP_CONSULTAR_DATOS_SPOOL(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SPOOL", ceco, unit, line, train, servicio,filtro,txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_ALMACEN(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_ALMACEN", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_SERIVICIO_PINTURA(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERIVICIO_PINTURA", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_SERVICIO_TRACEADO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERVICIO_TRACEADO", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        
        public DataTable SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        
        public DataTable SP_CONSULTAR_DATOS_AVANCE(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_AVANCE", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        
        public DataTable SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES(string ceco, string unit, string line, string train, string servicio, string conIv, string conRtrat, string tipEnsayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES", ceco, unit, line, train, servicio, conIv, conRtrat, tipEnsayo);
        }
        
        public DataTable SP_CONSULTAR_DATOS_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_REGISTRO_JUNTAS", ceco, unit, line, train,servicio);
        }
        public DataTable SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string tipo_ensayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS", ceco, unit, line, train, servicio, filtro, txtfiltro, tipo_ensayo); 
        }
        
        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio, string nrojunta)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS", ceco, unit, line, train, servicio, nrojunta);
        }
        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio, string nrojunta , string nuevajunta, string tipoJunta, string ubicacion)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS", ceco, unit, line, train, servicio, nrojunta, nuevajunta,tipoJunta,ubicacion);
        }
        public DataTable SP_GRABAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nrojunta, string nuevajunta, string tipoJunta, string ubicacion, string diametro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_DATOS_NUEVO_JUNTA", ceco, unit, line, train, servicio, nrojunta, nuevajunta,tipoJunta,ubicacion, diametro);
        }
        public DataTable SP_VERIFICAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nrojunta, string nuevajunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_DATOS_NUEVO_JUNTA", ceco, unit, line, train, servicio, nrojunta, nuevajunta);
        }
        
        public DataTable SP_CONSULTAR_COLUMNAS_EDITABLES(string ceco, string USUARIO)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_EDITABLES", ceco, USUARIO);

        }
        public DataTable SP_CONSULTAR_COLUMNAS_VISIBLES(string ceco, string USUARIO)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_VISIBLES", ceco, USUARIO);
        }

        public DataTable SP_GUARDAR_DATOS(string ceco, string id)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS", ceco, id);
        }

        public DataTable SP_GUARDAR_COLUMNAS(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_COLUMNAS",col,  id);
        }

        public DataTable SP_GUARDAR_COLUMNAS_SPOOL(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_COLUMNAS_SPOOL", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ALMACEN(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ALMACEN", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO", col, id);
        }

        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO", col, id);
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_AVANCE(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_AVANCE", col, id);
        }
        
        public DataTable SP_GUARDAR_DATOS_PAQUETES_PRUEBA(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_PAQUETES_PRUEBA", ceco, id);
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_JUNTAS(string ceco, string id)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_JUNTAS", ceco, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS(string ceco, string id, string tipo_ensayo, string col_e)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_v2", ceco, id,tipo_ensayo,col_e);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES", ceco, id);
        }       

        public DataTable SP_GUARDAR_DATOS_REGISTRO_SPOOLS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SPOOLS", ceco, id);
        }
        

        public DataTable SP_GUARDAR_DATOS_IV(string ceco, string id)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_IV", ceco, id);
        }
        public DataTable SP_GUARDAR_DATOS_REPORTE_SOLDADURAS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REPORTE_SOLDADURAS", ceco, id);
        }       

        public DataTable SP_REPORTE_SOLDADURAS(string unit, string service,  string line, string train,string dtpInicio, string dtpFin, string dtpInicioIV, string dtpFinIV, string dtpInicioReporte, string dtpFinReporte, string chkSinFechaSoldadura, string chkSinFechaIV, string chkSinFechaReporte)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_SOLDADURAS",  unit, service, line, train,dtpInicio,dtpFin, dtpInicioIV, dtpFinIV, dtpInicioReporte, dtpFinReporte, chkSinFechaSoldadura, chkSinFechaIV, chkSinFechaReporte); 
        }

        public DataTable SP_REPORTE_IV(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio, string pendientes, string sfecha)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_IV", unit, line, train, dtpInicio, dtpFin,servicio,pendientes, sfecha);
        }

        public DataTable SP_REPORTE_IV_EXPORTAR(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio, string pendientes, string sfecha)
        {
        return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_IV_EXPORTAR", unit, line, train, dtpInicio, dtpFin, servicio, pendientes,sfecha);
        }

        public DataTable SP_REPORTE_PIP35(string unidad, string tipojunta, string tipoensayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_PIP35", unidad , tipojunta, tipoensayo);
        }

        public DataTable SP_CONSULTAR_FILTROS(string unidad)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FILTROS", unidad);
        }
        public DataTable SP_CONSULTAR_FILTROS_SPOOL(string unidad)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FILTROS_SPOOL", unidad);
        }

        
        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA(string ceco, string unit, string line, string train, string servicio,string paquete, string filtro, string txtfiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PAQUETES_PRUEBA", ceco, unit, line, train, servicio, paquete, filtro, txtfiltro);
        }


        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR(string ceco, string unit, string line, string train, string servicio, string paquete, string filtro, string txtfiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR", ceco, unit, line, train, servicio, paquete, filtro, txtfiltro);
        }

        public DataTable SP_CONSULTAR_DOCUMENTOS_JUNTA(string junta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DOCUMENTOS_JUNTA", junta);
        }

        public DataTable SP_CONSULTAR_COLUMNAS_PIP35()
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_PIP35");
        }
        public DataTable SP_CONSULTAR_COLUMNAS_SPOOLS()
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_SPOOLS");
        }        
        public DataTable SP_GRABAR_NUEVO_ISOMETRICO(string junta, string unidad, string servicio, string line, string train)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_NUEVO_ISOMETRICO",junta,unidad,servicio,line,train);
        }
        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS(string ceco, string unit, string line, string train, string servicio, string nrojunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS", ceco, unit, line, train, servicio, nrojunta);
        }

        public DataTable SP_VERIFICAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio , string nuevajunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_DATOS_NUEVO_SPOOL", ceco, unit, line, train, servicio, nuevajunta);
        }

        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL", ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
        }

        public DataTable SP_GRABAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_DATOS_NUEVO_SPOOL", ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
        }
        public DataTable SP_CONSULTAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_TESTPACK", ceco,   unit,   servicio,   line,   train,   tp);
        }
        public DataTable SP_ACTUALIZAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp, string estado, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_TESTPACK", ceco, unit, servicio, line, train, tp,estado, fecha);
        }
        

    }
}
