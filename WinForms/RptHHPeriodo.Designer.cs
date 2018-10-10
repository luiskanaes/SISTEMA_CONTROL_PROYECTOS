﻿namespace WinForms
{
    partial class RptHHPeriodo
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFechaTermino = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsTareo = new WinForms.DataSet.DsTareo();
            this.sPRPTTAREODELDIAPERIODOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter = new WinForms.DataSet.DsTareoTableAdapters.SP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREODELDIAPERIODOBindingSource)).BeginInit();
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
            this.label2.Size = new System.Drawing.Size(1201, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Reporte HH por periodo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(819, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "TERMINO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "INICIO";
            // 
            // dateFechaTermino
            // 
            this.dateFechaTermino.Location = new System.Drawing.Point(883, 30);
            this.dateFechaTermino.Name = "dateFechaTermino";
            this.dateFechaTermino.Size = new System.Drawing.Size(200, 20);
            this.dateFechaTermino.TabIndex = 51;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(1087, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(612, 31);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(202, 20);
            this.dateFecha.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(65, 33);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 46;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "C. COSTO";
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(192, 32);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(372, 21);
            this.cboCentroCosto.TabIndex = 48;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPRPTTAREODELDIAPERIODOBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptHHPeriodo.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(3, 71);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(1194, 399);
            this.ReportViewer1.TabIndex = 54;
            // 
            // dsTareo
            // 
            this.dsTareo.DataSetName = "DsTareo";
            this.dsTareo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPRPTTAREODELDIAPERIODOBindingSource
            // 
            this.sPRPTTAREODELDIAPERIODOBindingSource.DataMember = "SP_RPT_TAREO_DEL_DIA_PERIODO";
            this.sPRPTTAREODELDIAPERIODOBindingSource.DataSource = this.dsTareo;
            // 
            // sP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter
            // 
            this.sP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter.ClearBeforeFill = true;
            // 
            // RptHHPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 482);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFechaTermino);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label2);
            this.Name = "RptHHPeriodo";
            this.Text = "RptHHPeriodo";
            this.Load += new System.EventHandler(this.RptHHPeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREODELDIAPERIODOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFechaTermino;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource sPRPTTAREODELDIAPERIODOBindingSource;
        private DataSet.DsTareo dsTareo;
        private DataSet.DsTareoTableAdapters.SP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter sP_RPT_TAREO_DEL_DIA_PERIODOTableAdapter;
    }
}