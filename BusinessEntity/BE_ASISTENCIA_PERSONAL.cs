using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_ASISTENCIA_PERSONAL
    {
        private int m_IDE_ASISTENCIA;
        public int IDE_ASISTENCIA
        {
            get { return m_IDE_ASISTENCIA; }
            set { m_IDE_ASISTENCIA = value; }
        }
        private string m_IDE_PERSONAL;
        public string IDE_PERSONAL
        {
            get { return m_IDE_PERSONAL; }
            set { m_IDE_PERSONAL = value; }
        }
        private string m_FEC_ASISTENCIA;
        public string FEC_ASISTENCIA
        {
            get { return m_FEC_ASISTENCIA; }
            set { m_FEC_ASISTENCIA = value; }
        }
        private string m_IDE_ESTADO;
        public string IDE_ESTADO
        {
            get { return m_IDE_ESTADO; }
            set { m_IDE_ESTADO = value; }
        }
        private string m_CCENTRO;
        public string CCENTRO
        {
            get { return m_CCENTRO; }
            set { m_CCENTRO = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_FECHA_REGISTRO;
        public string FECHA_REGISTRO
        {
            get { return m_FECHA_REGISTRO; }
            set { m_FECHA_REGISTRO = value; }
        }
        private string m_USUARIO_REGISTRA;
        public string USUARIO_REGISTRA
        {
            get { return m_USUARIO_REGISTRA; }
            set { m_USUARIO_REGISTRA = value; }
        }
        private string m_ESTADO_DIARIO;
        public string ESTADO_DIARIO
        {
            get { return m_ESTADO_DIARIO; }
            set { m_ESTADO_DIARIO = value; }
        }
        private string m_SUPERVISOR;
        public string SUPERVISOR
        {
            get { return m_SUPERVISOR; }
            set { m_SUPERVISOR = value; }
        }
    }
}
