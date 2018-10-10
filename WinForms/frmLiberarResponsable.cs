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
namespace WinForms
{
    public partial class frmLiberarResponsable : Form
    {
        public int varfMigracion;
        public frmLiberarResponsable()
        {
            InitializeComponent();
            ListarCategoria();
            listarCuadrilla();
        }

        private void frmLiberarResponsable_Load(object sender, EventArgs e)
        {

        }
        protected void ListarCategoria()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarParametros("PERSONAL", "IDE_GRUPO");
            if (dtResultado.Rows.Count > 0)
            {

                cboCategoria.ValueMember = "IDE_PARAMETRO";
                cboCategoria.DisplayMember = "DES_ASUNTO";
                cboCategoria.DataSource = dtResultado;

            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPersonalCategoria();
            
        }
        protected void listarPersonalCategoria()
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();

            Obj.IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            Obj.CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO ;
            Obj.IDE_GRUPO = Convert.ToInt32(cboCategoria.SelectedValue.ToString());

            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.Listar_PersonalGrupo(Obj);
            if (dtResultado.Rows.Count > 0)
            {
                cboPersonal.Visible = true;
                cboPersonal.ValueMember = "IDE_PERSONAL";
                cboPersonal.DisplayMember = "Personal";
                cboPersonal.DataSource = dtResultado;
                
                
            }
            else
            {
                cboPersonal.Visible = false ;
            }

            if (cboCategoria.SelectedIndex == 0)
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = false;
                rdoEmpleado.Checked = true;
            }
            else if (cboCategoria.SelectedIndex == 1)
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = true;
            }
            else
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = false;
                rdoObreros.Enabled = true;
            }
        }

        private void rdoEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
         
        }

        private void rdoObreros_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
           
        }
        private BE_PERSONAL f_datos(int estado, string TIPO_TRABAJADOR)
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            Obj.IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            Obj.CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO;
            Obj.TIPO_TRABAJADOR = TIPO_TRABAJADOR;
            return Obj;
        }
        protected void listarCuadrilla()
        {
            BE_PERSONAL obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string TipoTrabajador = string.Empty;
            if (rdoEmpleado.Checked)
            {
                TipoTrabajador = "01";
            }
            else
            {
                TipoTrabajador = "02";
            }

            DataTable dtResultado = new DataTable();
            obj = f_datos(0, TipoTrabajador);
            dtResultado = objPersona.Listar_PersonalCC(obj);
            if (dtResultado.Rows.Count > 0)
            {
                cboNuevoEncargado.Visible = true;
                cboNuevoEncargado.ValueMember = "IDE_PERSONAL";
                cboNuevoEncargado.DisplayMember = "Personal";
                cboNuevoEncargado.DataSource = dtResultado;

            }
            else
            {
                cboNuevoEncargado.Visible = false;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex == 2 )
            {
                MessageBox.Show("Categoria no permitida", "Advertencia Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea ejecutar los cambios?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    BL_PERSONAL objPersona = new BL_PERSONAL();
                    varfMigracion = 0;
                    DataTable dtResultado = new DataTable();
                    dtResultado = objPersona.uspUPD_PERSONAL_CATEGORIA_CAMBIO(Convert.ToInt32(cboPersonal.SelectedValue.ToString()),
                        Convert.ToInt32(cboNuevoEncargado.SelectedValue.ToString()),
                        Convert.ToInt32(cboCategoria.SelectedValue.ToString()),
                        frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO);

                    if (dtResultado.Rows.Count > 0)
                    {
                        varfMigracion++;
                        MessageBox.Show("Actualización satisfactoria", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
