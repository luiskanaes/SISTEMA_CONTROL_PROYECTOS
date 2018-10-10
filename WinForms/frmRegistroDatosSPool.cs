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
    public partial class frmRegistroDatosSPool : Form
    {
        public frmRegistroDatosSPool()
        {
            InitializeComponent();
            cargarFamilia(); cargaFiltros();
        }
        private void cargaFiltros()
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_FILTROS_SPOOL("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                cboFiltro.ValueMember = "ID";
                cboFiltro.DisplayMember = "DESCRIPCION";
                cboFiltro.DataSource = dtResultado;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_SPOOL("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, cboFiltro.SelectedValue.ToString(), txtFiltro.Text, cboFamilia.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Columns["ID"].Frozen = true;
                dgMarcas.Columns["ID"].Width = 155;
                dgMarcas.Columns["ID"].ReadOnly = true;
                dgMarcas.Visible = true;

                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].ReadOnly = true;
                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].DefaultCellStyle.BackColor = Color.Gray;

                //dgMarcas.Columns[85].ReadOnly = true;
                //dgMarcas.Columns[86].ReadOnly = true;
                //dgMarcas.Columns[87].ReadOnly = true;
                //dgMarcas.Columns[88].ReadOnly = true;
                //dgMarcas.Columns[89].ReadOnly = true;
                //dgMarcas.Columns[90].ReadOnly = true;
                //dgMarcas.Columns[91].ReadOnly = true;
                //dgMarcas.Columns[92].ReadOnly = true;
                //dgMarcas.Columns[93].ReadOnly = true;
                //dgMarcas.Columns[94].ReadOnly = true;

                //dgMarcas.Columns[85].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[86].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[87].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[88].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[89].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[90].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[91].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[92].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[93].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[94].DefaultCellStyle.BackColor = Color.Gray;

                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;

            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                lblTotal.Text = "TOTAL: ";
                dgMarcas.DataSource = null;
                dgMarcas.Refresh();
                return;
            }

            DataTable dtResultado_editable = new DataTable();
            dtResultado_editable = obj.SP_CONSULTAR_COLUMNAS_EDITABLES("", Convert.ToString(frmLogin.obj_perfil_E.IdPerfil));

            if (dgMarcas.Rows.Count != 0 && dgMarcas.Rows != null)
            {

                foreach (DataRow row in dtResultado_editable.Rows)
                {
                    dgMarcas.Columns[(row["CABECERA"].ToString())].ReadOnly = true;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.ForeColor = Color.White;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.BackColor = Color.Gray;

                    dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

                }

            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //DataTable dt = GetDataTableFromDGV(dgMarcas);
            //int inicio = 1, fin = 0;

            //if (dt.Rows.Count > 0)
            //{
            //    fin = dt.Columns.Count;

            //    string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(consString))
            //    {
            //        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //        {
            //            //string sqlTrunc = "TRUNCATE TABLE TMP_DATOS";
            //            //SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            //            con.Open();
            //            //cmd.ExecuteNonQuery();


            //            //Set the database table name
            //            sqlBulkCopy.DestinationTableName = "dbo.TMP_DATOS";

            //            //[OPTIONAL]: Map the DataTable columns with that of the database table
            //            //sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");

            //            while (inicio <= fin)
            //            {
            //                sqlBulkCopy.ColumnMappings.Add("Column" + inicio, "col_" + inicio);
            //                inicio++;
            //            }

            //            dt.Columns.Add("Column149", typeof(System.String));
            //            dt.Columns.Add("Column150", typeof(System.String));

            //            Guid guid = Guid.NewGuid();
            //            string str = guid.ToString();
            //            foreach (DataRow dr in dt.Rows)
            //            {
            //                //need to set value to MyRow column 
            //                dr["Column149"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
            //                dr["Column150"] = str;   // or set it to some other value 
            //            }

            //            sqlBulkCopy.ColumnMappings.Add("Column149", "col_149");
            //            sqlBulkCopy.ColumnMappings.Add("Column150", "col_150");

            //            sqlBulkCopy.WriteToServer(dt);

            //            BL_MARCAS obj = new BL_MARCAS();
            //            DataTable dtResultado = new DataTable();
            //            dtResultado = obj.SP_GUARDAR_DATOS_REGISTRO_SPOOLS("", str);                     

            //            if (dtResultado.Rows.Count > 0)
            //            {

            //            }

            //            MessageBox.Show("Registro Exitoso!");

            //            con.Close();



            //        }
            //    }
            //}

            DataTable dt = GetDataTableFromDGV(dgMarcas);
            int inicio = 1, fin = 0;

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado_col = new DataTable();
            dtResultado_col = obj.SP_CONSULTAR_COLUMNAS_SPOOLS();
            int i = 0;

            foreach (DataColumn row in dt.Columns)
            {
                //dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));

                if (dt.Columns.Count != i)
                {
                    dt.Columns[i].ColumnName = Guid.NewGuid().ToString();
                    i++;
                }

            }
            i = 0;
            foreach (DataRow row in dtResultado_col.Rows)
            {
                //dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));
                dt.Columns[i].ColumnName = "Column" + row["NUM_COLUMNA"].ToString();

                if (dt.Columns.Count == i)
                {
                    dt.Columns[i].ColumnName = "E";
                    i++;
                }

                i++;
            }


            if (dt.Rows.Count > 0)
            {
                fin = dt.Columns.Count;

                string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //string sqlTrunc = "TRUNCATE TABLE TMP_DATOS";
                        //SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                        con.Open();
                        //cmd.ExecuteNonQuery();


                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.TMP_DATOS";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");

                        //while (inicio <= fin)
                        //{
                        //    sqlBulkCopy.ColumnMappings.Add("Column"+inicio, "col_" + inicio);
                        //    inicio++;
                        //}

                        foreach (DataRow row in dtResultado_col.Rows)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column" + row["NUM_COLUMNA"].ToString(), "col_" + row["NUM_COLUMNA"].ToString());
                            //dt.Columns[i].ColumnName = "Column" + row["NUM_COLUMNA"].ToString();
                            //if (dt.Columns.Count == i)
                            //{
                            //    dt.Columns[i].ColumnName = "E";
                            //    i++;
                            //}

                            i++;
                        }

                        dt.Columns.Add("Column149", typeof(System.String));
                        dt.Columns.Add("Column150", typeof(System.String));

                        Guid guid = Guid.NewGuid();
                        string str = guid.ToString();
                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["Column149"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                            dr["Column150"] = str;
                        }

                        sqlBulkCopy.ColumnMappings.Add("Column149", "col_149");
                        sqlBulkCopy.ColumnMappings.Add("Column150", "col_150");

                        sqlBulkCopy.WriteToServer(dt);

                        DataTable dtResultado = new DataTable();
                        dtResultado = obj.SP_GUARDAR_DATOS_REGISTRO_SPOOLS("", str);

                        if (dtResultado.Rows.Count > 0)
                        {

                        }

                        MessageBox.Show("Registro Exitoso!");

                        con.Close();



                    }
                }
            }
        }



        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void dgMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //var editedCell = this.dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //var newValue = editedCell.Value;
            int ultimaColumna;
            ultimaColumna = dgMarcas.Columns.Count - 1;
            string x;
            string y;
            string valorAnterior;
            int num;

            x = e.RowIndex.ToString();
            num = e.ColumnIndex + 1;
            y = num.ToString();

            //dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Red;



            if (e.ColumnIndex.ToString() != ultimaColumna.ToString())
            {
                valorAnterior = dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value.ToString();
                dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value = valorAnterior + "," + y;
            }


            //dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex]. = 1;
        }

        private void frmRegistroDatosSPool_Load(object sender, EventArgs e)
        {

        }

        private void cargarFamilia()
        {
            cboFamilia.DataSource = new BindingSource(TipoFamilia, null);
            cboFamilia.DisplayMember = "Value";
            cboFamilia.ValueMember = "Value";
        }

        public static Dictionary<int, string> TipoFamilia = new Dictionary<int, string>()
        {
            {1,"SPOOL"},
            {2,"VALVULA"},
            {3,"SOPORTE"},
            {4,"MISCELANEO"},
            {5,"INSTRUMENTO"} 
        };

        private void cboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFamilia.SelectedValue.ToString() == "SPOOL")
            {
                lblCabecera.Text = "REGISTRO DATOS SPOOL";
            }
            if (cboFamilia.SelectedValue.ToString() == "VALVULA")
            {
                lblCabecera.Text = "REGISTRO DATOS VALVULA";
            }
            if (cboFamilia.SelectedValue.ToString() == "SOPORTE")
            {
                lblCabecera.Text = "REGISTRO DATOS SOPORTE";
            }
            if (cboFamilia.SelectedValue.ToString() == "MISCELANEO")
            {
                lblCabecera.Text = "REGISTRO DATOS MISCELANEO";
            }
            if (cboFamilia.SelectedValue.ToString() == "INSTRUMENTOS")
            {
                lblCabecera.Text = "REGISTRO DATOS INSTRUMENTOS";
            }
        }
    }
}
