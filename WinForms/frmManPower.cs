﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using Microsoft.Reporting.WinForms;
using UserCode;
namespace WinForms
{
    public partial class frmManPower : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
       
        public frmManPower()
        {
            InitializeComponent();
            ListarEmpresa();
            this.ReportViewer1.RefreshReport();
        }

        private void frmManPower_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
        }
        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
                ListarCesos();
            }
        }
        protected void ListarCesos()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarCesosPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, Convert.ToInt32(cboEmpresa.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultado;

            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            rpt_Cuadro();
        }
        protected void rpt_Cuadro()
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData();
            DataTable dsEstadoDiario= GetDataESTADOS();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers);
            ReportDataSource datasourceEstado = new ReportDataSource("DataSet2", dsEstadoDiario);
            if (dsCustomers.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasourceEstado);
                ReportViewer1.RefreshReport();
                ReportViewer1.Show();
            }
            else
            {
                ReportViewer1.Visible = false;
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspRPT_JORNADA_FERIADOS_CENTRO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ANIO", SqlDbType.Int).Value = Convert.ToInt32(dateTimePicker1.Value.Date.ToString("yyyy"));
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = Convert.ToInt32(dateTimePicker2.Value.Date.ToString("MM")); 
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private DataTable GetDataESTADOS()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspRPT_PERSONAL_ESTADO_DIARO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ANIO", SqlDbType.Int).Value = Convert.ToInt32(dateTimePicker1.Value.Date.ToString("yyyy"));
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = Convert.ToInt32(dateTimePicker2.Value.Date.ToString("MM"));
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }
}
