﻿namespace WinForms
{
    partial class frmTareoDiario
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTareo = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCapataz = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIngeniero = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFeriado = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.rdoGeneral = new System.Windows.Forms.RadioButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblF1 = new System.Windows.Forms.Label();
            this.cboMigrar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoGestor = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdoTareo = new System.Windows.Forms.RadioButton();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.gridDetalle = new System.Windows.Forms.DataGridView();
            this.groupControles = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnIndicadores = new System.Windows.Forms.Button();
            this.btnAdvertencia = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnPersonal = new System.Windows.Forms.Button();
            this.btnTareas = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.groupControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1214, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Consulta Tareo Diario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "FECHA TRABAJO";
            // 
            // dateTareo
            // 
            this.dateTareo.Location = new System.Drawing.Point(801, 13);
            this.dateTareo.Name = "dateTareo";
            this.dateTareo.Size = new System.Drawing.Size(208, 20);
            this.dateTareo.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(45, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "RESPONSABLE DE CUADRILLA";
            // 
            // cboCapataz
            // 
            this.cboCapataz.FormattingEnabled = true;
            this.cboCapataz.Location = new System.Drawing.Point(212, 55);
            this.cboCapataz.Name = "cboCapataz";
            this.cboCapataz.Size = new System.Drawing.Size(388, 21);
            this.cboCapataz.TabIndex = 35;
            this.cboCapataz.SelectedIndexChanged += new System.EventHandler(this.cboCapataz_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "INGENIERO DE CAMPO";
            // 
            // cboIngeniero
            // 
            this.cboIngeniero.FormattingEnabled = true;
            this.cboIngeniero.Location = new System.Drawing.Point(212, 33);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(388, 21);
            this.cboIngeniero.TabIndex = 34;
            this.cboIngeniero.SelectedIndexChanged += new System.EventHandler(this.cboIngeniero_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(86, 12);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 31;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "C. COSTO";
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(212, 12);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(475, 21);
            this.cboCentroCosto.TabIndex = 33;
            this.cboCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cboCentroCosto_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblFeriado);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.rdoGeneral);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.lblF1);
            this.groupBox1.Controls.Add(this.cboMigrar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rdoGestor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboCentroCosto);
            this.groupBox1.Controls.Add(this.rdoTareo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTareo);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCapataz);
            this.groupBox1.Controls.Add(this.cboIngeniero);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(6, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1212, 100);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // lblFeriado
            // 
            this.lblFeriado.AutoSize = true;
            this.lblFeriado.Location = new System.Drawing.Point(1025, 76);
            this.lblFeriado.Name = "lblFeriado";
            this.lblFeriado.Size = new System.Drawing.Size(13, 13);
            this.lblFeriado.TabIndex = 58;
            this.lblFeriado.Text = "0";
            this.lblFeriado.Visible = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::WinForms.Properties.Resources.boton_Generar;
            this.btnGenerar.Location = new System.Drawing.Point(1015, 40);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 30);
            this.btnGenerar.TabIndex = 57;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Visible = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // rdoGeneral
            // 
            this.rdoGeneral.AutoSize = true;
            this.rdoGeneral.Checked = true;
            this.rdoGeneral.Location = new System.Drawing.Point(385, 79);
            this.rdoGeneral.Name = "rdoGeneral";
            this.rdoGeneral.Size = new System.Drawing.Size(79, 17);
            this.rdoGeneral.TabIndex = 56;
            this.rdoGeneral.TabStop = true;
            this.rdoGeneral.Text = "Hrs Totales";
            this.rdoGeneral.UseVisualStyleBackColor = true;
            this.rdoGeneral.CheckedChanged += new System.EventHandler(this.rdoGeneral_CheckedChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(748, 79);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(13, 13);
            this.lblEstado.TabIndex = 55;
            this.lblEstado.Text = "0";
            this.lblEstado.Visible = false;
            // 
            // lblF1
            // 
            this.lblF1.AutoSize = true;
            this.lblF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF1.Location = new System.Drawing.Point(1131, 17);
            this.lblF1.Name = "lblF1";
            this.lblF1.Size = new System.Drawing.Size(29, 13);
            this.lblF1.TabIndex = 54;
            this.lblF1.Text = "(F1)";
            this.lblF1.Visible = false;
            // 
            // cboMigrar
            // 
            this.cboMigrar.FormattingEnabled = true;
            this.cboMigrar.Location = new System.Drawing.Point(801, 56);
            this.cboMigrar.Name = "cboMigrar";
            this.cboMigrar.Size = new System.Drawing.Size(208, 21);
            this.cboMigrar.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "ESTADO MIGRACION";
            // 
            // rdoGestor
            // 
            this.rdoGestor.AutoSize = true;
            this.rdoGestor.Location = new System.Drawing.Point(295, 79);
            this.rdoGestor.Name = "rdoGestor";
            this.rdoGestor.Size = new System.Drawing.Size(90, 17);
            this.rdoGestor.TabIndex = 47;
            this.rdoGestor.Text = "Tareo Sisplan";
            this.rdoGestor.UseVisualStyleBackColor = true;
            this.rdoGestor.CheckedChanged += new System.EventHandler(this.rdoGestor_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "ESTADO TAREO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(1015, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdoTareo
            // 
            this.rdoTareo.AutoSize = true;
            this.rdoTareo.Location = new System.Drawing.Point(212, 79);
            this.rdoTareo.Name = "rdoTareo";
            this.rdoTareo.Size = new System.Drawing.Size(77, 17);
            this.rdoTareo.TabIndex = 46;
            this.rdoTareo.Text = "Tareo SSK";
            this.rdoTareo.UseVisualStyleBackColor = true;
            this.rdoTareo.CheckedChanged += new System.EventHandler(this.rdoTareo_CheckedChanged);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(801, 35);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(208, 21);
            this.cboEstado.TabIndex = 45;
            // 
            // gridDetalle
            // 
            this.gridDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalle.Location = new System.Drawing.Point(7, 172);
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.Size = new System.Drawing.Size(1211, 280);
            this.gridDetalle.TabIndex = 42;
            this.gridDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellClick);
            // 
            // groupControles
            // 
            this.groupControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControles.Controls.Add(this.btnEliminar);
            this.groupControles.Controls.Add(this.btnIndicadores);
            this.groupControles.Controls.Add(this.btnAdvertencia);
            this.groupControles.Controls.Add(this.btnAbrir);
            this.groupControles.Controls.Add(this.btnCerrar);
            this.groupControles.Controls.Add(this.btnPersonal);
            this.groupControles.Controls.Add(this.btnTareas);
            this.groupControles.Controls.Add(this.btnProcesar);
            this.groupControles.Location = new System.Drawing.Point(6, 118);
            this.groupControles.Name = "groupControles";
            this.groupControles.Size = new System.Drawing.Size(1211, 50);
            this.groupControles.TabIndex = 50;
            this.groupControles.TabStop = false;
            this.groupControles.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::WinForms.Properties.Resources.boton_eliminarMigracion;
            this.btnEliminar.Location = new System.Drawing.Point(899, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(121, 30);
            this.btnEliminar.TabIndex = 54;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnIndicadores
            // 
            this.btnIndicadores.Image = global::WinForms.Properties.Resources.botonIndicadores;
            this.btnIndicadores.Location = new System.Drawing.Point(259, 12);
            this.btnIndicadores.Name = "btnIndicadores";
            this.btnIndicadores.Size = new System.Drawing.Size(125, 30);
            this.btnIndicadores.TabIndex = 53;
            this.btnIndicadores.UseVisualStyleBackColor = true;
            this.btnIndicadores.Click += new System.EventHandler(this.btnIndicadores_Click);
            // 
            // btnAdvertencia
            // 
            this.btnAdvertencia.BackColor = System.Drawing.Color.Red;
            this.btnAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvertencia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdvertencia.Location = new System.Drawing.Point(768, 12);
            this.btnAdvertencia.Name = "btnAdvertencia";
            this.btnAdvertencia.Size = new System.Drawing.Size(125, 30);
            this.btnAdvertencia.TabIndex = 52;
            this.btnAdvertencia.Text = "Exceso de Horas";
            this.btnAdvertencia.UseVisualStyleBackColor = false;
            this.btnAdvertencia.Visible = false;
            this.btnAdvertencia.Click += new System.EventHandler(this.btnAdvertencia_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = global::WinForms.Properties.Resources.botonAbrirTareo;
            this.btnAbrir.Location = new System.Drawing.Point(512, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(125, 30);
            this.btnAbrir.TabIndex = 50;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::WinForms.Properties.Resources.botonCerrarTareo;
            this.btnCerrar.Location = new System.Drawing.Point(385, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(125, 30);
            this.btnCerrar.TabIndex = 49;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.Image = global::WinForms.Properties.Resources.botonSinTareo;
            this.btnPersonal.Location = new System.Drawing.Point(133, 12);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(125, 30);
            this.btnPersonal.TabIndex = 48;
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnTareas
            // 
            this.btnTareas.Image = global::WinForms.Properties.Resources.botonTareasLista;
            this.btnTareas.Location = new System.Drawing.Point(7, 12);
            this.btnTareas.Name = "btnTareas";
            this.btnTareas.Size = new System.Drawing.Size(125, 30);
            this.btnTareas.TabIndex = 43;
            this.btnTareas.UseVisualStyleBackColor = true;
            this.btnTareas.Click += new System.EventHandler(this.btnTareas_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::WinForms.Properties.Resources.botonMigrar;
            this.btnProcesar.Location = new System.Drawing.Point(638, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(125, 30);
            this.btnProcesar.TabIndex = 44;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // frmTareoDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 460);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupControles);
            this.Name = "frmTareoDiario";
            this.Text = "Cierre Tareo";
            this.Load += new System.EventHandler(this.frmTareoDiario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.groupControles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTareo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCapataz;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIngeniero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridDetalle;
        private System.Windows.Forms.Button btnTareas;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.RadioButton rdoTareo;
        private System.Windows.Forms.RadioButton rdoGestor;
        private System.Windows.Forms.GroupBox groupControles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.ComboBox cboMigrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdvertencia;
        private System.Windows.Forms.Button btnIndicadores;
        private System.Windows.Forms.Label lblF1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.RadioButton rdoGeneral;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblFeriado;
    }
}