using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenteJuego
{
    public partial class ComponenteAhorcado : Control
    {
        private int numErrores;
        private int width;
        private int height;
        private int headD;
        private int headX;
        private int headY;
        public ComponenteAhorcado()
        {
            InitializeComponent();

            NumErrores = 0;

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Refresh();
        }
        public int NumErrores
        {
            set
            {
                numErrores = value;
               
                OnCambiaError(EventArgs.Empty);
                
                this.Refresh();
            }
            get { return numErrores; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            pint(e.Graphics);
        }

        public void pint(Graphics g)
        {
            width = this.Width;
            height = this.Height;

            headD = (int)(width * 0.10);
            headX = (int)(width * 0.75) - headD / 2;
            headY = (int)(height * 0.15);

            Pen pen = new Pen(Color.Black,3);
            // pata izq
            g.DrawLine(pen, 0, height, (int)(width * 0.25), (int)(height * 0.75));

            //pata derech
            g.DrawLine(pen, (int)(width * 0.50), height, (int)(width * 0.25), (int)(height * 0.75));

            //viga
            g.DrawLine(pen, (int)(width * 0.25), 0, (int)(width * 0.25), (int)(height * 0.75));

            //palo
            g.DrawLine(pen, (int)(width * 0.25), 0, (int)(width * 0.75), 0);

            //soga
            g.DrawLine(pen, (int)(width * 0.75), 0, (int)(width * 0.75), (int)(height * 0.15));

            pen.Width = 2;
            if (NumErrores >= 1)
            {
                // Cabeza
                g.DrawEllipse(pen, headX, headY, headD, headD);
            }
            if (NumErrores >= 2)
            {
                // Cuerpo
                g.DrawLine(pen, (int)(width * 0.75), (int)(headY + headD), (int)(width * 0.75), (int)(height * 0.60));
            }
            if (NumErrores >= 3)
            {
                // Brazo izquierdo
                g.DrawLine(pen, (int)(width * 0.75), (int)(height * 0.35), (int)(width * 0.60), (int)(height * 0.45));
            }
            if (NumErrores >= 4)
            {
                // Brazo derecho
                g.DrawLine(pen, (int)(width * 0.75), (int)(height * 0.35), (int)(width * 0.90), (int)(height * 0.45));              
            }

            if (NumErrores >= 5)
            {
                //Pierna izquierda
                g.DrawLine(pen, (int)(width * 0.75), (int)(height * 0.60), (int)(width * 0.60), (int)(height * 0.75));
            }

            if (NumErrores >= 6)
            {
                // Pierna derecha
                g.DrawLine(pen, (int)(width * 0.75), (int)(height * 0.60), (int)(width * 0.90), (int)(height * 0.75));
            }

            if (NumErrores >= 7)
            {

                //Pen pen = new Pen(Color.Black, 2);

                // Coordenadas para los ojos en forma de X
                int eyeOffset = headD / 4;
                int eyeSize = headD / 5;

                // Ojo izquierdo
                g.DrawLine(pen, headX + eyeOffset - eyeSize / 2, headY + eyeOffset - eyeSize / 2, headX + eyeOffset + eyeSize / 2, headY + eyeOffset + eyeSize / 2);
                g.DrawLine(pen, headX + eyeOffset + eyeSize / 2, headY + eyeOffset - eyeSize / 2, headX + eyeOffset - eyeSize / 2, headY + eyeOffset + eyeSize / 2);

                // Ojo derecho
                g.DrawLine(pen, headX + headD - eyeOffset - eyeSize / 2, headY + eyeOffset - eyeSize / 2, headX + headD - eyeOffset + eyeSize / 2, headY + eyeOffset + eyeSize / 2);
                g.DrawLine(pen, headX + headD - eyeOffset + eyeSize / 2, headY + eyeOffset - eyeSize / 2, headX + headD - eyeOffset - eyeSize / 2, headY + eyeOffset + eyeSize / 2);

                OnAhorcado(EventArgs.Empty);

            }

        }

        [Category("Mi Evento")]
        [Description("Se lanza cuando se falla")]
        public event System.EventHandler CambiaError;
        public void OnCambiaError(EventArgs e)
        {
            CambiaError?.Invoke(this, e);
        }

        [Category("Mi Evento")]
        [Description("Se lanza cuando se falla")]
        public event System.EventHandler Ahorcado;
        public void OnAhorcado(EventArgs e)
        {
            Ahorcado?.Invoke(this, e);
        }
    }
}
