﻿namespace WinForms
{
    partial class frmAsignacionPersonal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdoObreros = new System.Windows.Forms.RadioButton();
            this.rdoEmpleado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvCuadrilla = new System.Windows.Forms.DataGridView();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadAsignada = new System.Windows.Forms.TextBox();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1171, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Asignacion de Responsables";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(197, 14);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(828, 21);
            this.cboCentroCosto.TabIndex = 37;
            this.cboCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cboCentroCosto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "C. COSTO";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(62, 14);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 35;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "EMPRESA";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.cboCentroCosto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1169, 46);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(1031, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdoObreros
            // 
            this.rdoObreros.AutoSize = true;
            this.rdoObreros.Checked = true;
            this.rdoObreros.Location = new System.Drawing.Point(114, 78);
            this.rdoObreros.Name = "rdoObreros";
            this.rdoObreros.Size = new System.Drawing.Size(78, 17);
            this.rdoObreros.TabIndex = 54;
            this.rdoObreros.TabStop = true;
            this.rdoObreros.Text = "OBREROS";
            this.rdoObreros.UseVisualStyleBackColor = true;
            this.rdoObreros.CheckedChanged += new System.EventHandler(this.rdoObreros_CheckedChanged);
            // 
            // rdoEmpleado
            // 
            this.rdoEmpleado.AutoSize = true;
            this.rdoEmpleado.Location = new System.Drawing.Point(198, 78);
            this.rdoEmpleado.Name = "rdoEmpleado";
            this.rdoEmpleado.Size = new System.Drawing.Size(91, 17);
            this.rdoEmpleado.TabIndex = 53;
            this.rdoEmpleado.TabStop = true;
            this.rdoEmpleado.Text = "EMPLEADOS";
            this.rdoEmpleado.UseVisualStyleBackColor = true;
            this.rdoEmpleado.CheckedChanged += new System.EventHandler(this.rdoEmpleado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "PERSONAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "FILTRO NOMBRE";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(112, 100);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(438, 20);
            this.txtApellidos.TabIndex = 45;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "CATEGORIA PERSONAL";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(557, 198);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 35);
            this.btnQuitar.TabIndex = 43;
            this.btnQuitar.Text = "<<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(557, 142);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(36, 35);
            this.btnSeleccionar.TabIndex = 42;
            this.btnSeleccionar.Text = ">>";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvCuadrilla
            // 
            this.dgvCuadrilla.AllowUserToAddRows = false;
            this.dgvCuadrilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCuadrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadrilla.Location = new System.Drawing.Point(14, 130);
            this.dgvCuadrilla.Name = "dgvCuadrilla";
            this.dgvCuadrilla.Size = new System.Drawing.Size(536, 292);
            this.dgvCuadrilla.TabIndex = 41;
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Location = new System.Drawing.Point(602, 130);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.Size = new System.Drawing.Size(540, 292);
            this.dgvPersonal.TabIndex = 40;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(729, 78);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(195, 21);
            this.cboCategoria.TabIndex = 47;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // btnAsociar
            // 
            this.btnAsociar.Image = global::WinForms.Properties.Resources.botonAsignarResponsable;
            this.btnAsociar.Location = new System.Drawing.Point(930, 77);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(100, 32);
            this.btnAsociar.TabIndex = 48;
            this.btnAsociar.UseVisualStyleBackColor = true;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Leyenda Personal :";
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAsignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.lblAsignado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignado.ForeColor = System.Drawing.Color.Black;
            this.lblAsignado.Location = new System.Drawing.Point(432, 425);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(117, 23);
            this.lblAsignado.TabIndex = 50;
            this.lblAsignado.Text = "Asignado";
            this.lblAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisponible.BackColor = System.Drawing.Color.White;
            this.lblDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.Black;
            this.lblDisponible.Location = new System.Drawing.Point(312, 425);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(117, 23);
            this.lblDisponible.TabIndex = 49;
            this.lblDisponible.Text = "Disponible";
            this.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "CANTIDAD ASIGNADA";
            // 
            // txtCantidadAsignada
            // 
            this.txtCantidadAsignada.Location = new System.Drawing.Point(729, 100);
            this.txtCantidadAsignada.Name = "txtCantidadAsignada";
            this.txtCantidadAsignada.ReadOnly = true;
            this.txtCantidadAsignada.Size = new System.Drawing.Size(195, 20);
            this.txtCantidadAsignada.TabIndex = 53;
            // 
            // btnLiberar
            // 
            this.btnLiberar.Image = global::WinForms.Properties.Resources.botonLiberar;
            this.btnLiberar.Location = new System.Drawing.Point(1036, 77);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(100, 32);
            this.btnLiberar.TabIndex = 55;
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // frmAsignacionPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 457);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.rdoObreros);
            this.Controls.Add(this.txtCantidadAsignada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdoEmpleado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAsignado);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvCuadrilla);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "frmAsignacionPersonal";
            this.Text = "Asignacion de Personal";
            this.Load += new System.EventHandler(this.frmAsignacionPersonal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridView dgvCuadrilla;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btnAsociar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.RadioButton rdoObreros;
        private System.Windows.Forms.RadioButton rdoEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidadAsignada;
        private System.Windows.Forms.Button btnLiberar;
    }
}