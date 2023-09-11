namespace ReciboApp
{
    partial class FAST_MODE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAST_MODE));
            label1 = new Label();
            label2 = new Label();
            fontDialog1 = new FontDialog();
            Articulo = new Label();
            Contenido = new Label();
            Num = new NumericUpDown();
            Pb_Cerrar = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label5 = new Label();
            Solicitado = new Label();
            label3 = new Label();
            Escaneado = new Label();
            label4 = new Label();
            Recibido = new Label();
            label6 = new Label();
            Pendiente = new Label();
            Med = new Label();
            ((System.ComponentModel.ISupportInitialize)Num).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Pb_Cerrar).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(69, 52);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 0;
            label1.Text = "ARTÍCULO:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(69, 104);
            label2.Name = "label2";
            label2.Size = new Size(112, 19);
            label2.TabIndex = 1;
            label2.Text = "CONTENIDO:";
            // 
            // Articulo
            // 
            Articulo.Anchor = AnchorStyles.Top;
            Articulo.AutoSize = true;
            Articulo.FlatStyle = FlatStyle.Flat;
            Articulo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Articulo.Location = new Point(209, 52);
            Articulo.Name = "Articulo";
            Articulo.Size = new Size(86, 18);
            Articulo.TabIndex = 2;
            Articulo.Text = "ARTÍCULO";
            // 
            // Contenido
            // 
            Contenido.Anchor = AnchorStyles.Top;
            Contenido.AutoSize = true;
            Contenido.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Contenido.Location = new Point(209, 104);
            Contenido.Name = "Contenido";
            Contenido.Size = new Size(86, 18);
            Contenido.TabIndex = 3;
            Contenido.Text = "ARTÍCULO";
            // 
            // Num
            // 
            Num.Anchor = AnchorStyles.Top;
            Num.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Num.Location = new Point(284, 253);
            Num.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            Num.Minimum = new decimal(new int[] { 1, 0, 0, 458752 });
            Num.Name = "Num";
            Num.Size = new Size(140, 29);
            Num.TabIndex = 4;
            Num.TextAlign = HorizontalAlignment.Center;
            Num.Value = new decimal(new int[] { 1, 0, 0, 0 });
            Num.KeyDown += Num_KeyDown;
            // 
            // Pb_Cerrar
            // 
            Pb_Cerrar.Anchor = AnchorStyles.Top;
            Pb_Cerrar.BackColor = Color.Blue;
            Pb_Cerrar.Cursor = Cursors.Hand;
            Pb_Cerrar.Image = (Image)resources.GetObject("Pb_Cerrar.Image");
            Pb_Cerrar.Location = new Point(654, 3);
            Pb_Cerrar.Name = "Pb_Cerrar";
            Pb_Cerrar.Size = new Size(54, 33);
            Pb_Cerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb_Cerrar.TabIndex = 5;
            Pb_Cerrar.TabStop = false;
            Pb_Cerrar.Click += Pb_Cerrar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.Blue;
            flowLayoutPanel1.Controls.Add(Pb_Cerrar);
            flowLayoutPanel1.Cursor = Cursors.Hand;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, -3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(711, 36);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.MouseDown += flowLayoutPanel1_MouseDown;
            flowLayoutPanel1.MouseMove += flowLayoutPanel1_MouseMove;
            flowLayoutPanel1.MouseUp += flowLayoutPanel1_MouseUp;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(69, 158);
            label5.Name = "label5";
            label5.Size = new Size(112, 19);
            label5.TabIndex = 7;
            label5.Text = "SOLICITADO:";
            // 
            // Solicitado
            // 
            Solicitado.Anchor = AnchorStyles.Top;
            Solicitado.AutoSize = true;
            Solicitado.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Solicitado.Location = new Point(209, 158);
            Solicitado.Name = "Solicitado";
            Solicitado.Size = new Size(86, 18);
            Solicitado.TabIndex = 8;
            Solicitado.Text = "ARTÍCULO";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(383, 157);
            label3.Name = "label3";
            label3.Size = new Size(118, 19);
            label3.TabIndex = 9;
            label3.Text = "ESCANEADO:";
            // 
            // Escaneado
            // 
            Escaneado.Anchor = AnchorStyles.Top;
            Escaneado.AutoSize = true;
            Escaneado.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Escaneado.Location = new Point(519, 157);
            Escaneado.Name = "Escaneado";
            Escaneado.Size = new Size(86, 18);
            Escaneado.TabIndex = 10;
            Escaneado.Text = "ARTÍCULO";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(383, 104);
            label4.Name = "label4";
            label4.Size = new Size(94, 19);
            label4.TabIndex = 11;
            label4.Text = "RECIBIDO:";
            // 
            // Recibido
            // 
            Recibido.Anchor = AnchorStyles.Top;
            Recibido.AutoSize = true;
            Recibido.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Recibido.Location = new Point(519, 104);
            Recibido.Name = "Recibido";
            Recibido.Size = new Size(86, 18);
            Recibido.TabIndex = 12;
            Recibido.Text = "ARTÍCULO";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(69, 205);
            label6.Name = "label6";
            label6.Size = new Size(109, 19);
            label6.TabIndex = 13;
            label6.Text = "PENDIENTE:";
            // 
            // Pendiente
            // 
            Pendiente.Anchor = AnchorStyles.Top;
            Pendiente.AutoSize = true;
            Pendiente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Pendiente.Location = new Point(209, 205);
            Pendiente.Name = "Pendiente";
            Pendiente.Size = new Size(86, 18);
            Pendiente.TabIndex = 14;
            Pendiente.Text = "ARTÍCULO";
            // 
            // Med
            // 
            Med.Anchor = AnchorStyles.Top;
            Med.AutoSize = true;
            Med.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Med.Location = new Point(448, 258);
            Med.Name = "Med";
            Med.Size = new Size(92, 19);
            Med.TabIndex = 15;
            Med.Text = "ARTÍCULO";
            // 
            // FAST_MODE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 308);
            Controls.Add(Med);
            Controls.Add(Pendiente);
            Controls.Add(label6);
            Controls.Add(Recibido);
            Controls.Add(label4);
            Controls.Add(Escaneado);
            Controls.Add(label3);
            Controls.Add(Solicitado);
            Controls.Add(label5);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Num);
            Controls.Add(Contenido);
            Controls.Add(Articulo);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FAST_MODE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FAST_MODE";
            ((System.ComponentModel.ISupportInitialize)Num).EndInit();
            ((System.ComponentModel.ISupportInitialize)Pb_Cerrar).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private FontDialog fontDialog1;
        private Label Articulo;
        private Label Contenido;
        private NumericUpDown Num;
        private PictureBox Pb_Cerrar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label5;
        private Label Solicitado;
        private Label label3;
        private Label Escaneado;
        private Label label4;
        private Label Recibido;
        private Label label6;
        private Label Pendiente;
        private Label Med;
    }
}