namespace WinForms
{
    partial class frmLiberarResponsable
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
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPersonal = new System.Windows.Forms.ComboBox();
            this.rdoObreros = new System.Windows.Forms.RadioButton();
            this.rdoEmpleado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNuevoEncargado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Reasignación de Responsable";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(77, 37);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(326, 21);
            this.cboCategoria.TabIndex = 49;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "CATEGORIA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "PERSONAL";
            // 
            // cboPersonal
            // 
            this.cboPersonal.FormattingEnabled = true;
            this.cboPersonal.Location = new System.Drawing.Point(77, 59);
            this.cboPersonal.Name = "cboPersonal";
            this.cboPersonal.Size = new System.Drawing.Size(326, 21);
            this.cboPersonal.TabIndex = 51;
            // 
            // rdoObreros
            // 
            this.rdoObreros.AutoSize = true;
            this.rdoObreros.Location = new System.Drawing.Point(237, 86);
            this.rdoObreros.Name = "rdoObreros";
            this.rdoObreros.Size = new System.Drawing.Size(78, 17);
            this.rdoObreros.TabIndex = 57;
            this.rdoObreros.Text = "OBREROS";
            this.rdoObreros.UseVisualStyleBackColor = true;
            this.rdoObreros.CheckedChanged += new System.EventHandler(this.rdoObreros_CheckedChanged);
            // 
            // rdoEmpleado
            // 
            this.rdoEmpleado.AutoSize = true;
            this.rdoEmpleado.Checked = true;
            this.rdoEmpleado.Location = new System.Drawing.Point(125, 88);
            this.rdoEmpleado.Name = "rdoEmpleado";
            this.rdoEmpleado.Size = new System.Drawing.Size(91, 17);
            this.rdoEmpleado.TabIndex = 56;
            this.rdoEmpleado.TabStop = true;
            this.rdoEmpleado.Text = "EMPLEADOS";
            this.rdoEmpleado.UseVisualStyleBackColor = true;
            this.rdoEmpleado.CheckedChanged += new System.EventHandler(this.rdoEmpleado_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "ASIGNAR CARGO A :";
            // 
            // cboNuevoEncargado
            // 
            this.cboNuevoEncargado.FormattingEnabled = true;
            this.cboNuevoEncargado.Location = new System.Drawing.Point(77, 111);
            this.cboNuevoEncargado.Name = "cboNuevoEncargado";
            this.cboNuevoEncargado.Size = new System.Drawing.Size(326, 21);
            this.cboNuevoEncargado.TabIndex = 59;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::WinForms.Properties.Resources.boton_guardar;
            this.btnGuardar.Location = new System.Drawing.Point(161, 138);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 60;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmLiberarResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 178);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboNuevoEncargado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoObreros);
            this.Controls.Add(this.rdoEmpleado);
            this.Controls.Add(this.cboPersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiberarResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar Responsable";
            this.Load += new System.EventHandler(this.frmLiberarResponsable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPersonal;
        private System.Windows.Forms.RadioButton rdoObreros;
        private System.Windows.Forms.RadioButton rdoEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNuevoEncargado;
        private System.Windows.Forms.Button btnGuardar;
    }
}