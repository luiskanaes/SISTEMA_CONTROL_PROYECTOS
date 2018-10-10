using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using BusinessEntity;
using UserCode;
using System.Data.SqlClient;
using DataAccess.Conexion;
namespace DataAccess
{
    public  class DA_CECOS
    {
        //CONEXION BASE DE DATOS CGO
        UtilCGO oUtilitarios = new UtilCGO();
        public DataTable SEL_CECOS_POR_CATEGORIA_EMPRESA(string categoria, string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_POR_CATEGORIA_EMPRESA", categoria,  ip);
        }
        public DataTable uspDELETE_LOG_SOLPED_USER_REGISTRO( string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDELETE_LOG_SOLPED_USER_REGISTRO",  ip);
        }
        public DataTable uspCONSULTAR_LOG_SOLPED_USER(string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspCONSULTAR_LOG_SOLPED_USER", ip);
        }
        public DataTable SEL_CECOS_CENTRO_LOGISTICO(string sociedad,string imputacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_CENTRO_LOGISTICO", sociedad, imputacion);
        }
        public DataTable SEL_GRUPO_COMPRAS( string obra)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_GRUPO_COMPRAS", obra);
        }
        public DataTable uspSEL_CECOS_RRHH( int empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS", empresa);
        }
        public DataTable USP_EMPRESAS()
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_EMPRESAS");
        }
    }
}
