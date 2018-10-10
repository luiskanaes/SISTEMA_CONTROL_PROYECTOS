﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;
//using MetroFramework.Forms;
namespace WinForms
{
    public partial class frmControlTareo : Form
    {
        AutoCompleteStringCollection DataFrente = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataActividades = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataTarea = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataAreas = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataEstadiDiario = new AutoCompleteStringCollection();
        bool bKeyPressNum_GV_DATA = false;
        DataTable dsBonificacion = new DataTable();
        DataTable dsActividad = new DataTable();
        DataTable dtAreas = new DataTable();
        public static BE_ASIGNACION_TAREO obj_Tareo_E;
        public static BE_ASIGNACION_TAREAS obj_Tareas_E;
        private static List<BE_CABECERA> LstActividades = new List<BE_CABECERA>();
        private static List<BE_CABECERA> LstActividadesNro = new List<BE_CABECERA>();
        private static List<BE_TBPARAMETROS> LstAREAS = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstBonificacion = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstEstadoDiario = new List<BE_TBPARAMETROS>();

        int row;
        int col;
        int colTarea;
        int rowTarea;
        string MGridActividad = string.Empty;
        string MGridTareo = string.Empty;
        public static bool bSalir = false;
        double HoraMaxima = 24;
        double BonoMaxima = 24;
        decimal EstDiario = 0;// horas por dia de jornada
        string AsistenciaPersona;




        public frmControlTareo()
        {
            InitializeComponent();
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                btnGuardarActividad.BackColor = Color.FromArgb(62, 133, 195);

                btnGuardarTareo.BackColor = Color.FromArgb(62, 133, 195);
                btnGuardarTareo.ForeColor = Color.FromArgb(255, 255, 255);
                btnGuardarTareo.Font = new Font(btnGuardarTareo.Font.Name, btnGuardarTareo.Font.Size, FontStyle.Bold);
                //btnActividades.BackColor = Color.FromArgb(85, 176, 85);
                //btnActividades.ForeColor = Color.FromArgb(255,255,255);

                //VERDE
                //btnDigitacion.BackColor = Color.FromArgb(85, 176, 85);
                //btnDigitacion.ForeColor = Color.FromArgb(255, 255, 255);
                //btnDigitacion.Font = new Font(btnDigitacion.Font.Name, btnDigitacion.Font.Size, FontStyle.Bold);

                //Blanco
                btnListarCuadrilla.BackColor = Color.FromArgb(255, 255, 255);
                btnEstado.BackColor = Color.FromArgb(255, 255, 255);
                btnListarCuadrilla.BackColor = Color.FromArgb(255, 255, 255);
                btnActividades.BackColor = Color.FromArgb(255, 255, 255);
                btnDigitacion.BackColor = Color.FromArgb(255, 255, 255);
                btnConsultaPersona.BackColor = Color.FromArgb(255, 255, 255);
                btnPersonal.BackColor = Color.FromArgb(255, 255, 255);


                btnCuadrillaVarios.BackColor = Color.FromArgb(249, 39, 39);
                btnCuadrillaVarios.ForeColor = Color.FromArgb(255, 255, 255);
                btnCuadrillaVarios.Font = new Font(btnCuadrillaVarios.Font.Name, btnCuadrillaVarios.Font.Size, FontStyle.Bold);

                //btnPersonal.ForeColor = Color.FromArgb(255, 255, 255);
                //btnListarCuadrilla.Font = new Font(btnDigitacion.Font.Name, btnDigitacion.Font.Size, FontStyle.Bold);

                PeriodoAnio();
                ListarEmpresa();
                JornadasHoras();
                AreasSoporte();
                MGridActividad = string.Empty;
                MGridTareo = string.Empty;

                //btnActividades.Text = "Listar & Actividades";
                //btnGuardarActividad.Text = "Guardar &Tareas";
                //btnGuardarTareo.Text = "&Guardar Tareo";
                //btnPersonal.Text = "Agregar &Personal";
                //btnEstadoDiario.Text = "&Leyenda Asistencia";
                TipoDisciplina();
            }
            else
            {
                MessageBox.Show(ls_error);
            }
        }

        private void frmControlTareo_Load(object sender, EventArgs e)
        {

        }

        protected void ConsultarTareo()
        {

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();


            dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {

                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();
                lblEstado.Text = FLG_ESTADO;

                if (FLG_ESTADO == "0")
                {
                    btnGuardarActividad.Visible = false;
                    btnGuardarTareo.Visible = false;
                    //Keys.KeyCode.
                }
                else
                {
                    btnGuardarActividad.Visible = true;
                    btnGuardarTareo.Visible = true;
                }

            }
            else
            {
                lblEstado.Text = "1";
            }


        }
        protected void TipoDisciplina()
        {
            //BL_FUNCIONES obj = new BL_FUNCIONES();

            BL_DISCIPLINAS obj = new BL_DISCIPLINAS();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            //dtResultado = obj.SEL_DISCIPLINAS_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());
            dtResultado = obj.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());
            if (dtResultado.Rows.Count > 0)
            {

                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                workRow[0] = "0";
                workRow[1] = "--- SELECCIONAR  ---";
                dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_PARAMETRO"].ToString();
                    workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    dt.Rows.Add(workRow);
                }


