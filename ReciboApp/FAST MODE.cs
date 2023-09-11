using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReciboApp
{
    public partial class FAST_MODE : Form
    {
        private bool isDragging = false;
        private Point dragStart;
        decimal Cont;
        public delegate void EnviarVariableDelegate(decimal resultado, decimal uni);
        public event EnviarVariableDelegate EnviarVariableEvent;
        public FAST_MODE()
        {
            InitializeComponent();
            Num.Select(0, Num.Text.Length);
            Num.Focus();
        }

        public void UsarDatos(string datos, string descripcion, string contenido, string medida, string solicitado, string recibido, string escaneado)
        {
            // Hacer algo con los datos, por ejemplo:
            Articulo.Text = datos + " " + descripcion;
            if (medida == "CARTON")
                Contenido.Text = contenido + " EL " + medida;
            else if (medida == "PIEZA")
                Contenido.Text = contenido + " LA " + medida;
            else
                Contenido.Text = contenido + " / " + medida;
            Solicitado.Text = solicitado + " " + medida;
            Recibido.Text = recibido + " " + medida;
            Escaneado.Text = escaneado + " PIEZAS";
            Pendiente.Text = Math.Round((double.Parse(solicitado) - double.Parse(recibido)), 2).ToString() + " " + medida;
            Med.Text = medida;
            Cont = decimal.Parse(contenido);
        }

        private void Pb_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStart = e.Location;
            }
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - dragStart.X;
                int deltaY = e.Y - dragStart.Y;

                this.Left += deltaX;
                this.Top += deltaY;
            }
        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                decimal mul = Num.Value * Cont;
                EnviarVariableEvent(mul, Num.Value);
                this.Close();
            }
        }
    }
}
