﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_PERSONAL
    {
        private int m_IDE_PERSONAL;
        public int IDE_PERSONAL
        {
            get { return m_IDE_PERSONAL; }
            set { m_IDE_PERSONAL = value; }
        }
        private string m_CENTRO_COSTO;
        public string CENTRO_COSTO
        {
            get { return m_CENTRO_COSTO; }
            set { m_CENTRO_COSTO = value; }
        }
        private string m_NOMBRES;
        public string NOMBRES
        {
            get { return m_NOMBRES; }
            set { m_NOMBRES = value; }
        }
        private string m_APELLIDO_PATERNO;
        public string APELLIDO_PATERNO
        {
            get { return m_APELLIDO_PATERNO; }
            set { m_APELLIDO_PATERNO = value; }
        }
        private string m_APELLIDO_MATERNO;
        public string APELLIDO_MATERNO
        {
            get { return m_APELLIDO_MATERNO; }
            set { m_APELLIDO_MATERNO = value; }
        }
        private string m_DOCUMENTO_IDENTIFICACION;
        public string DOCUMENTO_IDENTIFICACION
        {
            get { return m_DOCUMENTO_IDENTIFICACION; }
            set { m_DOCUMENTO_IDENTIFICACION = value; }
        }
        private string m_TIPO_TRABAJADOR;
        public string TIPO_TRABAJADOR
        {
            get { return m_TIPO_TRABAJADOR; }
            set { m_TIPO_TRABAJADOR = value; }
        }
        private string m_ID_CATEGORIA;
        public string ID_CATEGORIA
        {
            get { return m_ID_CATEGORIA; }
            set { m_ID_CATEGORIA = value; }
        }
        private string m_ID_ESPECIALIDAD;
        public string ID_ESPECIALIDAD
        {
            get { return m_ID_ESPECIALIDAD; }
            set { m_ID_ESPECIALIDAD = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_IDE_CECOS;
        public string IDE_CECOS
        {
            get { return m_IDE_CECOS; }
            set { m_IDE_CECOS = value; }
        }
        private Boolean  m_FLG_ESTADOS;
        public Boolean FLG_ESTADOS
        {
            get { return m_FLG_ESTADOS; }
            set { m_FLG_ESTADOS = value; }
        }
        private string m_IDE_CAPATAZ;
        public string IDE_CAPATAZ
        {
            get { return m_IDE_CAPATAZ; }
            set { m_IDE_CAPATAZ = value; }
        }
        private int m_FLG_LIBRE;
        public int FLG_LIBRE
        {
            get { return m_FLG_LIBRE; }
            set { m_FLG_LIBRE = value; }
        }

        private string m_FECHA;
        public string FECHA
        {
            get { return m_FECHA; }
            set { m_FECHA = value; }
        }
        private int m_IDE_GRUPO;
        public int IDE_GRUPO
        {
            get { return m_IDE_GRUPO; }
            set { m_IDE_GRUPO = value; }
        }
        private string m_FECHA_INGRESO;
        public string FECHA_INGRESO
        {
            get { return m_FECHA_INGRESO; }
            set { m_FECHA_INGRESO = value; }
        }
    }
}
