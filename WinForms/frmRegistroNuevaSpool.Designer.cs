namespace WinForms
{
    partial class frmRegistroNuevaSpool
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
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTipoJunta = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgJuntaNueva = new System.Windows.Forms.DataGridView();
            this.txtNuevaJunta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgJunta = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgJuntaNueva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJunta)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(691, 346);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(121, 21);
            this.cboUbicacion.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(645, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "BORE:";
            // 
            // cboTipoJunta
            // 
            this.cboTipoJunta.FormattingEnabled = true;
            this.cboTipoJunta.Location = new System.Drawing.Point(483, 346);
            this.cboTipoJunta.Name = "cboTipoJunta";
            this.cboTipoJunta.Size = new System.Drawing.Size(121, 21);
            this.cboTipoJunta.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "TIPO DE FAMILIA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(316, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 12);
            this.label8.TabIndex = 66;
            this.label8.Text = "***INGRESAR DATOS DEL FILTROS COMPLETOS***";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(888, 340);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(110, 33);
            this.btnGenerar.TabIndex = 65;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgJuntaNueva
            // 
            this.dgJuntaNueva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJuntaNueva.Location = new System.Drawing.Point(70, 383);
            this.dgJuntaNueva.Name = "dgJuntaNueva";
            this.dgJuntaNueva.Size = new System.Drawing.Size(1161, 100);
            this.dgJuntaNueva.TabIndex = 64;
            // 
            // txtNuevaJunta
            // 
            this.txtNuevaJunta.Location = new System.Drawing.Point(267, 347);
            this.txtNuevaJunta.MaxLength = 100;
            this.txtNuevaJunta.Name = "txtNuevaJunta";
            this.txtNuevaJunta.Size = new System.Drawing.Size(96, 20);
            this.txtNuevaJunta.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "NUEVO SPOOL:";
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(381, 55);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(100, 20);
            this.txtServicio.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "SERVICIO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 25);
            this.label4.TabIndex = 58;
            this.label4.Text = "REGISTRO DE NUEVO SPOOL";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(717, 55);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(100, 20);
            this.txtTrain.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "TRAIN:";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(543, 55);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(100, 20);
            this.txtLine.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "LINE:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(192, 55);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "UNIT:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(1004, 340);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 33);
            this.btnGrabar.TabIndex = 50;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dgJunta
            // 
            this.dgJunta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJunta.Location = new System.Drawing.Point(70, 88);
            this.dgJunta.Name = "dgJunta";
            this.dgJunta.Size = new System.Drawing.Size(1161, 234);
            this.dgJunta.TabIndex = 49;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(989, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 33);
            this.btnBuscar.TabIndex = 48;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmRegistroNuevaSpool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 620);
            this.Controls.Add(this.cboUbicacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboTipoJunta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgJuntaNueva);
            this.Controls.Add(this.txtNuevaJunta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgJunta);
            this.Controls.Add(this.btnBuscar);
            this.Name = "frmRegistroNuevaSpool";
            this.Text = "frmRegistroNuevaSpool";
            ((System.ComponentModel.ISupportInitialize)(this.dgJuntaNueva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJunta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTipoJunta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgJuntaNueva;
        private System.Windows.Forms.TextBox txtNuevaJunta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dgJunta;
        private System.Windows.Forms.Button btnBuscar;
    }
}