                cboFile.ValueMember = "Codigo";
                cboFile.DisplayMember = "Descripcion";
                cboFile.DataSource = dt;
            }
        }
        protected void AreasSoporte()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            dtAreas = obj.ListarParametros("AREA_INCUMPLIMIENTO", "ID_AREA_INCUMPLIMIENTO");
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
        protected void JornadasHoras()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            string feriado;
            string dateString = dateTareo.Value.Date.ToString("dddd");
            dtResultado = obj.ListarHrasJorandas(dateTareo.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dddd"), cboCentroCosto.SelectedValue.ToString());
            if (dtResultado.Rows.Count > 0)
            {
                EstDiario = Convert.ToDecimal(dtResultado.Rows[0]["HORAS_TRABAJO"].ToString());
                feriado = dtResultado.Rows[0]["FERIADO"].ToString();
                if (feriado == "1")
                {
                    AsistenciaPersona = "F";
                }
                else
                {
                    AsistenciaPersona = string.Empty;
                }

            }
            else
            {
                AsistenciaPersona = string.Empty;
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
                //ListarIngenieros();
            }
        }
        protected void PeriodoAnio()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            //dtResultado = obj.ListarPeriodoFecha(1, anio, 1);

            dtResultado = obj.ListarPeriodoFecha_bd(1, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            if (dtResultado.Rows.Count > 0)
            {
                cboAnio.ValueMember = "COD";
                cboAnio.DisplayMember = "DESCRIPCION";
                cboAnio.DataSource = dtResultado;
                PeriodoMes();
            }
        }

        protected void PeriodoMes()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            //dtResultado = obj.ListarPeriodoFecha(2, Convert.ToInt32(cboAnio.SelectedValue), 1);
            dtResultado = obj.ListarPeriodoFecha_bd(2, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            if (dtResultado.Rows.Count > 0)
            {

                cboMes.ValueMember = "COD";
                cboMes.DisplayMember = "DESCRIPCION";
                cboMes.DataSource = dtResultado;
                PeriodoSemana();
            }
        }
        protected void PeriodoSemana()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();

            //dtResultado = obj.ListarPeriodoFecha(3, Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue));
            dtResultado = obj.ListarPeriodoFecha_bd(3, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            if (dtResultado.Rows.Count > 0)
            {
                cboSemana.ValueMember = "COD";
                cboSemana.DisplayMember = "DESCRIPCION";
                cboSemana.DataSource = dtResultado;
            }
        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodoMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodoSemana();
        }

        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        public void ActividadesProyectos()
        {
            BE_CABECERA objCab = new BE_CABECERA();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            DataActividades.Clear();
            dsActividad.Clear();
            LstActividades.Clear();

            objCab.TIPO = Convert.ToInt32(1);
            objCab.ID_PROYECTO = string.IsNullOrEmpty(cboCentroCosto.SelectedValue.ToString()) ? "0" : cboCentroCosto.SelectedValue.ToString();
            objCab.IDE_ACTIVIDAD = "1";
            objCab.ID_TAREA = "1";
            objCab.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            objCab.TIPO_ARCHIVO = cboFile.SelectedValue.ToString();
            dt = obj.Listar_ActividadTarea(1, cboCentroCosto.SelectedValue.ToString(), "1", "1", Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                dsActividad = obj.Listar_ActividadTarea(1, cboCentroCosto.SelectedValue.ToString(), "1", "1", Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue));
                LstActividades = new BL_CONTROL_AVANCE().f_list_TareProyecto(objCab);
                //if (DataActividades.Count <= 0)
                //{
                foreach (DataRow row in dt.Rows)
                {

                    DataActividades.Add(Convert.ToString(row["DESCRIPCION"]));
                }
                //}
            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                //DataActividades.Clear();
            }
        }
        public void AreasProyectos()
        {
            BE_TBPARAMETROS objCab = new BE_TBPARAMETROS();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            DataAreas.Clear();

            objCab.DES_TABLA = "AREA_INCUMPLIMIENTO";
            objCab.DES_CAMPO = "ID_AREA_INCUMPLIMIENTO";

            dt = obj.ListarParametros("AREA_INCUMPLIMIENTO", "ID_AREA_INCUMPLIMIENTO");
            if (dt.Rows.Count > 0)
            {
                LstAREAS = new BL_FUNCIONES().f_list_Parametros(objCab);
                foreach (DataRow row in dt.Rows)
                {
                    DataAreas.Add(Convert.ToString(row["DES_ASUNTO"]));
                }

            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                DataAreas.Clear();
            }
        }
        public void TareaProyectos()
        {
            try
            {
                BL_FUNCIONES obj = new BL_FUNCIONES();
                BE_CABECERA objCab = new BE_CABECERA();

                DataTable dt = new DataTable();
                DataTarea.Clear();
                row = gridAsignacion.CurrentCell.RowIndex; // fila de la grilla

                string valorActividad, valor = null;
                valorActividad = gridAsignacion.Rows[row].Cells["DESCRIPCION"].Value.ToString();


                valor = gridAsignacion.Rows[row].Cells["DESCRIPCION"].Value.ToString();
                objCab.TIPO = Convert.ToInt32(2);
                objCab.ID_PROYECTO = string.IsNullOrEmpty(cboCentroCosto.SelectedValue.ToString()) ? "0" : cboCentroCosto.SelectedValue.ToString();
                objCab.IDE_ACTIVIDAD = string.IsNullOrEmpty(valor) ? "0" : valor;
                objCab.ID_TAREA = "1";
                objCab.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                objCab.TIPO_ARCHIVO = cboFile.SelectedValue.ToString();

                dt = obj.Listar_ActividadTarea(2, cboCentroCosto.SelectedValue.ToString(), valor, "1", Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    LstActividades = new BL_CONTROL_AVANCE().f_list_TareProyecto(objCab);
                    foreach (DataRow row in dt.Rows)
                    {
                        DataTarea.Add(Convert.ToString(row["DESCRIPCION"]));
                    }
                }
                else
                {
                    dt.Rows.Clear();
                    dt.Clear();
                    DataTarea.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void FrenteProyectos()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            DataFrente.Clear();
            row = gridAsignacion.CurrentCell.RowIndex; // fila de la grilla

            string valorTarea, valorActividad;
            valorActividad = gridAsignacion.Rows[row].Cells[1].Value.ToString();
            valorTarea = gridAsignacion.Rows[row].Cells[2].Value.ToString();

            dt = obj.Listar_ActividadTarea(3, cboCentroCosto.SelectedValue.ToString(), valorActividad, valorTarea, Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DataFrente.Add(Convert.ToString(row["ID_FRENTE"]));
                }
            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                DataFrente.Clear();
            }
        }
        protected void txt_GV_ACTIVIDAD_TextChanged(object sender, EventArgs e)
        {
            string valor = null, actividadNombre;
            col = gridAsignacion.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            if (col == 1)
            {
                row = gridAsignacion.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridAsignacion.Rows[row];
                actividadNombre = box.Text;

                //int i = 0; int j = 0;
                //char[] letras = actividadNombre.ToCharArray();
                //for (i = 0; i < actividadNombre.Length; i++)
                //{
                //    if (letras[i] == '-')
                //    {
                //        j = i;
                //        break;
                //    }
                //}
                //if (j > 0)
                //{

                //    valor = (actividadNombre.Substring(0, j - 1));

                //}
                valor = box.Text;
                //valor = gridAsignacion.Rows[row].Cells["Actividad"].ToString();
                if (valor != string.Empty)
                {
                    //Rows.Cells[3].Value = label14.Text;

                    BE_CABECERA result = LstActividades.Find(
                    delegate (BE_CABECERA bk)
                    {
                        return bk.IDE_ACTIVIDAD == valor;

                        //return bk.DESCRIPCION == actividadNombre;
                    }
                    );
                    if (result != null)
                    {
                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.White;
                        gridAsignacion.Rows[row].Cells["ID_FRENTE"].Style.BackColor = Color.White;
                        gridAsignacion.Rows[row].Cells["CTA_COSTO"].Style.BackColor = Color.White;
                        gridAsignacion.Rows[row].Cells["DES_UNIDAD"].Style.BackColor = Color.White;
                        gridAsignacion.Rows[row].Cells["DESCRIPCION_TAREA"].Style.BackColor = Color.White;

                        gridAsignacion.Rows[row].Cells["DESCRIPCION_TAREA"].ReadOnly = false;


                        //Rows.Cells["Frente"].Value = result.ID_FRENTE;
                        //Rows.Cells["CtaCosto"].Value = result.CTA_COSTO;
                        //Rows.Cells["Actividad"].Value = valor;//codigo de actividad
                        //Rows.Cells["Unidad"].Value = result.DES_UNIDAD ;
                        //Rows.Cells["Tarea"].Value = result.ID_TAREA;
                        //Rows.Cells["Descripcion"].Value = result.DES_TAREA;
                    }
                    else
                    {
                        //gridAsignacion.Rows[row].Cells[col].ToolTipText = "Error, No existe actividad";
                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells["DESCRIPCION_TAREA"].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells["CTA_COSTO"].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells["DES_UNIDAD"].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells["ID_FRENTE"].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells["ID_FRENTE"].Value = string.Empty;
                        gridAsignacion.Rows[row].Cells["DESCRIPCION_TAREA"].Value = string.Empty;
                        gridAsignacion.Rows[row].Cells["CTA_COSTO"].Value = string.Empty;
                        gridAsignacion.Rows[row].Cells["DES_UNIDAD"].Value = string.Empty;
                        gridAsignacion.Rows[row].Cells["PK_TAREA"].Value = string.Empty;
                        gridAsignacion.Rows[row].Cells["DESCRIPCION_TAREA"].ReadOnly = true;

                    }
                }
            }
        }
        protected void txt_AREAS_TextChanged(object sender, EventArgs e)
        {
            string valor;
            col = gridAsignacion.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            if (gridAsignacion.Columns[col].Name == "Areas")
            {
                row = gridAsignacion.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridAsignacion.Rows[row];
                valor = box.Text;
                if (valor != string.Empty)
                {
                    BE_TBPARAMETROS result = LstAREAS.Find(
                    delegate (BE_TBPARAMETROS bk)
                    {
                        return bk.DES_ASUNTO == valor;
                    }
                    );
                    if (result != null)
                    {
                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.White;
                    }
                    else
                    {
                        //gridAsignacion.Rows[row].Cells[col].ToolTipText = "Error, No existe Area";
                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.Red;
                        gridAsignacion.Rows[row].Cells[col].Value = string.Empty;
                    }
                }
            }
        }
        protected void txt_TAREA_TextChanged(object sender, EventArgs e)
        {
            string valor = null, TareaNombre = null;
            col = gridAsignacion.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            if (gridAsignacion.Columns[col].Name == "DESCRIPCION_TAREA")
            {
                row = gridAsignacion.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridAsignacion.Rows[row];
                TareaNombre = box.Text;

                int i = 0; int j = 0;
                char[] letras = TareaNombre.ToCharArray();
                for (i = 0; i < TareaNombre.Length; i++)
                {
                    if (letras[i] == '-')
                    {
                        j = i;
                        break;
                    }
                }
                if (j > 0)
                {

                    valor = (TareaNombre.Substring(0, j - 1));

                }
                //valor = box.Text;
                //valor = gridAsignacion.Rows[row].Cells["Actividad"].Value.ToString();
                if (valor != string.Empty)
                {
                    BE_CABECERA result = LstActividades.Find(
                    delegate (BE_CABECERA bk)
                    {
                        return bk.ID_TAREA == valor;
                    }
                    );
                    if (result != null)
                    {


                        Rows.Cells["ID_FRENTE"].Value = result.ID_FRENTE;
                        Rows.Cells["CTA_COSTO"].Value = result.CTA_COSTO;
                        Rows.Cells["DES_UNIDAD"].Value = result.DES_UNIDAD;
                        Rows.Cells["IDE_TAREA"].Value = valor;
                        Rows.Cells["IDE_ACTIVIDAD"].Value = result.IDE_ACTIVIDAD;
                        Rows.Cells["PK_TAREA"].Value = result.PK_TAREA;

                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.White;
                        Rows.Cells["ID_FRENTE"].Style.BackColor = Color.White;
                        Rows.Cells["CTA_COSTO"].Style.BackColor = Color.White;
                        Rows.Cells["DES_UNIDAD"].Style.BackColor = Color.White;
                        Rows.Cells["IDE_TAREA"].Style.BackColor = Color.White;
                        Rows.Cells["IDE_ACTIVIDAD"].Style.BackColor = Color.White;

                    }
                    else
                    {
                        //gridAsignacion.Rows[row].Cells[col].ToolTipText = "Error, No existe Tarea";
                        gridAsignacion.Rows[row].Cells[col].Style.BackColor = Color.Red;

                        Rows.Cells["ID_FRENTE"].Style.BackColor = Color.Red;
                        Rows.Cells["CTA_COSTO"].Style.BackColor = Color.Red;
                        Rows.Cells["DES_UNIDAD"].Style.BackColor = Color.Red;
                        Rows.Cells["IDE_TAREA"].Style.BackColor = Color.Red;
                        Rows.Cells["IDE_ACTIVIDAD"].Style.BackColor = Color.Red;
               
                    }
                }
            }
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDisciplina();
            //ActividadesProyectos();
            //ListarIngenieros();
        }

        public void frentes()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            dt = obj.ListarPeriodoFecha(2, Convert.ToInt32(cboAnio.SelectedValue), 1);
            foreach (DataRow row in dt.Rows)
            {
                DataFrente.Add(Convert.ToString(row["descripcion"]));
            }
        }
        // para seleccionar
        private void gridAsignacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string x;
            //eliminar fila de tareas
            if (e.ColumnIndex > -1)
            {
                if (gridAsignacion.Columns[e.ColumnIndex].Name == "btn")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar tarea?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        DataGridViewRow Rows = gridAsignacion.Rows[i];
                        for (int j = 0; j <= e.ColumnIndex; j++)
                        {
                            try
                            {
                                string columnas = gridAsignacion.Columns[j].Name;
                                if (columnas.Equals("IDE_TAREA"))
                                {
                                    x = (Rows.Cells["IDE_TAREA"].Value == null) ? "0" : Rows.Cells["IDE_TAREA"].Value.ToString();
                                    if (x != "0")
                                    {
                                        BL_ASIGNACION_TAREAS objTarea = new BL_ASIGNACION_TAREAS();
                                        objTarea.EliminarTareas(Convert.ToInt32(x));
                                        ListarActividadesAsignadas();

                                        //listarCuadrilla();
                                        MessageBox.Show("ELiminacion de tarea satisfactoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Esta tarea no se encuentra registrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                //else if (gridAsignacion.Columns[e.ColumnIndex].Name == "Marca")
                //{
                //    DataGridViewRow Rows = gridAsignacion.Rows[i];
                //    string pk = (Rows.Cells["IdTarea"].Value == null) ? "0" : Rows.Cells["IdTarea"].Value.ToString();
                //    string IDE_ACTIVIDAD = (Rows.Cells["Actividad"].Value == null) ? "0" : Rows.Cells["Actividad"].Value.ToString();
                //    string DET_TAREA = (Rows.Cells["codigoTarea"].Value == null) ? "0" : Rows.Cells["codigoTarea"].Value.ToString();
                //    if (pk != "0")
                //    {
                //        string IDE_FRENTE = Rows.Cells["Frente"].Value.ToString();
                //        obj_Tareas_E = new BE_ASIGNACION_TAREAS();
                //        obj_Tareas_E.IDE_TAREA = Convert.ToInt32(pk);
                //        obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                //        obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                //        obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                //        obj_Tareas_E.ID_FRENTE = IDE_FRENTE;
                //        obj_Tareas_E.DET_TAREA = DET_TAREA;
                //        frmDisciplinaEstructura f2 = new frmDisciplinaEstructura(); //creamos un objeto del formulario hijo
                //        DialogResult res = f2.ShowDialog();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Falta registrar Tarea", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //}

            }
        }
        protected void Registrar_CabeceraTareo(int fila, int columnUltima)
        {
            BE_ASIGNACION_TAREO obj = new BE_ASIGNACION_TAREO();
            obj = f_datosCabecera();
            int rpta, rptaTareas;
            rpta = new BL_ASIGNACION_TAREO().Mant_Insert_Tareo(obj);
            string observa = null;
            string area = null;
            if (rpta > 0)
            {
                lblIdTareo.Text = rpta.ToString();
                DataGridViewRow Rows = gridAsignacion.Rows[fila];
                BE_ASIGNACION_TAREAS objTarea = new BE_ASIGNACION_TAREAS();
                try
                {
                    observa = (Rows.Cells["Observaciones"].Value == null) ? "" : Rows.Cells["Observaciones"].Value.ToString();
                    area = (Rows.Cells["Areas"].Value == null) ? "" : Rows.Cells["Areas"].Value.ToString();
                    //registro detalle

                    objTarea.IDE_TAREA = Convert.ToInt32(string.IsNullOrEmpty(lblidTareas.Text) ? "0" : lblidTareas.Text);
                    objTarea.IDE_TAREO_ASIGNACION = Convert.ToInt32(lblIdTareo.Text);
                    objTarea.ITEM_ACTIVIDAD = 0;
                    objTarea.IDE_ACTIVIDAD = Rows.Cells["Actividad"].Value.ToString();
                    objTarea.DET_TAREA = Rows.Cells["Tarea"].Value.ToString();
                    objTarea.ID_FRENTE = Rows.Cells["Frente"].Value.ToString();
                    objTarea.CTA_COSTO = Rows.Cells[4].Value.ToString();
                    objTarea.DES_TAREA = Rows.Cells[5].Value.ToString();
                    objTarea.DES_UNIDAD = Rows.Cells["Unidad"].Value.ToString();
                    objTarea.HORA_INICIO = null;
                    objTarea.HORA_FIN = null;
                    objTarea.PROGRAMADO = Convert.ToDecimal(string.IsNullOrEmpty(Rows.Cells["Programado"].Value.ToString()) ? "0" : Rows.Cells["Programado"].Value.ToString());
                    objTarea.EJECUTADO = Convert.ToDecimal(string.IsNullOrEmpty(Rows.Cells["Ejecutado"].Value.ToString()) ? "0" : Rows.Cells["Ejecutado"].Value.ToString());
                    objTarea.FLG_ESTADO = 1;
                    objTarea.OBSERVACIONES = observa.ToString();
                    objTarea.DES_AREAS = area.ToString();
                    objTarea.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
                    objTarea.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
                    objTarea.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
                    rptaTareas = new BL_ASIGNACION_TAREO().Mant_Insert_TareasActividades(objTarea);
                    if (rptaTareas > 0)
                    {
                        lblidTareas.Text = rptaTareas.ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


        #region InsertarDatos

        private BE_ASIGNACION_TAREO f_datosCabecera()
        {
            int turno = 1;
            if (checkTurno.Checked)
            {
                turno = 2;//Noche
            }

            else
            {
                turno = 1;
            }


            BE_ASIGNACION_TAREO Obj = new BE_ASIGNACION_TAREO();
            Obj.IDE_TAREO_ASIGNACION = Convert.ToInt32(string.IsNullOrEmpty(lblIdTareo.Text) ? "0" : lblIdTareo.Text);
            Obj.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
            Obj.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
            Obj.INT_ANIO = Convert.ToInt32(cboAnio.SelectedValue);
            Obj.INT_MES = Convert.ToInt32(cboMes.SelectedValue);
            Obj.INT_SEM = Convert.ToInt32(cboSemana.SelectedValue);
            Obj.COD_PROYECTO = "";//analizar dato
            Obj.FEC_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            Obj.IDE_CLIENTE = "";//analizar
            Obj.IDE_UBICACIONES = "";//analizar
            Obj.FLG_ESTADO = Convert.ToInt32(lblEstado.Text);
            Obj.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
            Obj.IDE_TURNO = turno;
            Obj.NOMBRE_DIA = dateTareo.Value.Date.ToString("dddd");
            return Obj;
        }
        #endregion

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }
        private void LoadGrillaComboBoxAreas()
        {
            foreach (DataGridViewRow rowCol in gridAsignacion.Rows)
            {


                DataGridViewComboBoxCell comboboxCell = rowCol.Cells["Areas"] as DataGridViewComboBoxCell;

                comboboxCell.DataSource = dtAreas;
                comboboxCell.ValueMember = "DES_ASUNTO";
                comboboxCell.DisplayMember = "DES_ASUNTO";

            }
        }

        protected void ListarActividadesAsignadas()
        {
            //ESTRUCTURA GRILLA
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            int valor = 0;
            if (cboFile.SelectedIndex == 0)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToInt32(cboFile.SelectedValue);
            }


            string CAPATAZ = string.Empty;
            CAPATAZ = cboCapataz.SelectedValue.ToString();

            dtResultado = xobj.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));

            gridAsignacion.Rows.Clear();
            gridAsignacion.Refresh();
            gridAsignacion.DataSource = null;
            gridAsignacion.Columns.Clear();

            gridAsignacion.ColumnCount = 1;
            gridAsignacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridAsignacion.Columns[0].Name = "Item";
            gridAsignacion.Columns[0].Width = 60;


            DataGridViewTextBoxColumn colIDE_TAREA = new DataGridViewTextBoxColumn();
            colIDE_TAREA.Name = "IDE_TAREA";
            colIDE_TAREA.HeaderText = "Descripcion Actividad";
            colIDE_TAREA.Width = 350;
            colIDE_TAREA.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridAsignacion.Columns.Insert(1, colIDE_TAREA);


            DataGridViewTextBoxColumn colDESCRIPCION = new DataGridViewTextBoxColumn();
            colDESCRIPCION.Name = "DESCRIPCION";
            colDESCRIPCION.HeaderText = "Descripción Actividad";
            colDESCRIPCION.Width = 420;
            colDESCRIPCION.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridAsignacion.Columns.Insert(2, colDESCRIPCION);

            DataGridViewTextBoxColumn colDESCRIPCION_TAREA = new DataGridViewTextBoxColumn();
            colDESCRIPCION_TAREA.Name = "DESCRIPCION_TAREA";
            colDESCRIPCION_TAREA.HeaderText = "Descripción Tareo";
            colDESCRIPCION_TAREA.Width = 420;
            //colTarea.ReadOnly = true;
            colDESCRIPCION_TAREA.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridAsignacion.Columns.Insert(3, colDESCRIPCION_TAREA);

            DataGridViewTextBoxColumn colID_FRENTE = new DataGridViewTextBoxColumn();
            colID_FRENTE.Name = "ID_FRENTE";
            colID_FRENTE.HeaderText = "Area";
            colID_FRENTE.Width = 60;
            colID_FRENTE.ReadOnly = true;
            //colID_FRENTE.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            colID_FRENTE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(4, colID_FRENTE);

            DataGridViewTextBoxColumn colCTA_COSTO = new DataGridViewTextBoxColumn();
            colCTA_COSTO.Name = "CTA_COSTO";
            colCTA_COSTO.HeaderText = "Cta. Costo";
            colCTA_COSTO.Width = 80;
            colCTA_COSTO.ReadOnly = true;
            //colCTA_COSTO.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            colCTA_COSTO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(5, colCTA_COSTO);

            DataGridViewTextBoxColumn ColDES_UNIDAD = new DataGridViewTextBoxColumn();
            ColDES_UNIDAD.Name = "DES_UNIDAD";
            ColDES_UNIDAD.HeaderText = "Unidad";
            ColDES_UNIDAD.Width = 50;
            ColDES_UNIDAD.ReadOnly = true;
            //ColDES_UNIDAD.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            ColDES_UNIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(6, ColDES_UNIDAD);


            gridAsignacion.Columns["DESCRIPCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridAsignacion.Columns["DESCRIPCION_TAREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridAsignacion.Columns["DESCRIPCION"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);


            DataGridViewTextBoxColumn colCOD_CABECERA = new DataGridViewTextBoxColumn();
            colCOD_CABECERA.Name = "COD_CABECERA";
            colCOD_CABECERA.HeaderText = "COD_CABECERA";
            gridAsignacion.Columns.Insert(7, colCOD_CABECERA);

            DataGridViewTextBoxColumn colPK_TAREA = new DataGridViewTextBoxColumn();
            colPK_TAREA.Name = "PK_TAREA";
            colPK_TAREA.HeaderText = "PK_TAREA";
            gridAsignacion.Columns.Insert(8, colPK_TAREA);

            DataGridViewTextBoxColumn colIDE_ACTIVIDAD = new DataGridViewTextBoxColumn();
            colIDE_ACTIVIDAD.Name = "IDE_ACTIVIDAD";
            colIDE_ACTIVIDAD.HeaderText = "IDE_ACTIVIDAD";
            gridAsignacion.Columns.Insert(9, colIDE_ACTIVIDAD);


            DataGridViewTextBoxColumn colDET_TAREA = new DataGridViewTextBoxColumn();
            colDET_TAREA.Name = "DET_TAREA";
            colDET_TAREA.HeaderText = "DET_TAREA";
            gridAsignacion.Columns.Insert(10, colDET_TAREA);

           

            //VISIBLE
            gridAsignacion.Columns["IDE_TAREA"].Visible = false;
            gridAsignacion.Columns["COD_CABECERA"].Visible = false; // como fila de la grilla
            gridAsignacion.Columns["PK_TAREA"].Visible = false;
            gridAsignacion.Columns["IDE_ACTIVIDAD"].Visible = false;//
            gridAsignacion.Columns["DET_TAREA"].Visible = false;




            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridAsignacion.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            if (dtResultado.Rows.Count > 0)
            {

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    int renglon = gridAsignacion.Rows.Add();
                    gridAsignacion.Rows[renglon].Cells["Item"].Value = "Tarea " + dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();// Convert.ToString(i + 1);
                    gridAsignacion.Rows[renglon].Cells["IDE_TAREA"].Value = dtResultado.Rows[i]["IDE_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DESCRIPCION"].Value = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DESCRIPCION_TAREA"].Value = dtResultado.Rows[i]["DESCRIPCION_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["ID_FRENTE"].Value = dtResultado.Rows[i]["ID_FRENTE"].ToString();
                    gridAsignacion.Rows[renglon].Cells["CTA_COSTO"].Value = dtResultado.Rows[i]["CTA_COSTO"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DES_UNIDAD"].Value = dtResultado.Rows[i]["DES_UNIDAD"].ToString();
                 
                  
                    gridAsignacion.Rows[renglon].Cells["COD_CABECERA"].Value = dtResultado.Rows[i]["COD_CABECERA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["PK_TAREA"].Value = dtResultado.Rows[i]["PK_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["IDE_ACTIVIDAD"].Value = dtResultado.Rows[i]["IDE_ACTIVIDAD"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DET_TAREA"].Value = dtResultado.Rows[i]["DET_TAREA"].ToString();

                    //lblEstado.Text = dtResultado.Rows[i]["ESTADO_TAREO"].ToString();
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)gridAsignacion.Rows[i].Clone();
                    row.Cells[0].Value = "Tarea " + Convert.ToString(i + 1);
                    gridAsignacion.Rows.Add(row);
                }
                /*lblEstado.Text = "1";*/// ABIERTO TAREO
            }


          
            if (lblEstado.Text == "1")
            {
                lblMensajeEstado.Text = "(Estado Tareo : Pendiente de Cierre)";
                btnGuardarTareo.Visible = true;
                btnGuardarActividad.Visible = true;
                gridAsignacion.Columns["btn"].Visible = true;

            }
            else
            {
                lblMensajeEstado.Text = "(Estado Tareo : Procesado)";
                btnGuardarTareo.Visible = false;
                btnGuardarActividad.Visible = false;
                gridAsignacion.Columns["btn"].Visible = false;

            }
            listarCuadrilla();
        }

        protected void ListarActividadesAsignadas_antiguo()
        {
            //ESTRUCTURA GRILLA
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            int valor = 0;
            if (cboFile.SelectedIndex == 0)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToInt32(cboFile.SelectedValue);
            }


            string CAPATAZ = string.Empty;
            CAPATAZ = cboCapataz.SelectedValue.ToString();

            dtResultado = xobj.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));

            gridAsignacion.Rows.Clear();
            gridAsignacion.Refresh();
            gridAsignacion.DataSource = null;
            gridAsignacion.Columns.Clear();

            gridAsignacion.ColumnCount = 1;
            gridAsignacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridAsignacion.Columns[0].Name = "Item";
            gridAsignacion.Columns[0].Width = 58;



            BL_DISCIPLINAS objDisciplina = new BL_DISCIPLINAS();
            DataTable dtDisciplina = new DataTable();

            dtDisciplina = objDisciplina.SEL_DISCIPLINAS_ESTRUCTURA(valor, cboCentroCosto.SelectedValue.ToString());
        

            if (dtDisciplina.Rows.Count > 0)
            {
                for (int i = 0; i < dtDisciplina.Rows.Count; i++)
                {

                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dtDisciplina.Rows[i]["Name"].ToString();
                    col.HeaderText = dtDisciplina.Rows[i]["HeaderText"].ToString();
                    col.ReadOnly = Convert.ToBoolean(dtDisciplina.Rows[i]["estado"].ToString());
                    col.Width = Convert.ToInt32(dtDisciplina.Rows[i]["Tamanio"].ToString());
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gridAsignacion.Columns.Add(col);
                }
            }





            gridAsignacion.Columns["DesActividad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridAsignacion.Columns["Tarea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            gridAsignacion.Columns["DesActividad"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);


            DataGridViewTextBoxColumn colProgramado = new DataGridViewTextBoxColumn();
            colProgramado.Name = "Programado";
            colProgramado.HeaderText = "Programado";
            colProgramado.Width = 62;
            colProgramado.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            colProgramado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(6, colProgramado);

            DataGridViewTextBoxColumn colEjecutado = new DataGridViewTextBoxColumn();
            colEjecutado.Name = "Ejecutado";
            colEjecutado.HeaderText = "Ejecutado";
            colEjecutado.Width = 60;
            colEjecutado.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            colEjecutado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(7, colEjecutado);

            DataGridViewButtonColumn btnMarca = new DataGridViewButtonColumn();
            btnMarca.HeaderText = "";
            btnMarca.Name = "Marca";
            btnMarca.Text = "Agregar Marca";
            btnMarca.UseColumnTextForButtonValue = true;
            gridAsignacion.Columns.Insert(8, btnMarca);


            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "RT";
            checkBoxColumn.ToolTipText = "Retrabajo";
            checkBoxColumn.Width = 40;
            checkBoxColumn.Name = "checkBoxRT";
            gridAsignacion.Columns.Insert(9, checkBoxColumn);




            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.HeaderText = "Areas de Soporte";
            cmbCol.Name = "Areas";

            gridAsignacion.Columns.Insert(10, cmbCol);



            DataGridViewTextBoxColumn colObservaciones = new DataGridViewTextBoxColumn();
            colObservaciones.Name = "Observaciones";
            colObservaciones.HeaderText = "Observaciones de Incumplimiento";
            colObservaciones.Width = 200;
            gridAsignacion.Columns.Insert(11, colObservaciones);


            DataGridViewTextBoxColumn colIdTarea = new DataGridViewTextBoxColumn();
            colIdTarea.Name = "IdTarea";
            colIdTarea.HeaderText = "IdTarea";
            gridAsignacion.Columns.Insert(12, colIdTarea);

            DataGridViewTextBoxColumn colCodActividad = new DataGridViewTextBoxColumn();
            colCodActividad.Name = "Actividad";
            colCodActividad.HeaderText = "Actividad";
            gridAsignacion.Columns.Insert(13, colCodActividad);

            DataGridViewTextBoxColumn colDescripcionActividad = new DataGridViewTextBoxColumn();
            colDescripcionActividad.Name = "DescripcionActividad";
            colDescripcionActividad.HeaderText = "Descripcion Actividad";
            gridAsignacion.Columns.Insert(14, colDescripcionActividad);

            DataGridViewTextBoxColumn colcodigoTarea = new DataGridViewTextBoxColumn();
            colcodigoTarea.Name = "codigoTarea";
            colcodigoTarea.HeaderText = "codigoTarea";
            gridAsignacion.Columns.Insert(15, colcodigoTarea);

            DataGridViewTextBoxColumn colDescripcionTarea = new DataGridViewTextBoxColumn();
            colDescripcionTarea.Name = "DescripcionTarea";
            colDescripcionTarea.HeaderText = "DescripcionTarea";
            gridAsignacion.Columns.Insert(16, colDescripcionTarea);

            DataGridViewTextBoxColumn colDescripcionFrente = new DataGridViewTextBoxColumn();
            colDescripcionFrente.Name = "DescripcionFrente";
            colDescripcionFrente.HeaderText = "DescripcionFrente";
            gridAsignacion.Columns.Insert(17, colDescripcionFrente);


            DataGridViewTextBoxColumn colPK_TAREA = new DataGridViewTextBoxColumn();
            colPK_TAREA.Name = "PK_TAREA";
            colPK_TAREA.HeaderText = "PK_TAREA";
            gridAsignacion.Columns.Insert(18, colPK_TAREA);


            //VISIBLE
            gridAsignacion.Columns["Actividad"].Visible = false;
            gridAsignacion.Columns["IdTarea"].Visible = false; // como fila de la grilla
            gridAsignacion.Columns["DescripcionFrente"].Visible = false;
            gridAsignacion.Columns["codigoTarea"].Visible = false;//
            gridAsignacion.Columns["DescripcionActividad"].Visible = false;
            gridAsignacion.Columns["DescripcionFrente"].Visible = false;
            gridAsignacion.Columns["DescripcionTarea"].Visible = false;
            gridAsignacion.Columns["PK_TAREA"].Visible = false;

            if (cboFile.Text == "PERSONALIZADO")
            {
                gridAsignacion.Columns["Marca"].Visible = false;
                //btnAvanceEstructura.Visible = true;
                //btnAvance.Visible = true;
            }
            else
            {
                gridAsignacion.Columns["Marca"].Visible = false;
                btnAvanceEstructura.Visible = false;
                //btnAvance.Visible = false;
            }


            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridAsignacion.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            if (dtResultado.Rows.Count > 0)
            {

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    int renglon = gridAsignacion.Rows.Add();
                    gridAsignacion.Rows[renglon].Cells["Item"].Value = "Tarea " + dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();// Convert.ToString(i + 1);
                    gridAsignacion.Rows[renglon].Cells["DesActividad"].Value = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Tarea"].Value = dtResultado.Rows[i]["DESCRIPCION_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Frente"].Value = dtResultado.Rows[i]["ID_FRENTE"].ToString();
                    gridAsignacion.Rows[renglon].Cells["CtaCosto"].Value = dtResultado.Rows[i]["CTA_COSTO"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Unidad"].Value = dtResultado.Rows[i]["DES_UNIDAD"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Programado"].Value = dtResultado.Rows[i]["H_PROGRAMADO"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Ejecutado"].Value = dtResultado.Rows[i]["H_EJECUTADO"].ToString();
                    gridAsignacion.Rows[renglon].Cells["checkBoxRT"].Value = Convert.ToBoolean(dtResultado.Rows[i]["RETRABAJO"].ToString());
                    gridAsignacion.Rows[renglon].Cells["Areas"].Value = dtResultado.Rows[i]["DES_AREAS"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Observaciones"].Value = dtResultado.Rows[i]["OBSERVACIONES"].ToString();
                    gridAsignacion.Rows[renglon].Cells["IdTarea"].Value = dtResultado.Rows[i]["IDE_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["Actividad"].Value = dtResultado.Rows[i]["IDE_ACTIVIDAD"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DescripcionActividad"].Value = dtResultado.Rows[i]["DES_ACTIVIDAD"].ToString();
                    gridAsignacion.Rows[renglon].Cells["codigoTarea"].Value = dtResultado.Rows[i]["DET_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DescripcionTarea"].Value = dtResultado.Rows[i]["DES_TAREA"].ToString();
                    gridAsignacion.Rows[renglon].Cells["DescripcionFrente"].Value = dtResultado.Rows[i]["DES_FRENTE"].ToString();
                    gridAsignacion.Rows[renglon].Cells["PK_TAREA"].Value = dtResultado.Rows[i]["PK_TAREA"].ToString();
                    //lblEstado.Text = dtResultado.Rows[i]["ESTADO_TAREO"].ToString();
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)gridAsignacion.Rows[i].Clone();
                    row.Cells[0].Value = "Tarea " + Convert.ToString(i + 1);
                    gridAsignacion.Rows.Add(row);
                }
                /*lblEstado.Text = "1";*/// ABIERTO TAREO
            }


            LoadGrillaComboBoxAreas();
            if (lblEstado.Text == "1")
            {
                lblMensajeEstado.Text = "(Estado Tareo : Pendiente de Cierre)";
                btnGuardarTareo.Visible = true;
                btnGuardarActividad.Visible = true;
                gridAsignacion.Columns["btn"].Visible = true;

            }
            else
            {
                lblMensajeEstado.Text = "(Estado Tareo : Procesado)";
                btnGuardarTareo.Visible = false;
                btnGuardarActividad.Visible = false;
                gridAsignacion.Columns["btn"].Visible = false;

            }
            listarCuadrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                if (cboFile.SelectedIndex < 1)
                {
                    MessageBox.Show("Seleccionar modo de tareo", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    ConsultarTareo();
                    PeriodoAnio();
                    //AreasSoporte();
                    ActividadesProyectos();
                    EstadoDiario();
                    JornadasHoras();

                    ListarIngenieros();
                    //dsActividad.Clear();
                    //LstActividades.Clear();
                }
                //ListarActividadesAsignadas();

            }
            else
            {

                MessageBox.Show(ls_error);
            }
            //dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
            //string Nombredia = dateTareo.ToString("dddd", new CultureInfo("es-ES"));


        }
        #region ActividadesAsignadasDetalle
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            if (lblEstado.Text == "1")
            {

                dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "INGENIERO", null, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
            else
            {

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1, "");
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            if (lblEstado.Text == "1")
            {
                dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataz.Visible = true;
                    cboCapataz.ValueMember = "ID_PERSONAL";
                    cboCapataz.DisplayMember = "NOMBRES";
                    cboCapataz.DataSource = dtResultado;
                }
                else
                {
                    cboCapataz.Visible = false;

                    MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
                        "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
                        "Ingresar Opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 2, cboIngeniero.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataz.ValueMember = "ID_PERSONAL";
                    cboCapataz.DisplayMember = "NOMBRES";
                    cboCapataz.DataSource = dtResultado;
                }
            }

        }
        #endregion

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }
        private void cboCapataz_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarActividadesAsignadas();
            //DetalleTrabajos();
        }
        private void btnCuadrilla_Click(object sender, EventArgs e)
        {
            listarCuadrilla();

        }
        protected void listarCuadrilla()
        {
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();


            string CAPATAZ = string.Empty;

            CAPATAZ = cboCapataz.SelectedValue.ToString();

            dtResultado = xobj.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                gridDetalle.Visible = true;
                DetalleTrabajos();

                //Variable donde almacenaremos el resultado de la sumatoria.
                double sumatoria = 0;

                for (int i = 7; i < gridDetalle.ColumnCount - 1; i++)
                {
                    sumatoria = 0;

                    foreach (DataGridViewRow row in gridDetalle.Rows)
                    {
                        //Aquí seleccionaremos la columna que contiene los datos numericos. 
                        if (row.Cells[i].Value == null)
                        {
                            sumatoria += Convert.ToDouble((row.Cells[i].Value == null) ? "0" : row.Cells[i].Value.ToString());
                        }
                        else if (row.Cells[i].Value.ToString() == "")
                        {
                            sumatoria += Convert.ToDouble((row.Cells[i].Value.ToString() == "" ? "0" : row.Cells[i].Value.ToString()));
                        }
                        else
                        {
                            sumatoria += Convert.ToDouble(row.Cells[i].Value.ToString());
                        }

                        //(rx.Cells["Asistencia"].Value == null) ? "" : rx.Cells["Asistencia"].Value.ToString()
                    }
                    DataGridViewRow rowTotal = gridDetalle.Rows[gridDetalle.Rows.Count - 1];
                    rowTotal.Cells[i].Value = sumatoria;

                    sumatoria = 0;

                }
                gridDetalle.Rows[gridDetalle.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
                gridDetalle.Rows[gridDetalle.Rows.Count - 1].ReadOnly = true;
                //gridDetalle.AllowUserToAddRows = false;
            }
            else
            {
                gridDetalle.Visible = false;
                gridDetalle.Rows.Clear();
                gridDetalle.Refresh();


                //DataGridViewRow rowTotal = gridDetalle.Rows[gridDetalle.Rows.Count - 1];
                //rowTotal.Cells["Total"].Value = 0;
            }


            //
            // Se toma la ultima fila del total general, asignando el valor acumulado en el calculo
            //


            BE_TBPARAMETROS objCab = new BE_TBPARAMETROS();
            objCab.DES_TABLA = "TAREO";
            objCab.DES_CAMPO = "IDE_BONIFICACION";
            LstBonificacion = new BL_FUNCIONES().f_list_Parametros(objCab);
            dsBonificacion = new BL_FUNCIONES().ListarParametros("TAREO", "IDE_BONIFICACION");
        }



        private void checkTurno_CheckedChanged(object sender, EventArgs e)
        {

        }

      
        void ValidarNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

        }
        //autocompletar
        private void gridAsignacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bKeyPressNum_GV_DATA = false;
            col = gridAsignacion.CurrentCell.ColumnIndex;
            string titleText = gridAsignacion.Columns[col].HeaderText;
            TextBox txt_GV_DATA = e.Control as TextBox;

            if (gridAsignacion.Columns[col].Name == "DESCRIPCION") //ACTIVIDAD
            {

                ActividadesProyectos();
                txt_GV_DATA.ReadOnly = false;
                bKeyPressNum_GV_DATA = false;
                if (txt_GV_DATA != null)
                {

                    txt_GV_DATA.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txt_GV_DATA.AutoCompleteSource = AutoCompleteSource.CustomSource;//CustomSource
                    txt_GV_DATA.AutoCompleteCustomSource = DataActividades; //autocompletar dsActividad;// 
                    row = gridAsignacion.CurrentCell.RowIndex;
                    txt_GV_DATA.TextChanged += txt_GV_ACTIVIDAD_TextChanged;
                }
            }
            else
            {

                if (gridAsignacion.Columns[col].Name == "DESCRIPCION_TAREA") //TAREA
                {
                    bKeyPressNum_GV_DATA = true;
                    if (txt_GV_DATA != null)
                    {
                        TareaProyectos();
                        txt_GV_DATA.AutoCompleteCustomSource = DataTarea; //autocompletar
                        txt_GV_DATA.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txt_GV_DATA.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        row = gridAsignacion.CurrentCell.RowIndex;
                        txt_GV_DATA.TextChanged += txt_TAREA_TextChanged;
                    }
                }
                //else if (gridAsignacion.Columns[col].Name == "Programado") // Programado
                //{
                //    DataActividades.Clear();
                //    DataTarea.Clear();
                //    bKeyPressNum_GV_DATA = true;
                //    if (txt_GV_DATA != null)
                //    {

                //        txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                //        txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
                //    }
                //}
                //else if (gridAsignacion.Columns[col].Name == "Ejecutado") // Ejecutado
                //{
                //    DataActividades.Clear();
                //    bKeyPressNum_GV_DATA = true;
                //    if (txt_GV_DATA != null)
                //    {

                //        txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                //        txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
                //    }
                //}

                else
                {
                    bKeyPressNum_GV_DATA = false;
                }

            }
        }





        private void txt_GV_DATA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (bKeyPressNum_GV_DATA == true)
            {
                if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
                {
                    return;
                }
                decimal isNumber = 0;
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
            }
            else
            {
                e.Handled = false;
            }
        }

        protected void DetalleTrabajos()
        {
            gridDetalle.Rows.Clear();
            gridDetalle.Refresh();
            gridDetalle.DataSource = null;
            gridDetalle.Columns.Clear();
            gridDetalle.AllowUserToAddRows = true;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //gridDetalle.AutoGenerateColumns = false;
            int CANTIDAD_PERSONAL = 0;
            int CANTIDAD_TAREAS = 0;

            //gridDetalle.ColumnCount = 5;
            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "Item";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colItem.Width = 30;
            gridDetalle.Columns.Insert(0, colItem);

            DataGridViewTextBoxColumn colIDE_PERSONAL = new DataGridViewTextBoxColumn();
            colIDE_PERSONAL.Name = "IDE_PERSONAL";
            colIDE_PERSONAL.HeaderText = "IDE_PERSONAL";
            gridDetalle.Columns.Insert(1, colIDE_PERSONAL);

            DataGridViewTextBoxColumn colApellidos = new DataGridViewTextBoxColumn();
            colApellidos.Name = "Apellidos";
            colApellidos.HeaderText = "Apellidos y nombres";
            //colApellidos.Width = 350;
            gridDetalle.Columns.Insert(2, colApellidos);

            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.Name = "Especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //colEspecialidad.Width = 30;
            gridDetalle.Columns.Insert(3, colEspecialidad);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //colEspecialidad.Width = 30;
            gridDetalle.Columns.Insert(4, colCategoria);

            DataGridViewTextBoxColumn colAsistencia = new DataGridViewTextBoxColumn();
            colAsistencia.Name = "Asistencia";
            colAsistencia.HeaderText = "Asistencia";
            colAsistencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAsistencia.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridDetalle.Columns.Insert(5, colAsistencia);

            //gridDetalle.Columns[0].Name = "Item";
            //gridDetalle.Columns[1].Name = "Apellidos y nombres";
            //gridDetalle.Columns[2].Name = "Especialidad";
            //gridDetalle.Columns[3].Name = "Categoria";
            //gridDetalle.Columns[4].Name = "Asistencia";

            DataGridViewTextBoxColumn colED = new DataGridViewTextBoxColumn();
            colED.Name = "EstadoDiario";
            colED.HeaderText = "E/F";
            colED.Width = 40;
            colED.ReadOnly = true;
            colED.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(6, colED);



            //agregar columna de tareas agregadas en bd

            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            string CAPATAZ = string.Empty;
            CAPATAZ = cboCapataz.SelectedValue.ToString();

            dtResultado = xobj.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));
            CANTIDAD_TAREAS = dtResultado.Rows.Count;

            if (dtResultado.Rows.Count > 0)
            {
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DataPropertyName = dtResultado.Rows[i]["IDE_TAREA"].ToString();
                    col.HeaderText = "Tarea " + dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 67;

                    gridDetalle.Columns.Add(col);
                }
            }



            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotal.Width = 55;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colTotal);


            DataGridViewTextBoxColumn colHNoct = new DataGridViewTextBoxColumn();
            colHNoct.Name = "HNoct";
            colHNoct.HeaderText = "HNoct";
            colHNoct.Width = 55;
            colHNoct.DataPropertyName = "35";
            colHNoct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHNoct);

            DataGridViewTextBoxColumn colHAlt = new DataGridViewTextBoxColumn();
            colHAlt.Name = "HAlt";
            colHAlt.HeaderText = "HAlt";
            colHAlt.Width = 55;
            colHAlt.DataPropertyName = "36";
            colHAlt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHAlt);

            DataGridViewTextBoxColumn colHAgua = new DataGridViewTextBoxColumn();
            colHAgua.Name = "HAgua";
            colHAgua.HeaderText = "HAgua";
            colHAgua.Width = 55;
            colHAgua.DataPropertyName = "37";
            colHAgua.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHAgua);

            DataGridViewTextBoxColumn colHTunel = new DataGridViewTextBoxColumn();
            colHTunel.Name = "HTunel";
            colHTunel.HeaderText = "HTunel";
            colHTunel.Width = 55;
            colHTunel.DataPropertyName = "38";
            colHTunel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add( colHTunel);

            DataGridViewTextBoxColumn colTotalMax = new DataGridViewTextBoxColumn();
            colTotalMax.Name = "TotalMax";
            colTotalMax.HeaderText = "Total";
            colTotalMax.Width = 55;
            colTotalMax.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotalMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colTotalMax);



            //tamaños
            gridDetalle.Columns[0].Width = 30;
            gridDetalle.Columns["Especialidad"].Width = 100;
            gridDetalle.Columns["Asistencia"].Width = 60;
            gridDetalle.Columns["Categoria"].Width = 70;
            gridDetalle.Columns["Apellidos"].Width = 300;



            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns[2].ReadOnly = true;
            gridDetalle.Columns[3].ReadOnly = true;
            gridDetalle.Columns[4].ReadOnly = true;
            gridDetalle.Columns["Total"].ReadOnly = true;
            gridDetalle.Columns["TotalMax"].ReadOnly = true;

            gridDetalle.Columns["TotalMax"].Visible = false;
            gridDetalle.Columns["IDE_PERSONAL"].Visible = false;
            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridDetalle.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Limpiar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            //llenar trabajadores
            BL_CUADRILLA obj = new BL_CUADRILLA();
            DataTable dtResul = new DataTable();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string Padre = string.Empty;
            if (lblEstado.Text == "1")
            {
                gridDetalle.Columns["btn"].Visible = true;
                Padre = cboCapataz.SelectedValue.ToString();
                dtResul = obj.SP_OBTENER_CUADRILLA_X_FECHA(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), cboCapataz.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));


                CANTIDAD_PERSONAL = dtResul.Rows.Count;

                if (dtResul.Rows.Count > 0)
                {
                    //datos vacios
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        int renglon = gridDetalle.Rows.Add();

                        gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                        gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        gridDetalle.Rows[renglon].Cells["Apellidos"].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                        gridDetalle.Rows[renglon].Cells["Especialidad"].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["Categoria"].Value = dtResul.Rows[i]["CATEGORIA"].ToString();

                        string ED = dtResul.Rows[i]["ASISTENCIA"].ToString();
                        if (ED != string.Empty )
                        {
                            gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ASISTENCIA"].ToString();
                        }
                        else
                        {
                            if(AsistenciaPersona == "F")
                            {
                                gridDetalle.Rows[renglon].Cells["Asistencia"].Value = AsistenciaPersona;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                            }
                        }


                        if (ED == "F" || ED == "E") // || ED == "B"
                        {
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }

                        
                        gridDetalle.Rows[renglon].Cells["HNoct"].Value = dtResul.Rows[i]["HNoct"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAlt"].Value = dtResul.Rows[i]["HAlt"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAgua"].Value = dtResul.Rows[i]["HAgua"].ToString();
                        gridDetalle.Rows[renglon].Cells["HTunel"].Value = dtResul.Rows[i]["HTunel"].ToString();


                    }
                }
            }
            else
            {
                string dateString = dateTareo.Value.Date.ToString("dddd");
                gridDetalle.Columns["btn"].Visible = false;
                BL_ASIGNACION_TAREAS objT = new BL_ASIGNACION_TAREAS();
                dtResul = objT.Lista_Personal_tareas_x_fecha(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), cboCapataz.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString);
                CANTIDAD_PERSONAL = dtResul.Rows.Count;
                if (dtResul.Rows.Count > 0)
                {
                    //datos vacios
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        int renglon = gridDetalle.Rows.Add();

                        gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                        gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        gridDetalle.Rows[renglon].Cells["Apellidos"].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                        gridDetalle.Rows[renglon].Cells["Especialidad"].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["Categoria"].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                        //gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();

                        string ED = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();

                        if (ED != string.Empty)
                        {
                            gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();
                        }
                        else
                        {
                            if (AsistenciaPersona == "F")
                            {
                                gridDetalle.Rows[renglon].Cells["Asistencia"].Value = AsistenciaPersona;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                            }
                        }

                        if (ED == "F" || ED == "E") // || ED == "B"
                        {
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }
                        

                        gridDetalle.Rows[renglon].Cells["HNoct"].Value = dtResul.Rows[i]["HNoct"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAlt"].Value = dtResul.Rows[i]["HAlt"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAgua"].Value = dtResul.Rows[i]["HAgua"].ToString();
                        gridDetalle.Rows[renglon].Cells["HTunel"].Value = dtResul.Rows[i]["HTunel"].ToString();

                    }
                }

            }





            //tareo personal
            BL_TAREO Xobj = new BL_TAREO();
            BL_FUNCIONES ObjFuncion = new BL_FUNCIONES();
            DataTable dtResulTareo = new DataTable();
            DataTable dtAsistencia = new DataTable();
            DataTable dtBono = new DataTable();

            string codPersona = null;
            decimal Total = 0;
            decimal TotalBono = 0;

            int filas = Convert.ToInt32(gridDetalle.Rows.Count);
            for (int i = 0; i < filas - 1; i++)
            {
                Total = 0;
                TotalBono = 0;
                codPersona = gridDetalle.Rows[i].Cells[1].Value.ToString();


                /// PARA LAS TAREAS NORMALES ///
                DataTable dtTareas = new DataTable();
                BL_ASIGNACION_TAREAS objTareas = new BL_ASIGNACION_TAREAS();
                dtTareas = objTareas.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));
                int cantidadTareas = dtTareas.Rows.Count;

                if (dtTareas.Rows.Count > 0)
                {
                    for (int mi = 0; mi < dtTareas.Rows.Count; mi++)
                    {
                        try
                        {
                            string codTarea = dtTareas.Rows[mi]["IDE_TAREA"].ToString();//codigo

                            dtResulTareo = Xobj.actividadesPersona_tareo(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), 1, dateTareo.Value.Date.ToString("dd/MM/yyyy"), codPersona, Convert.ToInt32(codTarea));
                            if (dtResulTareo.Rows.Count > 0)
                            {
                                Total = Total + Convert.ToDecimal(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                gridDetalle.Rows[i].Cells[7 + mi].Value = dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString();

                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    gridDetalle.Rows[i].Cells[7 + cantidadTareas].Value = Total;
                }

            }


            
            

            MGridTareo = string.Empty;
            verImagen(MGridTareo);

        }
        public void EstadoDiario()
        {
            BE_TBPARAMETROS objCab = new BE_TBPARAMETROS();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            dt.Clear();
            DataEstadiDiario.Clear();
            LstEstadoDiario.Clear();

            objCab.DES_TABLA = "ASISTENCIA_PERSONAL";
            objCab.DES_CAMPO = "IDE_ESTADO_DIARIO";
            objCab.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            objCab.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            objCab.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            dt = obj.ListarEstadoDiario("ASISTENCIA_PERSONAL", "IDE_ESTADO_DIARIO", objCab.IDE_EMPRESA, objCab.CENTRO_COSTO.ToString(), objCab.FECHA.ToString(), dateTareo.Value.Date.ToString("dddd"));
            if (dt.Rows.Count > 0)
            {
                LstEstadoDiario = new BL_FUNCIONES().f_list_EstadoDiario(objCab);
                foreach (DataRow row in dt.Rows)
                {
                    DataEstadiDiario.Add(Convert.ToString(row["DES_ABREVIADO"]));
                }

            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                DataEstadiDiario.Clear();
            }
        }
        protected void txt_GV_ASISTENCIA_TextChanged(object sender, EventArgs e)
        {
            //gridDetalle.AllowUserToAddRows = false;
            string valor;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            if (colTarea == 5)
            {

                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                if (valor == string.Empty)
                {
                    valor = "FALTA";
                }
                BE_TBPARAMETROS result = LstEstadoDiario.Find(
                delegate (BE_TBPARAMETROS bk)
                {
                    return bk.DES_ABREVIADO == valor;
                }
                );


                if (result != null)
                {
                    gridDetalle.Rows[rowTarea].Cells["Asistencia"].Style.BackColor = Color.White;

                    // agregar horas
                    if (valor == "X")
                    {
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                    }
                    else if (valor == "F")
                    {
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                    }
                    else
                    {


                        //gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        //gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                        int cantidadTareas = gridAsignacion.Rows.Count;
                        for (int j = 5; j <= 8 + cantidadTareas; j++)
                        {

                            try
                            {
                                int num;
                                bool isNumber = int.TryParse(gridDetalle.Columns[j].Name, out num);
                                if (isNumber == true)
                                {
                                    gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                                }
                                else
                                {
                                    if (gridDetalle.Columns[j].Name.Substring(0, 1) == "H")
                                    {
                                        gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                                    }
                                    else if (gridDetalle.Columns[j].Name == "Asistencia")
                                    {
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (valor == "E") //|| valor == "B"
                        {
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }
                    }

                }
                else
                {
                    gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "Error, No existe Estado Diario";
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Value = string.Empty;

                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;

                }

            }
        }
        private void gridDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bKeyPressNum_GV_DATA = false;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            if (colTarea == 5) //ASISTENCIA
            {
                txt_GV_DATA.ReadOnly = false;
                bKeyPressNum_GV_DATA = false;
                if (txt_GV_DATA != null)
                {
                    rowTarea = gridDetalle.CurrentCell.RowIndex;
                    txt_GV_DATA.TextChanged += txt_GV_ASISTENCIA_TextChanged;
                }
            }

            else
            {
                rowTarea = gridDetalle.CurrentCell.RowIndex;

                string valorAsistencia = (gridDetalle.Rows[rowTarea].Cells["Asistencia"].Value == null) ? "" : gridDetalle.Rows[rowTarea].Cells["Asistencia"].Value.ToString();
                if (valorAsistencia == "F" || valorAsistencia == "X")
                {

                    txt_GV_DATA.ReadOnly = false;
                    int num;
                    bool isNumber = int.TryParse(gridDetalle.Columns[colTarea].Name, out num);

                    if (isNumber == true)
                    {
                        bKeyPressNum_GV_DATA = true;
                        if (txt_GV_DATA != null)
                        {
                            txt_GV_DATA.MaxLength = 4;
                            rowTarea = gridDetalle.CurrentCell.RowIndex;
                            txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                            txt_GV_DATA.TextChanged += txt_AcumuladoHras_TextChanged;
                        }
                    }
                    else
                    {
                        if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
                        {
                            bKeyPressNum_GV_DATA = true;
                            if (txt_GV_DATA != null)
                            {
                                txt_GV_DATA.MaxLength = 4;
                                rowTarea = gridDetalle.CurrentCell.RowIndex;
                                txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                                txt_GV_DATA.TextChanged += txt_BonoHras_TextChanged;
                            }
                        }
                    }
                }

                else
                {
                    txt_GV_DATA.ReadOnly = true;
                }

            }

            txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
        }
        protected void txt_AcumuladoBonos_TextChanged(object sender, EventArgs e)
        {
            double Acumulado = 0;
            string valor = null;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            var box = (TextBox)sender;
            //grabar acumulado bonos
            DataGridViewRow rowx = gridDetalle.Rows[rowTarea];
            gridDetalle.Rows[rowTarea].Cells[colTarea].Value = box.Text;

            for (int j = 0; j <= gridDetalle.ColumnCount; j++)
            {

                try
                {
                    valor = string.Empty;
                    //valor =
                    if (gridDetalle.Columns[j].Name.Substring(0, 1) == "H")
                    {
                        valor = (rowx.Cells[j].Value == null) ? "0" : rowx.Cells[j].Value.ToString();
                        if (valor == string.Empty)
                        {
                            valor = "0";
                        }
                        Acumulado = Acumulado + Convert.ToDouble(valor);
                    }
                }
                catch (Exception ex)
                {

                }

                if (Acumulado > BonoMaxima)
                {
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Style.BackColor = Color.Red;
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Style.ForeColor = Color.White;
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Value = Acumulado;
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].ToolTipText = "No se permiten horas superior a " + Convert.ToString(BonoMaxima) + " Hrs.";
                }
                else
                {
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Value = Acumulado;
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Style.BackColor = Color.FromArgb(218, 247, 166);
                    gridDetalle.Rows[rowTarea].Cells["TotalMax"].Style.ForeColor = Color.Black;
                }

                double TotalMax = Convert.ToDouble(gridDetalle.Rows[rowTarea].Cells["TotalMax"].Value);
                double Total = Convert.ToDouble(gridDetalle.Rows[rowTarea].Cells["Total"].Value);
                if (TotalMax + Total > HoraMaxima)
                {
                    gridDetalle.Rows[rowTarea].DefaultCellStyle.ForeColor = Color.White;
                    gridDetalle.Rows[rowTarea].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    gridDetalle.Rows[rowTarea].DefaultCellStyle.ForeColor = Color.Black;
                    gridDetalle.Rows[rowTarea].DefaultCellStyle.BackColor = Color.White;
                }

            }
        }
        protected void txt_AcumuladoHras_TextChanged(object sender, EventArgs e)
        {
            double Acumulado = 0;
            string valor = null;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            var box = (TextBox)sender;
            //grabar tareas
            DataGridViewRow rowx = gridDetalle.Rows[rowTarea];
            gridDetalle.Rows[rowTarea].Cells[colTarea].Value = box.Text;
            int cantidadTareas = gridAsignacion.Rows.Count;
            for (int j = 7; j <= 7 + cantidadTareas; j++)
            {

                try
                {
                    valor = string.Empty;
                    int num;
                    bool isNumber = int.TryParse(gridDetalle.Columns[j].Name, out num);
                    //valor =
                    if (isNumber == true)
                    {
                        valor = (rowx.Cells[j].Value == null) ? "0" : rowx.Cells[j].Value.ToString();
                        if (valor == string.Empty)
                        {
                            valor = "0";
                        }

                        if (Convert.ToDouble(valor) > HoraMaxima)
                        {
                            gridDetalle.Rows[rowTarea].Cells[j].Style.BackColor = Color.Red;
                            gridDetalle.Rows[rowTarea].Cells[j].Style.ForeColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells[j].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                        }
                        else
                        {
                            gridDetalle.Rows[rowTarea].Cells[j].Style.BackColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells[j].Style.ForeColor = Color.Black;
                        }


                        Acumulado = Acumulado + Convert.ToDouble(valor);



                        if (Acumulado > HoraMaxima)
                        {
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.Red;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Value = Acumulado;
                            gridDetalle.Rows[rowTarea].Cells["Total"].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                        }
                        else
                        {
                            gridDetalle.Rows[rowTarea].Cells["Total"].Value = Acumulado;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.FromArgb(218, 247, 166);
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.Black;

                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        protected void txt_EstadoDiario_TextChanged(object sender, EventArgs e)
        {

            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            string valor;

            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
            valor = box.Text;


            if (colTarea == 5)
            {
                //if (valor != string.Empty)
                //{
                if (valor == "X")
                {
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                }
                else if (valor == "F")
                {
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                }
                else
                {


                    //gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                    //gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;

                    for (int j = 5; j <= gridDetalle.ColumnCount; j++)
                    {

                        try
                        {
                            int num;
                            bool isNumber = int.TryParse(gridDetalle.Columns[j].Name, out num);
                            if (isNumber == true)
                            {
                                gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                            }
                            else
                            {
                                if (gridDetalle.Columns[j].Name.Substring(0, 1) == "H")
                                {
                                    gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                                }
                                else if (gridDetalle.Columns[j].Name == "Asistencia")
                                {
                                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (valor == "E") //|| valor == "B"
                    {
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                    }
                }
            }
        }
        protected void txt_TrabajoHras_TextChanged(object sender, EventArgs e)
        {
            int num;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            string valor;
            var box = (TextBox)sender;
            bool isNumber = int.TryParse(gridDetalle.Columns[colTarea].Name, out num);

            if (isNumber == true)
            {
                rowTarea = gridDetalle.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                if (valor != string.Empty)
                {
                    //Rows.Cells[3].Value = label14.Text;
                    if (Convert.ToDouble(valor) > HoraMaxima)
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                    }
                    else
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.Black;
                    }
                }
            }

        }
        protected void txt_BonoHras_TextChanged(object sender, EventArgs e)
        {

            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            string valor;

            var box = (TextBox)sender;


            if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
            {
                rowTarea = gridDetalle.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                if (valor != string.Empty)
                {
                    if (Convert.ToDouble(valor) > BonoMaxima)
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "No se permiten horas superior a " + Convert.ToString(BonoMaxima) + " Hrs.";
                    }
                    else
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.Black;
                    }

                }
            }

        }

        


        private void gridAsignacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (gridAsignacion.Rows.Count > 0)
            //{
            //    MGridActividad = "Update";
            //    btnGuardarActividad.Image = global::WinForms.Properties.Resources.botonTareasGIF;
            //    btnGuardarActividad.Text = string.Empty;
            //    verImagen( MGridActividad);
            //}
            //else
            //{
            //    btnGuardarActividad.Text = "Guardar &Tareas";
            //    MGridActividad = string.Empty;

            //}
        }
        protected void verImagen(string control)
        {
            if (control == "Update")
            {


                cboEmpresa.Enabled = false;
                cboCentroCosto.Enabled = false;
                cboAnio.Enabled = false;
                cboMes.Enabled = false;
                cboSemana.Enabled = false;
                cboIngeniero.Enabled = false;
                cboCapataz.Enabled = false;
                dateTareo.Enabled = false;
            }
            else
            {

                cboEmpresa.Enabled = true;
                cboCentroCosto.Enabled = true;
                cboAnio.Enabled = true;
                cboMes.Enabled = true;
                cboSemana.Enabled = true;
                cboIngeniero.Enabled = true;
                cboCapataz.Enabled = true;
                dateTareo.Enabled = true;
            }
        }



       
        private void frmControlTareo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (imageActividad.Visible == true || imagenTareo.Visible == true)
            //{
            //    bSalir = true;
            //}

            if (bSalir == false)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea salir del formulario?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            //else
            //{


            //        DialogResult respuesta = MessageBox.Show("¿Existen registros por guardar, Esta seguro que desea Salir del Formulario?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (respuesta != DialogResult.Yes)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        e.Cancel = false;
            //    }
            //}
        }

        private void imageActividad_Click(object sender, EventArgs e)
        {
            btnGuardarActividad.PerformClick();
        }

        private void imagenTareo_Click(object sender, EventArgs e)
        {
            btnGuardarTareo.PerformClick();
        }

        private void gridDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblEstado.Text == "1")
            {
                if ((e.Control && e.KeyCode == Keys.Delete) )//|| (e.Shift && e.KeyCode == Keys.Delete) || e.KeyCode == Keys.Delete)
                {
                    int iRow = gridDetalle.CurrentCell.RowIndex;
                    DataGridViewRow Rows = gridDetalle.Rows[iRow];

                    string Persona = ((Rows.Cells["Apellidos"].Value == null) ? "" : Rows.Cells["Apellidos"].Value.ToString());
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar de la cuadrilla y sus horas de trabajo al " + Environment.NewLine +
                        "Sr. " + Persona + " ?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        GrabarDigitacionDelete();
                        string ID_PERSONAL = ((Rows.Cells["IDE_PERSONAL"].Value == null) ? "0" : Rows.Cells["IDE_PERSONAL"].Value.ToString());

                        BL_TAREO obj = new BL_TAREO();
                        DataTable dtResulTareo = new DataTable();

                        dtResulTareo = obj.SP_ELIMINAR_TAREO_PERSONA(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), ID_PERSONAL, cboCapataz.SelectedValue.ToString());
                        if (dtResulTareo.Rows.Count > 0)
                        {
                            //e.SuppressKeyPress = (e.KeyData = Keys.Delete);
                            listarCuadrilla();
                            MessageBox.Show("Registro eliminado", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar esta operación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    int iRow = gridDetalle.CurrentCell.RowIndex;
                    int icol = gridDetalle.CurrentCell.ColumnIndex ;
                    DataGridViewRow Rows = gridDetalle.Rows[iRow];
                    if (icol > 4)
                    {
                        Rows.Cells[icol].Value = string.Empty;
                    }
                   
                }

            }
            else
            {
                MessageBox.Show("No se puede realizar esta operación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //if ((e.Control && e.KeyCode == Keys.Insert) || (e.Shift && e.KeyCode == Keys.Insert))
            //{
            //    PasteClipboard();
            //}




        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyClipboard();
        }
        private void CopyClipboard()
        {
            DataObject d = gridDetalle.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }
        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboard();
        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = gridDetalle.CurrentCell.RowIndex;
                int iCol = gridDetalle.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < gridDetalle.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.gridDetalle.ColumnCount)
                            {
                                oCell = gridDetalle[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    string valor = (oCell.Value == null) ? "0" : oCell.Value.ToString();
                                    if (valor == string.Empty)
                                    {
                                        valor = "0";
                                    }
                                    if (valor != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        //oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                        iFail++;//only traps a fail if the data has changed and you are pasting into a read only cell
                                }
                            }
                            else
                            { break; }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    //if (iFail > 0)
                    //    MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {

                btnGuardarActividad.PerformClick();
            }
            if (keyData == Keys.F2)
            {
                btnGuardarTareo.PerformClick();
            }
            if (keyData == Keys.F4)
            {
                btnBuscar.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFile.SelectedIndex > 0)
                {
                    ListarActividadesAsignadas();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAvanceEstructura_Click(object sender, EventArgs e)
        {
            obj_Tareas_E = new BE_ASIGNACION_TAREAS();

            obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            obj_Tareas_E.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
            obj_Tareas_E.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
            obj_Tareas_E.FLG_ESTADO = Convert.ToInt32(lblEstado.Text);
            obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            frmEstructuraConsumo f2 = new frmEstructuraConsumo(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }

        private void btnAvance_Click(object sender, EventArgs e)
        {
            obj_Tareas_E = new BE_ASIGNACION_TAREAS();

            obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            obj_Tareas_E.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
            obj_Tareas_E.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
            obj_Tareas_E.FLG_ESTADO = Convert.ToInt32(lblEstado.Text);
            obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            obj_Tareas_E.IDE_DISCIPLINA = Convert.ToInt32(cboFile.SelectedValue);
            IngenieroAvance f2 = new IngenieroAvance(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }

     

        private void btnReporte_Click(object sender, EventArgs e)
        {
            obj_Tareas_E = new BE_ASIGNACION_TAREAS();

            obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            obj_Tareas_E.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
            obj_Tareas_E.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
            obj_Tareas_E.FLG_ESTADO = Convert.ToInt32(lblEstado.Text);
            obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            obj_Tareas_E.IDE_DISCIPLINA = Convert.ToInt32(cboFile.SelectedValue);
            frmControlTareoReporte f2 = new frmControlTareoReporte(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }


        //eliminar
        private void gridAsignacion_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.gridAsignacion.Rows[e.RowIndex].Selected = true;
                //  this.rowIndex = e.RowIndex;
                this.gridAsignacion.CurrentCell = this.gridAsignacion.Rows[e.RowIndex].Cells[1];
                //this.contextMenuStrip1.Show(this.gridAsignacion, e.Location);
                //contextMenuStrip1.Show(Cursor.Position);
            }
        }

        //private void contextMenuStrip1_Click(object sender, EventArgs e)
        //{
        //    if (!this.gridAsignacion.Rows[this.rowIndex].IsNewRow)
        //    {
        //        this.gridAsignacion.Rows.RemoveAt(this.rowIndex);
        //    }
        //}


        private void btnDigitacion_Click(object sender, EventArgs e)
        {
           if (lblEstado.Text == "label")
            {
                MessageBox.Show("Seleccionar fecha de tareo a consultar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                obj_Tareo_E = new BE_ASIGNACION_TAREO();
                obj_Tareo_E.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                obj_Tareo_E.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                obj_Tareo_E.FEC_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                obj_Tareo_E.FLG_ESTADO = Convert.ToInt32(lblEstado.Text);
                obj_Tareo_E.NOMBRE_DIA = dateTareo.Value.Date.ToString("dddd");
                obj_Tareo_E.IDE_DISCIPLINA = Convert.ToInt32(cboFile.SelectedValue);
                obj_Tareo_E.DISCIPLINA = cboFile.Text;



                string ls_error = "";
                UserCode.Conexion cn = new UserCode.Conexion();

                bool lb_conectado = cn.ProbarConexion(ref ls_error);

                if (lb_conectado == true)
                {
                    frmControlTareoTodo f2 = new frmControlTareoTodo(); //creamos un objeto del formulario hijo
                    DialogResult res = f2.ShowDialog();
                    if (f2.varfNuevo > 0)
                    {
                        listarCuadrilla();
                    }
                }
                else
                {
                    MessageBox.Show(ls_error);
                }
            }
        }

        private void btnListarCuadrilla_Click(object sender, EventArgs e)
        {
            if (lblEstado.Text == "1")
            {

                  DialogResult respuesta = MessageBox.Show("¿Desea listar la última cuadrilla del " + Environment.NewLine +
                        "Sr. " + cboCapataz.Text   + " ?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    BL_TAREO obj = new BL_TAREO();

                    DataTable dtResulTareo = new DataTable();

                    dtResulTareo = obj.SP_CARGA_ULTIMA_CUADRILLA(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"),  cboCapataz.SelectedValue.ToString());
                    if (dtResulTareo.Rows.Count > 0)
                    {
                        listarCuadrilla();
                        MessageBox.Show("Actualización satisfactoria", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
                    else
                    {
                        MessageBox.Show("Existen problema con el llenado de cuadrilla", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    
                }
               
            }
            else
            {
                MessageBox.Show("No se puede realizar esta operación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardarActividad_Click(object sender, EventArgs e)
        {
            string observa = string.Empty;
            string area = string.Empty;
            //string programado = null;
            //string ejecutado = null;
            int rpta, rptaTareas;
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea grabar actividades?", "Grabar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    EstadoDiario();
                    if (lblEstado.Text == "1")
                    {
                        BE_ASIGNACION_TAREO obj = new BE_ASIGNACION_TAREO();
                        obj = f_datosCabecera();
                        rpta = new BL_ASIGNACION_TAREO().Mant_Insert_Tareo(obj);

                        if (rpta > 0)
                        {
                            try
                            {
                                BE_ASIGNACION_TAREAS objTarea = new BE_ASIGNACION_TAREAS();
                                foreach (DataGridViewRow Rows in gridAsignacion.Rows)
                                {
                                    lblIdTareo.Text = rpta.ToString();
                                    //observa = (Rows.Cells["Observaciones"].Value == null) ? "" : Rows.Cells["Observaciones"].Value.ToString();
                                    //area = (Rows.Cells["Areas"].Value == null) ? "" : Rows.Cells["Areas"].Value.ToString();

                                    //if (Rows.Cells["Programado"].Value == null)
                                    //{
                                    //    programado = "0";
                                    //}
                                    //else if (Rows.Cells["Programado"].Value.ToString() == "")
                                    //{
                                    //    programado = "0";
                                    //}
                                    //else
                                    //{
                                    //    programado = Rows.Cells["Programado"].Value.ToString();
                                    //}

                                    //if (Rows.Cells["Ejecutado"].Value == null)
                                    //{
                                    //    ejecutado = "0";
                                    //}
                                    //else if (Rows.Cells["Ejecutado"].Value.ToString() == "")
                                    //{
                                    //    ejecutado = "0";
                                    //}
                                    //else
                                    //{
                                    //    ejecutado = Rows.Cells["Ejecutado"].Value.ToString();
                                    //}

                                    //programado = (Rows.Cells["Programado"].Value.ToString() == "") ? "0" : Rows.Cells["Programado"].Value.ToString();
                                    //ejecutado = (Rows.Cells["Ejecutado"].Value.ToString() == "") ? "0" : Rows.Cells["Ejecutado"].Value.ToString();

                                    //registro detalle

                                    objTarea.IDE_TAREA = Convert.ToInt32(string.IsNullOrEmpty(lblidTareas.Text) ? "0" : lblidTareas.Text);
                                    objTarea.IDE_TAREO_ASIGNACION = Convert.ToInt32(lblIdTareo.Text);
                                    objTarea.ITEM_ACTIVIDAD = 0;
                                    objTarea.IDE_ACTIVIDAD = Rows.Cells["IDE_ACTIVIDAD"].Value.ToString();
                                    objTarea.DET_TAREA = string.Empty;// Rows.Cells["DET_TAREA"].Value.ToString();
                                    objTarea.ID_FRENTE = Rows.Cells["ID_FRENTE"].Value.ToString();
                                    objTarea.CTA_COSTO = Rows.Cells["CTA_COSTO"].Value.ToString();
                                    objTarea.DES_TAREA = string.Empty;
                                    objTarea.DES_UNIDAD = Rows.Cells["DES_UNIDAD"].Value.ToString();
                                    objTarea.HORA_INICIO = string.Empty;
                                    objTarea.HORA_FIN = string.Empty;
                                    objTarea.PROGRAMADO = 0;
                                    objTarea.EJECUTADO = 0;
                                    objTarea.FLG_ESTADO = 1;
                                    objTarea.OBSERVACIONES = observa.ToString();
                                    objTarea.DES_AREAS = area.ToString();
                                    objTarea.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
                                    objTarea.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
                                    objTarea.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();

                                    //bool isSelected = Convert.ToBoolean(Rows.Cells["checkBoxRT"].Value);
                                    objTarea.RETRABAJO = false;// isSelected;
                                    objTarea.DES_ACTIVIDAD = string.Empty;
                                    objTarea.DES_FRENTE = string.Empty;
                                    objTarea.PK_TAREA = Rows.Cells["PK_TAREA"].Value.ToString();
                                    objTarea.IDE_DISCIPLINA = Convert.ToInt32(cboFile.SelectedValue);
                                    rptaTareas = new BL_ASIGNACION_TAREO().Mant_Insert_TareasActividades(objTarea);
                                    if (rptaTareas > 0)
                                    {
                                        lblidTareas.Text = rptaTareas.ToString();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("Se presentaron problemas al procesar la información", "Registro de Actividades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //return;
                            }
                            //btnGuardarActividad.Image = global::WinForms.Properties.Resources.botonTareas;
                            MGridActividad = string.Empty;

                            verImagen(MGridActividad);
                            MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ListarActividadesAsignadas();
                        //ActividadesProyectos();
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar modificaciones, Tareo Procesado", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            else
            {

                MessageBox.Show(ls_error);

            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            new FrmEstadoDiario().ShowDialog();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {


                if (cboFile.SelectedIndex < 1)
                {
                    MessageBox.Show("Seleccionar modo de tareo");
                    return;
                }
                else
                {
                    obj_Tareo_E = new BE_ASIGNACION_TAREO();
                    obj_Tareo_E.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                    obj_Tareo_E.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                    int valor = 0;
                    if (cboFile.SelectedIndex == 0)
                    {
                        valor = 0;
                    }
                    else
                    {
                        valor = Convert.ToInt32(cboFile.SelectedValue);
                    }

                    obj_Tareo_E.TIPO = Convert.ToInt32(valor);
                    //new frmCronograma().ShowDialog();
                    frmCronograma f2 = new frmCronograma(); //creamos un objeto del formulario hijo
                    DialogResult res = f2.ShowDialog();

                    if (f2.varfActividad != string.Empty)
                    {
                        PosicionarActvidad(
                            f2.varfDesActividad,
                            f2.varfActividad,
                            f2.varfCodActividad,
                            f2.varfTareo,
                            f2.varfCodTareo,
                            f2.varfDesTareo,
                            f2.varfCodFrente,
                            f2.varfDesFrente,
                            f2.varfCtaCosto,
                            f2.varfUnidad,
                            f2.varfCODIGO_TAREA,
                            f2.varfPK_TAREA);
                    }
                }
            }
            else
            {
                MessageBox.Show(ls_error);
            }
        }
        protected void PosicionarActvidad(
           string DesActividad,
           string Actividad,
           string codActividad,
           string Tarea,
           string CodTarea,
           string DesTarea,
           string frente,
           string DesFrente,
           string CtaCosto,
           string Unidad,
           string CODIGO_TAREA,
           string PK_TAREA)

        {
            for (int i = 0; i < gridAsignacion.Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)gridAsignacion.Rows[i].Clone();
                try
                {
                    //string Valor = (row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString();
                    string Valor = (gridAsignacion.Rows[i].Cells["DESCRIPCION"].Value == null) ? "" : gridAsignacion.Rows[i].Cells["DESCRIPCION"].Value.ToString();
                    if (Valor == string.Empty)
                    {
                        //gridAsignacion.Rows[i].Cells[1].Value = Actividad;
                        //row.Cells[1].Value = Actividad;
                        //row.Cells[2].Value = Tarea;
                        //gridAsignacion.Rows.Add(row);
                        gridAsignacion.Rows[i].Cells["DESCRIPCION"].Value = DesActividad;
                        gridAsignacion.Rows[i].Cells["IDE_ACTIVIDAD"].Value = codActividad;
                        gridAsignacion.Rows[i].Cells["DESCRIPCION_TAREA"].Value = DesTarea;


                        //gridAsignacion.Rows[i].Cells["DESCRIPCION_TAREA"].Value = DesTarea;
                        //gridAsignacion.Rows[i].Cells["ID_TAREA"].Value = CodTarea;
                        //gridAsignacion.Rows[i].Cells["DES_TAREA"].Value = Tarea;

                        gridAsignacion.Rows[i].Cells["ID_FRENTE"].Value = frente;
                        gridAsignacion.Rows[i].Cells["CTA_COSTO"].Value = CtaCosto;
                        gridAsignacion.Rows[i].Cells["DES_UNIDAD"].Value = Unidad;
                        //gridAsignacion.Rows[i].Cells["DES_FRENTE"].Value = DesFrente;
                        //gridAsignacion.Rows[i].Cells["Programado"].Value = "0";
                        //gridAsignacion.Rows[i].Cells["Ejecutado"].Value = "0";
                        gridAsignacion.Rows[i].Cells["PK_TAREA"].Value = PK_TAREA;

                        break;
                    }
                }
                catch (Exception ex)
                {

                }
            }


            //DataGridViewRow row = (DataGridViewRow)gridAsignacion.Rows[0].Clone();
            ////row.Cells[1].Value = Actividad;
            //gridAsignacion.Rows[0].Cells[1].Value = Actividad;
            //gridAsignacion.Rows.Add(row);

        }

        private void btnConsultaPersona_Click_1(object sender, EventArgs e)
        {
            obj_Tareas_E = new BE_ASIGNACION_TAREAS();

            obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);

            frmBuscarPersona f2 = new frmBuscarPersona(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }

        private void btnPersonal_Click_1(object sender, EventArgs e)
        {
            //new frmCuadrilla().ShowDialog();
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                obj_Tareo_E = new BE_ASIGNACION_TAREO();
                obj_Tareo_E.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                obj_Tareo_E.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                obj_Tareo_E.FEC_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");

                frmCuadrilla f2 = new frmCuadrilla(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varfNuevo > 0)
                {
                    listarCuadrilla();
                }
            }
            else
            {
                MessageBox.Show(ls_error);
            }
        }

        private void btnGuardarTareo_Click(object sender, EventArgs e)
        {
            GrabarDigitacion();
        }
        protected void GrabarDigitacion()
        {
            int faltaEstado = 0;
            string ls_error = "";
            int SinHoras = 0;
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {

                for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                {
                    try
                    {
                        string dia = dateTareo.Value.Date.ToString("dddd").ToUpper();
                        string estadoAsistencia = string.Empty;
                        if (dia == "DOMINGO")
                        {
                            estadoAsistencia = "X";
                        }
                        else
                        {
                            estadoAsistencia = AsistenciaPersona;
                        }

                        string estadoDiario = (gridDetalle.Rows[p].Cells["Asistencia"].Value == null) ? "" : gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString();
                        if (estadoDiario == "")
                        {
                            faltaEstado++;
                        }

                        if ((gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString() == "X") && (gridDetalle.Rows[p].Cells["Total"].Value.ToString() == "0") && estadoAsistencia == "")
                        {
                            SinHoras++;
                        }

                        
                    }
                    catch (Exception ex)
                    {

                    }

                }

                if (faltaEstado > 0)
                {

                    MessageBox.Show("Existen " + (faltaEstado).ToString() + " Obrero(s) sin asignación de trabajo(s)", "Falta Ingresar Estado Diario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                DialogResult respuesta = MessageBox.Show("¿Desea grabar tareo?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {

                    int CantError = 0;
                    ////////////////////
                    foreach (DataGridViewRow xRows in gridDetalle.Rows)
                    {
                        //grabar tareas
                        try
                        {
                            DataGridViewRow rowx = gridDetalle.Rows[xRows.Index];
                            for (int j = 0; j <= gridDetalle.ColumnCount - 1; j++)
                            {

                                string color = gridDetalle.Rows[rowx.Index].Cells[j].Style.BackColor.ToString();
                                if (color == "Color [Red]")
                                {
                                    CantError++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (SinHoras > 0)
                    {
                        MessageBox.Show("Existen " + SinHoras.ToString() + " obrero(s) sin horas de trabajo, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (CantError == 0)
                        {
                            //////////////////
                            string valor, persona, asistencia;
                            int registros = 0;
                            string CAPATAZ = string.Empty;
                            string INGENIERO = string.Empty;

                            INGENIERO = cboIngeniero.SelectedValue.ToString();
                            CAPATAZ = cboCapataz.SelectedValue.ToString();

                            //TAREAS
                            DataTable dtTareas = new DataTable();
                            BL_ASIGNACION_TAREAS objTareas = new BL_ASIGNACION_TAREAS();
                            dtTareas = objTareas.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));
                            int cantidadTareas = dtTareas.Rows.Count;

                            for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                            {
                                

                                //grabar tareas
                                DataGridViewRow rowx = gridDetalle.Rows[p];
                                persona = string.IsNullOrEmpty(rowx.Cells["IDE_PERSONAL"].Value.ToString()) ? "0" : rowx.Cells["IDE_PERSONAL"].Value.ToString();// persona
                                asistencia = (rowx.Cells["Asistencia"].Value == null) ? "FALTA" : rowx.Cells["Asistencia"].Value.ToString();

                                

                                if (dtTareas.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtTareas.Rows.Count; i++)
                                    {

                                        string codTarea = dtTareas.Rows[i]["IDE_TAREA"].ToString();//codigo


                                        try
                                        {
                                            if (rowx.Cells[7 + i].Value == null)
                                            {
                                                valor = "0";
                                            }
                                            else if (rowx.Cells[7 + i].Value.ToString() == string.Empty)
                                            {
                                                valor = "0";
                                            }
                                            else
                                            {
                                                valor = rowx.Cells[7 + i].Value.ToString();
                                            }


                                            if (Convert.ToDecimal(valor) >= 0)
                                            {


                                                BE_TAREO Obj = new BE_TAREO();
                                                Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                                Obj.IDE_TAREA = Convert.ToInt32(codTarea);
                                                Obj.DES_DNI = persona;
                                                Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                                Obj.IDE_INGCAMPO = INGENIERO;
                                                Obj.IDE_CAPATAZ = CAPATAZ;
                                                Obj.FLG_ESTADO = true;
                                                Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                                Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                                Obj.TIPO = 1;
                                                Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                                Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                                Obj.IDE_BONIFICACION = 0;
                                                Obj.DES_ASISTENCIA = asistencia;
                                                int rpta;
                                                rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                                if (rpta > 0)
                                                {
                                                    valor = string.Empty;
                                                    registros++;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }
                                /////////////////// FIN DE LAS TAREAS ////////////////////


                                //BL_FUNCIONES Fobj = new BL_FUNCIONES();
                                //DataTable dtBonificacion = new DataTable();
                                //dtBonificacion = Fobj.ListarBonificacion(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue));

                                //if (dtBonificacion.Rows.Count > 0)
                                //{
                                for (int i = 0; i < 4; i++)
                                {
                                    string codBono = string.Empty;
                                    try
                                    {
                                        if (i==0)
                                        {
                                            codBono = "35";
                                        }
                                        else if (i == 1)
                                        {
                                            codBono = "36";
                                        }
                                        else if (i == 2)
                                        {
                                            codBono = "37";
                                        }
                                        else if (i == 3)
                                        {
                                            codBono = "38";
                                        }

                                        

                                        if (rowx.Cells[8 + cantidadTareas + i].Value == null)
                                        {
                                            valor = "0";
                                        }
                                        else if (rowx.Cells[8 + cantidadTareas + i].Value.ToString() == string.Empty)
                                        {
                                            valor = "0";
                                        }
                                        else
                                        {
                                            valor = rowx.Cells[8 + cantidadTareas + i].Value.ToString();
                                        }

                                        BE_TAREO Obj = new BE_TAREO();
                                        Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                        Obj.IDE_TAREA = 0;
                                        Obj.DES_DNI = persona;
                                        Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                        Obj.IDE_INGCAMPO = INGENIERO;
                                        Obj.IDE_CAPATAZ = CAPATAZ;

                                        Obj.FLG_ESTADO = true;
                                        Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                        Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                        Obj.TIPO = 2;
                                        Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                        Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                        Obj.IDE_BONIFICACION = Convert.ToInt32(codBono);
                                        Obj.DES_ASISTENCIA = asistencia;
                                        int rpta;
                                        rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                        if (rpta > 0)
                                        {
                                            registros++;
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                //}

                                //////// FIN DE LOS BONOS ////////////////7



                                // REGISTRO DE ASITENCIAS
                                BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                                ObjAsistencia.IDE_ASISTENCIA = 0;
                                ObjAsistencia.IDE_PERSONAL = persona;
                                ObjAsistencia.FEC_ASISTENCIA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                ObjAsistencia.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                ObjAsistencia.IDE_ESTADO = asistencia;
                                ObjAsistencia.SUPERVISOR = CAPATAZ;
                                int rptAsistencia;
                                rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);




                            }
                            if (registros > 0)
                            {
                                MGridTareo = string.Empty;

                                verImagen(MGridTareo);
                                MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            listarCuadrilla();
                        }
                        else
                        {
                            MessageBox.Show("Existen inconsistencia en la digitación, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show(ls_error);

            }
        }
        protected void GrabarDigitacionDelete()
        { 
            //Guardar antes de borrar
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();
            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {


                int CantError = 0;
                ////////////////////
                foreach (DataGridViewRow xRows in gridDetalle.Rows)
                {
                    //grabar tareas
                    try
                    {
                        DataGridViewRow rowx = gridDetalle.Rows[xRows.Index];
                        for (int j = 0; j <= gridDetalle.ColumnCount - 1; j++)
                        {

                            string color = gridDetalle.Rows[rowx.Index].Cells[j].Style.BackColor.ToString();
                            if (color == "Color [Red]")
                            {
                                CantError++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }


                if (CantError == 0)
                {
                    //////////////////
                    string valor, persona, asistencia, HrsTotalNormales;
                    int registros = 0;

                    DataTable dtTareas = new DataTable();
                    string CAPATAZ = string.Empty;
                    string INGENIERO = string.Empty;

                    INGENIERO = cboIngeniero.SelectedValue.ToString();
                    CAPATAZ = cboCapataz.SelectedValue.ToString();

                    BL_ASIGNACION_TAREAS objTareas = new BL_ASIGNACION_TAREAS();
                    dtTareas = objTareas.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), CAPATAZ, cboIngeniero.SelectedValue.ToString(), Convert.ToInt32(cboFile.SelectedValue));
                    int cantidadTareas = dtTareas.Rows.Count;

                    for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                    {
                        


                        //grabar tareas
                        DataGridViewRow rowx = gridDetalle.Rows[p];
                        persona = string.IsNullOrEmpty(rowx.Cells["IDE_PERSONAL"].Value.ToString()) ? "0" : rowx.Cells["IDE_PERSONAL"].Value.ToString();// persona
                        asistencia = (rowx.Cells["Asistencia"].Value == null) ? string.Empty  : rowx.Cells["Asistencia"].Value.ToString();
                        HrsTotalNormales = (rowx.Cells["Asistencia"].Value == null) ? "0" : rowx.Cells["Total"].Value.ToString();
                        //TAREAS
                        if (asistencia == "X" && Convert.ToDouble (HrsTotalNormales) > 0 || asistencia == "B" || asistencia == "E")
                        {
                            

                            if (dtTareas.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtTareas.Rows.Count; i++)
                                {

                                    string codTarea = dtTareas.Rows[i]["IDE_TAREA"].ToString();//codigo


                                    try
                                    {
                                        if (rowx.Cells[7 + i].Value == null)
                                        {
                                            valor = "0";
                                        }
                                        else if (rowx.Cells[7 + i].Value.ToString() == string.Empty)
                                        {
                                            valor = "0";
                                        }
                                        else
                                        {
                                            valor = rowx.Cells[7 + i].Value.ToString();
                                        }


                                        if (Convert.ToDecimal(valor) >= 0)
                                        {


                                            BE_TAREO Obj = new BE_TAREO();
                                            Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                            Obj.IDE_TAREA = Convert.ToInt32(codTarea);
                                            Obj.DES_DNI = persona;
                                            Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                            Obj.IDE_INGCAMPO = INGENIERO;
                                            Obj.IDE_CAPATAZ = CAPATAZ;
                                            Obj.FLG_ESTADO = true;
                                            Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                            Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                            Obj.TIPO = 1;
                                            Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                            Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                            Obj.IDE_BONIFICACION = 0;
                                            Obj.DES_ASISTENCIA = asistencia;
                                            int rpta;
                                            rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                            if (rpta > 0)
                                            {
                                                valor = string.Empty;
                                                registros++;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            /////////////////// FIN DE LAS TAREAS ////////////////////


                            //BL_FUNCIONES Fobj = new BL_FUNCIONES();
                            //DataTable dtBonificacion = new DataTable();
                            //dtBonificacion = Fobj.ListarBonificacion(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue));

                            //if (dtBonificacion.Rows.Count > 0)
                            //{
                            for (int i = 0; i < 4; i++)
                            {

                                try
                                {
                                    string codBono = string.Empty;
                                    if (i == 0)
                                    {
                                        codBono = "35";
                                    }
                                    else if (i == 1)
                                    {
                                        codBono = "36";
                                    }
                                    else if (i == 2)
                                    {
                                        codBono = "37";
                                    }
                                    else if (i == 3)
                                    {
                                        codBono = "38";
                                    }

                                    if (rowx.Cells[8 + cantidadTareas + i].Value == null)
                                    {
                                        valor = "0";
                                    }
                                    else if (rowx.Cells[8 + cantidadTareas + i].Value.ToString() == string.Empty)
                                    {
                                        valor = "0";
                                    }
                                    else
                                    {
                                        valor = rowx.Cells[8 + cantidadTareas + i].Value.ToString();
                                    }

                                    BE_TAREO Obj = new BE_TAREO();
                                    Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                    Obj.IDE_TAREA = 0;
                                    Obj.DES_DNI = persona;
                                    Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                    Obj.IDE_INGCAMPO = INGENIERO;
                                    Obj.IDE_CAPATAZ = CAPATAZ;

                                    Obj.FLG_ESTADO = true;
                                    Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                    Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                    Obj.TIPO = 2;
                                    Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                    Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                    Obj.IDE_BONIFICACION = Convert.ToInt32(codBono);
                                    Obj.DES_ASISTENCIA = asistencia;
                                    int rpta;
                                    rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                    if (rpta > 0)
                                    {
                                        registros++;
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            //}

                            //////// FIN DE LOS BONOS ////////////////7


                            // REGISTRO DE ASITENCIAS
                            BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                            ObjAsistencia.IDE_ASISTENCIA = 0;
                            ObjAsistencia.IDE_PERSONAL = persona;
                            ObjAsistencia.FEC_ASISTENCIA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                            ObjAsistencia.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                            ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                            ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                            ObjAsistencia.IDE_ESTADO = asistencia;
                            ObjAsistencia.SUPERVISOR = CAPATAZ;
                            int rptAsistencia;
                            rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);

                        }

                    }

                   
                }
                else
                {
                    MessageBox.Show("Existen inconsistencia en la digitación, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
                
            }
            else
            {

                MessageBox.Show(ls_error);

            }
        }

        private void btnCuadrillaVarios_Click(object sender, EventArgs e)
        {
            BL_CUADRILLA objCuadrilla = new BL_CUADRILLA();
            DataTable dtResultado = new DataTable();
            dtResultado = objCuadrilla.SP_LISTAR_CUADRILLA_OBRERO(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                obj_Tareo_E = new BE_ASIGNACION_TAREO();
                obj_Tareo_E.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                obj_Tareo_E.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                obj_Tareo_E.FEC_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
              
                frmCuadrillaVarios f2 = new frmCuadrillaVarios(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varCuadrilla > 0)
                {
                    listarCuadrilla();
           
                }
                //else
                //{
                //    listarCuadrilla();
             
                //}
            }
            else
            {

                MessageBox.Show("No existe personal en más de una cuadrilla " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
