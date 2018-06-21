namespace Ayala_PDV.Presentacion
{
    partial class FrmReporteVentas
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
            this.TablaReporteVentas = new System.Windows.Forms.DataGridView();
            this.detalleVenta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concretada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGananciasPeriodo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblGananciasDesc = new System.Windows.Forms.Label();
            this.LblGanancias = new System.Windows.Forms.Label();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.CbCalendario = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporteVentas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablaReporteVentas
            // 
            this.TablaReporteVentas.AllowUserToAddRows = false;
            this.TablaReporteVentas.AllowUserToDeleteRows = false;
            this.TablaReporteVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReporteVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalleVenta,
            this.idVenta,
            this.Fecha,
            this.clmMonto,
            this.concretada});
            this.TablaReporteVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablaReporteVentas.Location = new System.Drawing.Point(4, 4);
            this.TablaReporteVentas.Name = "TablaReporteVentas";
            this.TablaReporteVentas.ReadOnly = true;
            this.TablaReporteVentas.Size = new System.Drawing.Size(543, 411);
            this.TablaReporteVentas.TabIndex = 0;
            this.TablaReporteVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaReporteVentas_CellClick);
            // 
            // detalleVenta
            // 
            this.detalleVenta.HeaderText = "Ver detalle de venta";
            this.detalleVenta.Name = "detalleVenta";
            this.detalleVenta.ReadOnly = true;
            // 
            // idVenta
            // 
            this.idVenta.HeaderText = "No.Venta";
            this.idVenta.Name = "idVenta";
            this.idVenta.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // clmMonto
            // 
            this.clmMonto.HeaderText = "Monto";
            this.clmMonto.Name = "clmMonto";
            this.clmMonto.ReadOnly = true;
            // 
            // concretada
            // 
            this.concretada.HeaderText = "Concretada";
            this.concretada.Name = "concretada";
            this.concretada.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 549F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Controls.Add(this.TablaReporteVentas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 419);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.LblGananciasPeriodo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LblGananciasDesc);
            this.panel2.Controls.Add(this.LblGanancias);
            this.panel2.Controls.Add(this.DtpFin);
            this.panel2.Controls.Add(this.DtpInicio);
            this.panel2.Controls.Add(this.CbCalendario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(554, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 411);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ganancias totales del periodo";
            // 
            // LblGananciasPeriodo
            // 
            this.LblGananciasPeriodo.AutoSize = true;
            this.LblGananciasPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGananciasPeriodo.Location = new System.Drawing.Point(75, 210);
            this.LblGananciasPeriodo.Name = "LblGananciasPeriodo";
            this.LblGananciasPeriodo.Size = new System.Drawing.Size(24, 25);
            this.LblGananciasPeriodo.TabIndex = 11;
            this.LblGananciasPeriodo.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha de inicio";
            // 
            // LblGananciasDesc
            // 
            this.LblGananciasDesc.AutoSize = true;
            this.LblGananciasDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGananciasDesc.Location = new System.Drawing.Point(2, 276);
            this.LblGananciasDesc.Name = "LblGananciasDesc";
            this.LblGananciasDesc.Size = new System.Drawing.Size(157, 24);
            this.LblGananciasDesc.TabIndex = 6;
            this.LblGananciasDesc.Text = "Ganancias totales";
            // 
            // LblGanancias
            // 
            this.LblGanancias.AutoSize = true;
            this.LblGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGanancias.Location = new System.Drawing.Point(75, 300);
            this.LblGanancias.Name = "LblGanancias";
            this.LblGanancias.Size = new System.Drawing.Size(24, 25);
            this.LblGanancias.TabIndex = 7;
            this.LblGanancias.Text = "0";
            // 
            // DtpFin
            // 
            this.DtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFin.Location = new System.Drawing.Point(15, 119);
            this.DtpFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(103, 20);
            this.DtpFin.TabIndex = 4;
            this.DtpFin.ValueChanged += new System.EventHandler(this.DtpFin_ValueChanged);
            // 
            // DtpInicio
            // 
            this.DtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicio.Location = new System.Drawing.Point(15, 68);
            this.DtpInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(103, 20);
            this.DtpInicio.TabIndex = 3;
            this.DtpInicio.ValueChanged += new System.EventHandler(this.DtpInicio_ValueChanged);
            // 
            // CbCalendario
            // 
            this.CbCalendario.AutoSize = true;
            this.CbCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCalendario.Location = new System.Drawing.Point(15, 13);
            this.CbCalendario.Name = "CbCalendario";
            this.CbCalendario.Size = new System.Drawing.Size(153, 24);
            this.CbCalendario.TabIndex = 5;
            this.CbCalendario.Text = "Aplicar calendario";
            this.CbCalendario.UseVisualStyleBackColor = true;
            this.CbCalendario.CheckedChanged += new System.EventHandler(this.CbCalendario_CheckedChanged);
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 419);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmReporteVentas";
            this.Text = "FrmReporteVentas";
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporteVentas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaReporteVentas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.CheckBox CbCalendario;
        private System.Windows.Forms.Label LblGanancias;
        private System.Windows.Forms.Label LblGananciasDesc;
        private System.Windows.Forms.DataGridViewButtonColumn detalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn concretada;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGananciasPeriodo;
    }
}