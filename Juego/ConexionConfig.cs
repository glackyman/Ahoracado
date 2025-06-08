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
    public partial class ConexionConfig : Form
    {
        private Form1 parenet;

        public ConexionConfig(Form1 parent)
        {
            InitializeComponent();

            this.parenet = parent;
        }

        private void ConexionConfig_Load(object sender, EventArgs e)
        {
            txtIp.Text = parenet.ep.Address.ToString();
            txtPort.Text = parenet.ep.Port.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            parenet.ep.Address = System.Net.IPAddress.Parse(txtIp.Text);
            parenet.ep.Port = int.Parse(txtPort.Text);
        }
    }
}
