namespace Ayala_PDV.Presentacion
{
    partial class FrmVenta
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tablaVentas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRegistrarVenta = new System.Windows.Forms.Button();
            this.LblCambio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPagara = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.ClmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDistribuidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ClmMenos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaVentas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tablaVentas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 435);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tablaVentas
            // 
            this.tablaVentas.AllowUserToAddRows = false;
            this.tablaVentas.AllowUserToDeleteRows = false;
            this.tablaVentas.BackgroundColor = System.Drawing.Color.White;
            this.tablaVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmId,
            this.clmNombre,
            this.ClmDistribuidor,
            this.ClmCodigo,
            this.ClmCantidad,
            this.ClmPrecio,
            this.ClmCosto,
            this.ClmMas,
            this.ClmMenos});
            this.tablaVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaVentas.Location = new System.Drawing.Point(6, 94);
            this.tablaVentas.Name = "tablaVentas";
            this.tablaVentas.ReadOnly = true;
            this.tablaVentas.Size = new System.Drawing.Size(845, 244);
            this.tablaVentas.TabIndex = 0;
            this.tablaVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaVentas_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 79);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnCancelar);
            this.panel3.Controls.Add(this.BtnAgregar);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.TxtCodigo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 79);
            this.panel3.TabIndex = 5;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(406, 27);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(122, 30);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar venta";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(314, 27);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(86, 30);
            this.BtnAgregar.TabIndex = 3;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Código de producto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(168, 33);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(127, 20);
            this.TxtCodigo.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnRegistrarVenta);
            this.panel2.Controls.Add(this.LblCambio);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxtPagara);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.LblTotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 82);
            this.panel2.TabIndex = 4;
            // 
            // BtnRegistrarVenta
            // 
            this.BtnRegistrarVenta.Enabled = false;
            this.BtnRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrarVenta.Location = new System.Drawing.Point(660, 12);
            this.BtnRegistrarVenta.Name = "BtnRegistrarVenta";
            this.BtnRegistrarVenta.Size = new System.Drawing.Size(160, 59);
            this.BtnRegistrarVenta.TabIndex = 0;
            this.BtnRegistrarVenta.Text = "Registrar venta";
            this.BtnRegistrarVenta.UseVisualStyleBackColor = true;
            this.BtnRegistrarVenta.Click += new System.EventHandler(this.BtnRegistrarVenta_Click);
            // 
            // LblCambio
            // 
            this.LblCambio.AutoSize = true;
            this.LblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCambio.Location = new System.Drawing.Point(501, 33);
            this.LblCambio.Name = "LblCambio";
            this.LblCambio.Size = new System.Drawing.Size(27, 20);
            this.LblCambio.TabIndex = 7;
            this.LblCambio.Text = "$0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cambio:";
            // 
            // TxtPagara
            // 
            this.TxtPagara.Location = new System.Drawing.Point(331, 35);
            this.TxtPagara.Name = "TxtPagara";
            this.TxtPagara.Size = new System.Drawing.Size(100, 20);
            this.TxtPagara.TabIndex = 5;
            this.TxtPagara.TextChanged += new System.EventHandler(this.TxtPagara_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Se pagará con:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total a pagar:";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(118, 35);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(27, 20);
            this.LblTotal.TabIndex = 2;
            this.LblTotal.Text = "$0";
            // 
            // ClmId
            // 
            this.ClmId.HeaderText = "No. producto";
            this.ClmId.Name = "ClmId";
            this.ClmId.ReadOnly = true;
            this.ClmId.Width = 65;
            // 
            // clmNombre
            // 
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            this.clmNombre.Width = 130;
            // 
            // ClmDistribuidor
            // 
            this.ClmDistribuidor.HeaderText = "Distribuidor";
            this.ClmDistribuidor.Name = "ClmDistribuidor";
            this.ClmDistribuidor.ReadOnly = true;
            this.ClmDistribuidor.Width = 130;
            // 
            // ClmCodigo
            // 
            this.ClmCodigo.HeaderText = "Código";
            this.ClmCodigo.Name = "ClmCodigo";
            this.ClmCodigo.ReadOnly = true;
            // 
            // ClmCantidad
            // 
            this.ClmCantidad.HeaderText = "Cantidad";
            this.ClmCantidad.Name = "ClmCantidad";
            this.ClmCantidad.ReadOnly = true;
            this.ClmCantidad.Width = 65;
            // 
            // ClmPrecio
            // 
            this.ClmPrecio.HeaderText = "Precio";
            this.ClmPrecio.Name = "ClmPrecio";
            this.ClmPrecio.ReadOnly = true;
            this.ClmPrecio.Width = 70;
            // 
            // ClmCosto
            // 
            this.ClmCosto.HeaderText = "SubTotal";
            this.ClmCosto.Name = "ClmCosto";
            this.ClmCosto.ReadOnly = true;
            this.ClmCosto.Width = 90;
            // 
            // ClmMas
            // 
            this.ClmMas.HeaderText = "Sumar producto";
            this.ClmMas.Name = "ClmMas";
            this.ClmMas.ReadOnly = true;
            this.ClmMas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmMas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClmMas.Text = "+";
            this.ClmMas.Width = 75;
            // 
            // ClmMenos
            // 
            this.ClmMenos.HeaderText = "Restar producto";
            this.ClmMenos.MinimumWidth = 50;
            this.ClmMenos.Name = "ClmMenos";
            this.ClmMenos.ReadOnly = true;
            this.ClmMenos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmMenos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClmMenos.Text = "-";
            this.ClmMenos.Width = 75;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 435);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmVenta";
            this.Text = "FrmVenta";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaVentas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Button BtnRegistrarVenta;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tablaVentas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPagara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDistribuidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCosto;
        private System.Windows.Forms.DataGridViewButtonColumn ClmMas;
        private System.Windows.Forms.DataGridViewButtonColumn ClmMenos;
    }
}