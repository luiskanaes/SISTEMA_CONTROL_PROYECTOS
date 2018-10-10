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
    public class BL_MARCAS
    {

        public DataTable SP_CONSULTAR_DATOS(string ceco,string unit , string line, string train, string servicio, string indfecha, string finicio, string ffin, string iv, string filtro, string txtfiltro, string indValidos, string indValidosProgramar)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS(ceco,unit,line,train,servicio,indfecha,finicio,ffin,iv, filtro, txtfiltro,indValidos, indValidosProgramar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_COLUMNAS_ANTES(string col_1, string col_x)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_ANTES(col_1, col_x);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_COLUMNAS_ANTES_SPOOL(string col_1, string col_x)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_ANTES_SPOOL(col_1, col_x);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_GUARDAR_COLUMNAS(string col ,string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_COLUMNAS(col,id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GUARDAR_COLUMNAS_SPOOL(string col, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_COLUMNAS_SPOOL(col, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES(string ceco,string cboFiltro, string txtFiltro)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES(ceco, cboFiltro, txtFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }         

        public DataTable SP_CONSULTAR_REPORTES(string nombrereporte)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_REPORTES(nombrereporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_REPORTES_CS(string nombrereporte)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_REPORTES_CS(nombrereporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_REPORTES_SPOOL(string nombrereporte)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_REPORTES_SPOOL(nombrereporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_DATOS_SPOOL (string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_SPOOL(ceco, unit, line, train, servicio,filtro,txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_DATOS_ALMACEN(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_ALMACEN(ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_DATOS_SERIVICIO_PINTURA(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_SERIVICIO_PINTURA(ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_DATOS_SERVICIO_TRACEADO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_SERVICIO_TRACEADO(ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO(ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public DataTable SP_CONSULTAR_DATOS_AVANCE(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_AVANCE(ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES(string ceco, string unit, string line, string train, string servicio, string conIv, string conRtrat, string tipEnsayo)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES(ceco, unit, line, train, servicio,conIv,conRtrat,tipEnsayo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_CONSULTAR_DATOS_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_REGISTRO_JUNTAS(ceco, unit, line, train, servicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro,string tipo_ensayo)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS(ceco, unit, line, train, servicio,filtro,txtfiltro,tipo_ensayo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio,string nroJunta)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS(ceco, unit, line, train, servicio,nroJunta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio, string nroJunta, string nuevajunta, string tipoJunta, string ubicacion)
        {
            try
            {
                return new DA_MARCAS().SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS(ceco, unit, line, train, servicio, nroJunta, nuevajunta, tipoJunta, ubicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GRABAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nroJunta, string nuevajunta, string tipoJunta, string ubicacion, string diametro)
        {
            try
            {
                return new DA_MARCAS().SP_GRABAR_DATOS_NUEVO_JUNTA(ceco, unit, line, train, servicio, nroJunta, nuevajunta,tipoJunta,ubicacion, diametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VERIFICAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nroJunta, string nuevajunta)
        {
            try
            {
                return new DA_MARCAS().SP_VERIFICAR_DATOS_NUEVO_JUNTA(ceco, unit, line, train, servicio, nroJunta, nuevajunta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public DataTable SP_CONSULTAR_COLUMNAS_EDITABLES(string ceco, string USUARIO)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_EDITABLES(ceco,USUARIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_COLUMNAS_VISIBLES(string ceco, string USUARIO)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_VISIBLES(ceco, USUARIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public DataTable SP_GUARDAR_DATOS(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GUARDAR_DATOS_PAQUETES_PRUEBA(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_PAQUETES_PRUEBA(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GUARDAR_DATOS_REPORTE_SOLDADURAS(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REPORTE_SOLDADURAS(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_JUNTAS(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_JUNTAS(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ALMACEN(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_ALMACEN(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GUARDAR_DATOS_REGISTRO_AVANCE(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_AVANCE(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS(string ceco, string id, string tipo_ensayo, string col_e)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_ENSAYOS(ceco, id, tipo_ensayo,col_e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SPOOLS(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_REGISTRO_SPOOLS(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GUARDAR_DATOS_IV(string ceco, string id)
        {
            try
            {
                return new DA_MARCAS().SP_GUARDAR_DATOS_IV(ceco, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        



        public DataTable SP_REPORTE_SOLDADURAS(string unit, string service, string line, string train, string dtpInicio , string dtpFin, string dtpInicioIV, string dtpFinIV, string dtpInicioReporte, string dtpFinReporte, string chkSinFechaSoldadura, string chkSinFechaIV, string chkSinFechaReporte)
        {
            try
            {
                return new DA_MARCAS().SP_REPORTE_SOLDADURAS(unit, service , line, train,dtpInicio, dtpFin,dtpInicioIV, dtpFinIV, dtpInicioReporte, dtpFinReporte, chkSinFechaSoldadura, chkSinFechaIV, chkSinFechaReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_REPORTE_IV(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio , string pendientes, string sfecha)
        {
            try
            {
                return new DA_MARCAS().SP_REPORTE_IV(unit, line, train, dtpInicio, dtpFin, servicio, pendientes,sfecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_REPORTE_IV_EXPORTAR(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio, string pendientes, string sfecha)
        {
            try
            {
                return new DA_MARCAS().SP_REPORTE_IV_EXPORTAR(unit, line, train, dtpInicio, dtpFin, servicio, pendientes,sfecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_REPORTE_PIP35(string unidad, string tipojunta, string tipoensayo)
        {
            try
            {
                return new DA_MARCAS().SP_REPORTE_PIP35(unidad, tipojunta, tipoensayo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_FILTROS(string unidad)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_FILTROS(unidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_FILTROS_SPOOL(string unidad)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_FILTROS_SPOOL(unidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA(string ceco, string unit, string line, string train, string servicio, string paquete ,string filtro, string txtfiltro)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_PAQUETES_PRUEBA(ceco, unit, line, train, servicio, paquete, filtro,txtfiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR(string ceco, string unit, string line, string train, string servicio, string paquete, string filtro, string txtfiltro)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR(ceco, unit, line, train, servicio, paquete, filtro, txtfiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_DOCUMENTOS_JUNTA(string junta)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DOCUMENTOS_JUNTA(junta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_COLUMNAS_PIP35()
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_PIP35();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_COLUMNAS_SPOOLS()
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_COLUMNAS_SPOOLS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable SP_GRABAR_NUEVO_ISOMETRICO(string junta, string unidad, string servicio, string line, string train)
        {
            try
            {
                return new DA_MARCAS().SP_GRABAR_NUEVO_ISOMETRICO(junta,unidad,servicio,line,train);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS(string ceco, string unit, string line, string train, string servicio, string nroJunta)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS(ceco, unit, line, train, servicio, nroJunta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_VERIFICAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio , string nuevajunta)
        {
            try
            {
                return new DA_MARCAS().SP_VERIFICAR_DATOS_NUEVO_SPOOL(ceco, unit, line, train, servicio, nuevajunta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            try
            {
                return new DA_MARCAS().SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL(ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GRABAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            try
            {
                return new DA_MARCAS().SP_GRABAR_DATOS_NUEVO_SPOOL(ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp)
        {
            try
            {
                return new DA_MARCAS().SP_CONSULTAR_TESTPACK(  ceco,   unit,   servicio,   line,   train,   tp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_ACTUALIZAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp, string estado, string fecha)
        {
            try
            {
                return new DA_MARCAS().SP_ACTUALIZAR_TESTPACK(ceco, unit, servicio, line, train, tp,estado, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
