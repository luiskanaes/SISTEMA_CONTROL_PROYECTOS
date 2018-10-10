using System;
using System.Collections.Generic;
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
    public partial class frmRegistrarIsometrico : Form
    {
        public frmRegistrarIsometrico()
        {
            InitializeComponent();
        }

        private void dgJuntaNueva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //- Creación de DataTable
            DataTable dtDatos = new DataTable();
            dtDatos.Columns.Add("JUNTA");
            dtDatos.Columns.Add("UNIDAD");
            dtDatos.Columns.Add("SERVICIO");
            dtDatos.Columns.Add("LINE");
            dtDatos.Columns.Add("TRAIN");


            //- Agregar Datos
            DataRow dRow = dtDatos.NewRow();
            dRow["JUNTA"] = txtUnit.Text+"-"+txtServicio.Text+"-"+txtTrain.Text+"-"+ txtLine.Text +"-"+ "0000Z";
            dRow["UNIDAD"] = txtUnit.Text;
            dRow["SERVICIO"] = txtServicio.Text;
            dRow["LINE"] = txtLine.Text;
            dRow["TRAIN"] = txtTrain.Text;
            dtDatos.Rows.Add(dRow);

            dgJuntaNueva.DataSource = dtDatos;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show("¿Esta seguro de guardar los cambios?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {

                BL_MARCAS obj2 = new BL_MARCAS();
                DataTable dtResultado2 = new DataTable();
                dtResultado2 = obj2.SP_GRABAR_NUEVO_ISOMETRICO(txtUnit.Text + "-" + txtServicio.Text + "-" + txtTrain.Text + "-" + txtLine.Text + "-" + "0000Z", txtUnit.Text, txtServicio.Text, txtLine.Text, txtTrain.Text);

                MessageBox.Show("Registro Exitoso!");

                txtLine.Text = "";
                txtServicio.Text = "";
                txtTrain.Text = "";
                txtUnit.Text = "";

                dgJuntaNueva.DataSource = null;
            }
        }        
    }
}
