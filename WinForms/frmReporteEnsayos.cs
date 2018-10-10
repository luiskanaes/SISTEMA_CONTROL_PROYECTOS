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
    public partial class frmReporteEnsayos : Form
    {
        public frmReporteEnsayos()
        {
            InitializeComponent();
            cargarUnidades();
            cargarEnsayos();
            cargarTipoJunta();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_REPORTE_PIP35(cboUnidad.Text,cboTipoJunta.Text,cboTipoEnsayo.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Visible = true;              
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgMarcas.DataSource = null;
                return;
            }
        }

        private void cargarUnidades()
        {
            cboUnidad.DataSource = new BindingSource(unidades, null);
            cboUnidad.DisplayMember = "Value";
            cboUnidad.ValueMember = "Key";
        }

        public static Dictionary<int, string> unidades = new Dictionary<int, string>()
        {
            {1,"AM2"},
            {2,"DV3"},
            {3,"FCC"},
            {4,"HTF"},
            {5,"RG1"},
            {6,"RG2"},
            {7,"WS2"}
            //,
            //{8,"VACIOS"},
            //{9,"TODOS"},
        };

        private void cargarTipoJunta()
        {
            cboTipoJunta.DataSource = new BindingSource(tjunta, null);
            cboTipoJunta.DisplayMember = "Value";
            cboTipoJunta.ValueMember = "Key";
        }
            
        public static Dictionary<int, string> tjunta = new Dictionary<int, string>()
        {
            {1,"SP"},
            {2,"RP"},
            {3,"SW"},
            {4,"TH"},
            {5,"FJ"},
            {6,"BR"},
            {7,"RJ"},
            {8,"BW"}
            //,
            //{9,"VACIOS"},
            //{10,"TODOS"},
        };

        private void cargarEnsayos()
        {
            cboTipoEnsayo.DataSource = new BindingSource(ensayos, null);
            cboTipoEnsayo.DisplayMember = "Value";
            cboTipoEnsayo.ValueMember = "Key";
        }

        public static Dictionary<int, string> ensayos = new Dictionary<int, string>()
        {
            {1,"HTA%"},   
            {2,"HTB%"},
            {3,"MT%"},
            {4,"PMI%"},
            {5,"PT%"},
            {6,"PWHT%"},
            {7,"RT%"}
            //,
            //{8,"VACIOS"},
            //{9,"TODOS"},
        };
        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Reporte_Ensayos_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgMarcas, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
