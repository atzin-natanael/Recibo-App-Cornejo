namespace ReciboApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Txt_Folio = new TextBox();
            label1 = new Label();
            Btn_Buscar = new Button();
            Data_Datos = new DataGridView();
            Código = new DataGridViewTextBoxColumn();
            Descripción = new DataGridViewTextBoxColumn();
            Medida = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            Contenido = new DataGridViewTextBoxColumn();
            Unidades = new DataGridViewTextBoxColumn();
            Recibidas = new DataGridViewTextBoxColumn();
            Objetivo = new DataGridViewTextBoxColumn();
            Capturado = new DataGridViewTextBoxColumn();
            Txt_Escanear = new TextBox();
            label2 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            Btn_PDF = new Button();
            saveFileDialog1 = new SaveFileDialog();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Data_Datos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Txt_Folio
            // 
            Txt_Folio.Anchor = AnchorStyles.Top;
            Txt_Folio.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Txt_Folio.Location = new Point(502, 13);
            Txt_Folio.Margin = new Padding(4);
            Txt_Folio.Multiline = true;
            Txt_Folio.Name = "Txt_Folio";
            Txt_Folio.Size = new Size(242, 41);
            Txt_Folio.TabIndex = 0;
            Txt_Folio.KeyDown += Txt_Folio_KeyDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(288, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(192, 25);
            label1.TabIndex = 1;
            label1.Text = "ORDEN DE COMPRA";
            // 
            // Btn_Buscar
            // 
            Btn_Buscar.Anchor = AnchorStyles.Top;
            Btn_Buscar.BackColor = Color.SteelBlue;
            Btn_Buscar.Cursor = Cursors.Hand;
            Btn_Buscar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Buscar.Location = new Point(776, 14);
            Btn_Buscar.Margin = new Padding(4);
            Btn_Buscar.Name = "Btn_Buscar";
            Btn_Buscar.Size = new Size(158, 42);
            Btn_Buscar.TabIndex = 2;
            Btn_Buscar.Text = "BUSCAR";
            Btn_Buscar.UseVisualStyleBackColor = false;
            Btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // Data_Datos
            // 
            Data_Datos.AllowUserToAddRows = false;
            Data_Datos.AllowUserToDeleteRows = false;
            Data_Datos.AllowUserToOrderColumns = true;
            Data_Datos.AllowUserToResizeColumns = false;
            Data_Datos.AllowUserToResizeRows = false;
            Data_Datos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Data_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            Data_Datos.BorderStyle = BorderStyle.None;
            Data_Datos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Data_Datos.Columns.AddRange(new DataGridViewColumn[] { Código, Descripción, Medida, PrecioUnitario, Contenido, Unidades, Recibidas, Objetivo, Capturado });
            Data_Datos.EditMode = DataGridViewEditMode.EditOnF2;
            Data_Datos.Location = new Point(15, 205);
            Data_Datos.Margin = new Padding(4);
            Data_Datos.Name = "Data_Datos";
            Data_Datos.RowHeadersVisible = false;
            Data_Datos.RowTemplate.Height = 25;
            Data_Datos.Size = new Size(1105, 542);
            Data_Datos.TabIndex = 3;
            Data_Datos.CellEndEdit += Data_Datos_CellEndEdit;
            Data_Datos.CellFormatting += Data_Datos_CellFormatting;
            Data_Datos.EditingControlShowing += Data_Datos_EditingControlShowing;
            // 
            // Código
            // 
            Código.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Código.HeaderText = "Código";
            Código.Name = "Código";
            // 
            // Descripción
            // 
            Descripción.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Descripción.HeaderText = "Descripción";
            Descripción.Name = "Descripción";
            Descripción.Width = 117;
            // 
            // Medida
            // 
            Medida.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Medida.HeaderText = "Medida";
            Medida.Name = "Medida";
            // 
            // PrecioUnitario
            // 
            PrecioUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrecioUnitario.HeaderText = "Precio";
            PrecioUnitario.Name = "PrecioUnitario";
            // 
            // Contenido
            // 
            Contenido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Contenido.HeaderText = "Contenido";
            Contenido.Name = "Contenido";
            // 
            // Unidades
            // 
            Unidades.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Unidades.HeaderText = "Unidades";
            Unidades.Name = "Unidades";
            // 
            // Recibidas
            // 
            Recibidas.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Recibidas.HeaderText = "Recibidas";
            Recibidas.Name = "Recibidas";
            // 
            // Objetivo
            // 
            Objetivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Objetivo.HeaderText = "Objetivo";
            Objetivo.Name = "Objetivo";
            // 
            // Capturado
            // 
            Capturado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Capturado.HeaderText = "Capturado";
            Capturado.Name = "Capturado";
            // 
            // Txt_Escanear
            // 
            Txt_Escanear.Anchor = AnchorStyles.Top;
            Txt_Escanear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Txt_Escanear.Location = new Point(572, 140);
            Txt_Escanear.Margin = new Padding(4);
            Txt_Escanear.Name = "Txt_Escanear";
            Txt_Escanear.Size = new Size(242, 33);
            Txt_Escanear.TabIndex = 4;
            Txt_Escanear.KeyDown += Txt_Escanear_KeyDown;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(325, 143);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(228, 25);
            label2.TabIndex = 5;
            label2.Text = "ARTÍCULO A ESCANEAR:";
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton1.Location = new Point(20, 100);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(189, 26);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "MODO POR CAJA";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top;
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton2.Location = new Point(20, 141);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(180, 26);
            radioButton2.TabIndex = 7;
            radioButton2.TabStop = true;
            radioButton2.Text = "MODO DIRECTO";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // Btn_PDF
            // 
            Btn_PDF.Anchor = AnchorStyles.Top;
            Btn_PDF.BackColor = Color.Maroon;
            Btn_PDF.Cursor = Cursors.Hand;
            Btn_PDF.Enabled = false;
            Btn_PDF.ForeColor = Color.White;
            Btn_PDF.Location = new Point(1005, 44);
            Btn_PDF.Name = "Btn_PDF";
            Btn_PDF.Size = new Size(115, 29);
            Btn_PDF.TabIndex = 8;
            Btn_PDF.Text = "Generar PDF";
            Btn_PDF.UseVisualStyleBackColor = false;
            Btn_PDF.Click += Btn_PDF_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Usuzi", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(422, 751);
            label3.Name = "label3";
            label3.Size = new Size(322, 15);
            label3.TabIndex = 9;
            label3.Text = "Developed by: AtziN Not Found";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(20, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1134, 772);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(Btn_PDF);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label2);
            Controls.Add(Txt_Escanear);
            Controls.Add(Data_Datos);
            Controls.Add(Btn_Buscar);
            Controls.Add(label1);
            Controls.Add(Txt_Folio);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Data_Datos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Folio;
        private Label label1;
        private Button Btn_Buscar;
        private DataGridView Data_Datos;
        private TextBox Txt_Escanear;
        private Label label2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button Btn_PDF;
        private SaveFileDialog saveFileDialog1;
        private DataGridViewTextBoxColumn Código;
        private DataGridViewTextBoxColumn Descripción;
        private DataGridViewTextBoxColumn Medida;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private DataGridViewTextBoxColumn Contenido;
        private DataGridViewTextBoxColumn Unidades;
        private DataGridViewTextBoxColumn Recibidas;
        private DataGridViewTextBoxColumn Objetivo;
        private DataGridViewTextBoxColumn Capturado;
        private Label label3;
        private PictureBox pictureBox1;
    }
}