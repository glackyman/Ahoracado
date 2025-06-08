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

            ValidarInputs(); // ← Comprobar si el valor inicial ya es válido

            // Eventos para validar mientras escribe
            txtIp.TextChanged += (s, ev) => ValidarInputs();
            txtPort.TextChanged += (s, ev) => ValidarInputs();
        }

        private void ValidarInputs()
        {
            bool ipValida = System.Net.IPAddress.TryParse(txtIp.Text, out _);

            bool puertoValido = int.TryParse(txtPort.Text, out int port) &&
                                port >= 1 && port <= 65535;

            btnOK.Enabled = ipValida && puertoValido;
            lblWarningConexion.Visible = !btnOK.Enabled;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
        parenet.ep.Address = System.Net.IPAddress.Parse(txtIp.Text);
            parenet.ep.Port = int.Parse(txtPort.Text);
        }
    }
}
