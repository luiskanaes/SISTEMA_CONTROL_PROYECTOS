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
    public partial class frmRegistroNuevaSpool : Form
    {
        public frmRegistroNuevaSpool()
        {
            InitializeComponent();
            cargarUbicacion();
            cargarTipoFamilia();
            btnGrabar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, "");

            if (dtResultado.Rows.Count > 0)
            {
                dgJunta.DataSource = dtResultado;
                dgJunta.AutoResizeColumns();
                dgJunta.Visible = true;
                dgJuntaNueva.DataSource = null;
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgJunta.DataSource = null;
                txtNuevaJunta.Text = ""; return;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = new DataTable();
            BL_MARCAS obj = new BL_MARCAS();
            //dtResultado = obj.SP_VERIFICAR_DATOS_NUEVO_JUNTA("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNuevaJunta.Text);

            //if (dtResultado.Rows[0]["TOTAL"].ToString() == "1")
            //{
            //    //MessageBox.Show("LA JUNTA " + txtNroJunta.Text + txtNuevaJunta.Text + " YA EXISTE FAVOR DE VERIFICAR", "ADVERTENCIA", MessageBoxButtons.OK);
            //    return;
            //}
            //else {
            //    dtResultado = null;
            //}

            dtResultado = obj.SP_GRABAR_DATOS_NUEVO_SPOOL("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNuevaJunta.Text, cboTipoJunta.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show("Registro exitoso!!!", "OK", MessageBoxButtons.OK);
                dgJuntaNueva.DataSource = null;
                txtNuevaJunta.Text = "";
                btnGrabar.Visible = false;
            }
            else {
                dgJuntaNueva.DataSource = null;
            }

            dtResultado = null;

            dtResultado = obj.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text,"");

            if (dtResultado.Rows.Count > 0)
            {
                dgJunta.DataSource = dtResultado;
                dgJunta.AutoResizeColumns();
                dgJunta.Visible = true;
                dgJuntaNueva.DataSource = null;
            }
            else
            {
                dgJunta.DataSource = null;
                txtNuevaJunta.Text = "";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (txtNuevaJunta.Text == "")
            {

                MessageBox.Show("INGRESE LA NUEVA JUNTA", "Advertencia", MessageBoxButtons.OK);
                return;

            }

            DataTable dtResultado = new DataTable();
            BL_MARCAS obj = new BL_MARCAS();
            dtResultado = obj.SP_VERIFICAR_DATOS_NUEVO_SPOOL("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text,  txtNuevaJunta.Text);

            if (dtResultado.Rows[0]["TOTAL"].ToString() == "1")
            {
                MessageBox.Show("EL SPOOL " + txtNuevaJunta.Text + " YA EXISTE FAVOR DE VERIFICAR", "ADVERTENCIA", MessageBoxButtons.OK);
                return;
            }
            else {
                dtResultado = null;
            }

            if (dgJunta.Rows.Count > 2)
            {
                BL_MARCAS obj2 = new BL_MARCAS();
                DataTable dtResultado2 = new DataTable();
                dtResultado2 = obj2.SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNuevaJunta.Text, cboTipoJunta.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

                if (dtResultado2.Rows.Count > 0)
                {
                    dgJuntaNueva.DataSource = dtResultado2;
                    dgJuntaNueva.AutoResizeColumns();
                    dgJuntaNueva.Visible = true;
                    btnGrabar.Visible = true;
                }
                else {
                    dgJuntaNueva.DataSource = null;
                }


            }
        }
        private void cargarUbicacion()
        {
            cboUbicacion.DataSource = new BindingSource(Ubicacion, null);
            cboUbicacion.DisplayMember = "Value";
            cboUbicacion.ValueMember = "Value";
        }

        public static Dictionary<int, string> Ubicacion = new Dictionary<int, string>()
        {
            {1,"LARGE BORE"},
            {2,"SMALL BORE"}
        };

        private void cargarTipoFamilia()
        {
            cboTipoJunta.DataSource = new BindingSource(TipoJunta, null);
            cboTipoJunta.DisplayMember = "Value";
            cboTipoJunta.ValueMember = "Value";
        }

        public static Dictionary<int, string> TipoJunta = new Dictionary<int, string>()
        {
            { 1,"SPOOL"},
            {2,"VALVULA"},
            {3,"SOPORTE"},
            {4,"MISCELANEO"},
            {5,"INSTRUMENTO"}
        };
    }
}
