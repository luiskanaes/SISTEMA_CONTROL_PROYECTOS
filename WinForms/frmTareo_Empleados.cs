using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;
using WinForms.SvTareo;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WinForms
{
    public partial class frmTareo_Empleados : Form
    {
        public frmTareo_Empleados()
        {
            InitializeComponent();
        }

        private void frmTareo_Empleados_Load(object sender, EventArgs e)
        { cargaUbicaciones2();
            cargasMeses();
            cargasAnios();
            verificarEstadoTareoEmp();
           
        }

        private void verificarEstadoTareoEmp()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_VERIFICAR_ESTADO_TAREOEMP("", cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString());


            if (dtResultado.Rows[0]["TOTAL"].ToString() == "0")
            {
                lblEstado.Visible = true;
                lblEstado.Text = "PENDIENTE";
                btnImportar.Visible = true;
                btnMigrar.Visible = true;
                //MessageBox.Show("No existe data para generar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {

                lblEstado.Visible = true;
                lblEstado.Text = "MIGRADO";
                btnImportar.Visible = false;
                btnMigrar.Visible = false;
            }

        }

        private void cargasMeses()
        {
            cboMes.DataSource = new BindingSource(meses, null);
            cboMes.DisplayMember = "Value";
            cboMes.ValueMember = "Key";
            cboMes.SelectedValue = 1;

        }

        private void cargaUbicaciones2() {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion1.ValueMember = "ID";
                cboUbicacion1.DisplayMember = "DESCRIPCION";
                cboUbicacion1.DataSource = dtResultado;
            
            }

        }

        private void cargasAnios()
        {
            cboAnio.DataSource = new BindingSource(anios, null);
            cboAnio.DisplayMember = "Value";
            cboAnio.ValueMember = "Key";
            cboAnio.SelectedValue = 2017;
        }

        public static Dictionary<int, string> meses = new Dictionary<int, string>()
        {
            {1,"ENERO"},
            {2,"FEBRERO"},
            {3,"MARZO"},
            {4,"ABRIL"},
            {5,"MAYO"},
            {6,"JUNIO"},
            {7,"JULIO"},
            {8,"AGOSTO"},
            {9,"SEPTIEMBRE"},
            {10,"OCTUBRE"},
            {11,"NOVIEMBRE"},
            {12,"DICIEMBRE"} 
        };

        public static Dictionary<int, string> anios = new Dictionary<int, string>()
        {
            {2017,"2017"},
            {2018,"2018"},
            {2019,"2019"},
            {2020,"2020"}
        };

   
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            verificarEstadoTareoEmp();

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_EMPLEADOS("",cboMes.SelectedValue.ToString(),cboAnio.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                //gridDetalle.Rows.Clear();
                //gridDetalle.Columns.Clear();
                //gridDetalle.Refresh();
                dgTareo.DataSource = dtResultado;
                dgTareo.AutoResizeColumns();
                dgTareo.Visible = true;

                dgTareo.Columns[0].Frozen = true;
                dgTareo.Columns[1].Frozen = true;
                dgTareo.Columns[2].Frozen = true;

                dgTareo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                dgTareo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                dgTareo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;


                DataGridViewColumn 
                
                column = dgTareo.Columns[0]; column.Width = 20;
                column = dgTareo.Columns[1]; column.Width = 50;
            //    column = dgTareo.Columns[2]; column.Width = 80;
                column = dgTareo.Columns[3]; column.Width = 40;
                column = dgTareo.Columns[4]; column.Width = 57;
                column = dgTareo.Columns[5]; column.Width = 69;
                column = dgTareo.Columns[6]; column.Width = 68;
                column = dgTareo.Columns[7]; column.Width = 25;
                column = dgTareo.Columns[8]; column.Width = 25;
                column = dgTareo.Columns[9]; column.Width = 25;                
                column = dgTareo.Columns[10]; column.Width = 25;
                column = dgTareo.Columns[11]; column.Width = 25;
                column = dgTareo.Columns[12]; column.Width = 25;
                column = dgTareo.Columns[13]; column.Width = 25;
                column = dgTareo.Columns[14]; column.Width = 25;
                column = dgTareo.Columns[15]; column.Width = 30;
                column = dgTareo.Columns[16]; column.Width = 30;
                column = dgTareo.Columns[17]; column.Width = 30;
                column = dgTareo.Columns[18]; column.Width = 30;
                column = dgTareo.Columns[19]; column.Width = 30;
                column = dgTareo.Columns[20]; column.Width = 30;
                column = dgTareo.Columns[21]; column.Width = 30;
                column = dgTareo.Columns[22]; column.Width = 30;
                column = dgTareo.Columns[23]; column.Width = 30;
                column = dgTareo.Columns[24]; column.Width = 30;
                column = dgTareo.Columns[25]; column.Width = 30;
                column = dgTareo.Columns[26]; column.Width = 30;
                column = dgTareo.Columns[27]; column.Width = 30;
                column = dgTareo.Columns[28]; column.Width = 30;
                column = dgTareo.Columns[29]; column.Width = 30;
                column = dgTareo.Columns[30]; column.Width = 30;
                column = dgTareo.Columns[31]; column.Width = 30;
                column = dgTareo.Columns[32]; column.Width = 30;
                column = dgTareo.Columns[33]; column.Width = 30;
                column = dgTareo.Columns[34]; column.Width = 30;
                column = dgTareo.Columns[35]; column.Width = 30;
                column = dgTareo.Columns[36]; column.Width = 30;

                dgTareo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            }

        }

        private void dgTareo_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("B - BAJADA"));
                m.MenuItems.Add(new MenuItem("C - CESADO"));
                m.MenuItems.Add(new MenuItem("DM - DESCANSO MEDICO"));
                m.MenuItems.Add(new MenuItem("DSO - DESCANSO MEDICO OBLIGATORIO"));
                m.MenuItems.Add(new MenuItem("FER - DIA FERIADO"));
                m.MenuItems.Add(new MenuItem("X - DIA LABORADO OBRA"));
                m.MenuItems.Add(new MenuItem("H - DIA LABORADO OF CENTRAL"));
                m.MenuItems.Add(new MenuItem("FA - FALTA"));
                m.MenuItems.Add(new MenuItem("P - LIC PATERNIDAD"));
                m.MenuItems.Add(new MenuItem("LC - LICENCIA CON GOCE"));
                m.MenuItems.Add(new MenuItem("LS - LICENCIA SIN GOCE"));
                m.MenuItems.Add(new MenuItem("MAT - MATERNIDAD"));
                m.MenuItems.Add(new MenuItem("SUB - SUBSIDIO POR SALUD"));
                m.MenuItems.Add(new MenuItem("S - SUSPENSION"));
                m.MenuItems.Add(new MenuItem("V - VACACIONES"));


                //int currentMouseOverRow = dgTareo.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                m.Show(dgTareo, new Point(e.X, e.Y));

            }


        }

        private void dgTareo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                this.dgTareo.Rows[e.RowIndex].Selected = true;
                //  this.rowIndex = e.RowIndex;
                this.dgTareo.CurrentCell = this.dgTareo.Rows[e.RowIndex].Cells[1];
                //this.contextMenuStrip1.Show(this.gridAsignacion, e.Location);
                //contextMenuStrip1.Show(Cursor.Position);
            }

        }
    }
}
