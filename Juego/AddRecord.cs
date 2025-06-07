using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego
{
    public partial class AddRecord : Form
    {
        private string nombre;

        public AddRecord(Form1 f)
        {
            InitializeComponent();

            label2.Text = f.Time.ToString();
            toolTip1.SetToolTip(textBox1, "El nombre deben ser 3 caracteres");
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (((Button)sender) == btnOk)
            {
                Name = textBox1.Text;
                DialogResult = DialogResult.Yes;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
