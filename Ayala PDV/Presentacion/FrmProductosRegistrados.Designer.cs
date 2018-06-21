namespace Ayala_PDV.Presentacion
{
    partial class FrmProductosRegistrados
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
            this.TablaProducto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TablaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaProducto
            // 
            this.TablaProducto.AllowUserToAddRows = false;
            this.TablaProducto.AllowUserToDeleteRows = false;
            this.TablaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablaProducto.Location = new System.Drawing.Point(0, 0);
            this.TablaProducto.Name = "TablaProducto";
            this.TablaProducto.ReadOnly = true;
            this.TablaProducto.Size = new System.Drawing.Size(601, 261);
            this.TablaProducto.TabIndex = 0;
            // 
            // FrmProductosRegistrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 261);
            this.Controls.Add(this.TablaProducto);
            this.Name = "FrmProductosRegistrados";
            this.Text = "Productos registrados";
            ((System.ComponentModel.ISupportInitialize)(this.TablaProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaProducto;
    }
}