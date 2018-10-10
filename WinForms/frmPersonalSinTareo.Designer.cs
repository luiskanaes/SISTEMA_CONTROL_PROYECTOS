namespace WinForms
{
    partial class frmPersonalSinTareo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCabecera = new System.Windows.Forms.Label();
            this.checkTodos = new System.Windows.Forms.CheckBox();
            this.btnFaltos = new System.Windows.Forms.Button();
            this.btnBajada = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(693, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblCabecera
            // 
            this.lblCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCabecera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecera.ForeColor = System.Drawing.Color.White;
            this.lblCabecera.Location = new System.Drawing.Point(9, 9);
            this.lblCabecera.Name = "lblCabecera";
            this.lblCabecera.Size = new System.Drawing.Size(696, 23);
            this.lblCabecera.TabIndex = 21;
            this.lblCabecera.Text = "Personal sin Tareo";
            this.lblCabecera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkTodos
            // 
            this.checkTodos.AutoSize = true;
            this.checkTodos.Location = new System.Drawing.Point(12, 48);
            this.checkTodos.Name = "checkTodos";
            this.checkTodos.Size = new System.Drawing.Size(110, 17);
            this.checkTodos.TabIndex = 48;
            this.checkTodos.Text = "Seleccionar Todo";
            this.checkTodos.UseVisualStyleBackColor = true;
            this.checkTodos.CheckedChanged += new System.EventHandler(this.checkTodos_CheckedChanged);
            // 
            // btnFaltos
            // 
            this.btnFaltos.Location = new System.Drawing.Point(129, 36);
            this.btnFaltos.Name = "btnFaltos";
            this.btnFaltos.Size = new System.Drawing.Size(100, 30);
            this.btnFaltos.TabIndex = 49;
            this.btnFaltos.Text = "Falta";
            this.btnFaltos.UseVisualStyleBackColor = true;
            this.btnFaltos.Click += new System.EventHandler(this.btnFaltos_Click);
            // 
            // btnBajada
            // 
            this.btnBajada.Location = new System.Drawing.Point(236, 36);
            this.btnBajada.Name = "btnBajada";
            this.btnBajada.Size = new System.Drawing.Size(100, 30);
            this.btnBajada.TabIndex = 50;
            this.btnBajada.Text = "Bajada";
            this.btnBajada.UseVisualStyleBackColor = true;
            this.btnBajada.Click += new System.EventHandler(this.btnBajada_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 51;
            this.button1.Text = "Enfermo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPersonalSinTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBajada);
            this.Controls.Add(this.btnFaltos);
            this.Controls.Add(this.checkTodos);
            this.Controls.Add(this.lblCabecera);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalSinTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonalSinTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCabecera;
        private System.Windows.Forms.CheckBox checkTodos;
        private System.Windows.Forms.Button btnFaltos;
        private System.Windows.Forms.Button btnBajada;
        private System.Windows.Forms.Button button1;
    }
}