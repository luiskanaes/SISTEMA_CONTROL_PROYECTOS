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
using System.Text.RegularExpressions;


namespace WinForms
{
    public partial class frmReporteBaseEnsayosPendientes : Form
    {
        public frmReporteBaseEnsayosPendientes()
        {
            InitializeComponent();
            cargaFiltros();
        }
        private void cargaFiltros()
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_FILTROS("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                cboFiltro.ValueMember = "ID";
                cboFiltro.DisplayMember = "DESCRIPCION";
                cboFiltro.DataSource = dtResultado;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES("", cboFiltro.SelectedValue.ToString(), txtFiltro.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Columns["JUNTA"].Frozen = true;
                dgMarcas.Columns["JUNTA"].Width = 160;
                dgMarcas.Visible = true;

                dgMarcas.Columns[0].ReadOnly = true;
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[21].ReadOnly = true;

                dgMarcas.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[21].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

                //lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;

            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                //lblTotal.Text = "TOTAL: ";
                dgMarcas.DataSource = null;
                dgMarcas.Refresh();
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES("", cboFiltro.SelectedValue.ToString(), txtFiltro.Text);

            //DataTable dt = dtResultado;
            //string filename = OpenSavefileDialog();

            //ToCSV(filename);



            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt (*.txt)|*.txt";
            sfd.FileName = "REPORTE_BASE_ENSAYOS_PENDIENTES_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCSV(dtResultado, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }




        private void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }






    }
}
