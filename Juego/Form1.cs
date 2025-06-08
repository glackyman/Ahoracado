using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using Label = System.Windows.Forms.Label;
namespace Juego
{
    public partial class Form1 : Form
    {
        private string config = Environment.GetEnvironmentVariable("programdata") + "/config.txt";

        private readonly object l = new object();
        public IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31416);
        private Socket client;
        private Thread t;
        private Timer timer;
        private Label letraLabel;

        private List<string> palabras = new List<string>();
      

        private int vidas = 7;
        private int timeSeconds = 0;
        private int minutes;
        private int seconds;
        private string command;
        private string palabra = " ";

        public Form1()
        {
            InitializeComponent();

            t = new Thread(Cliente);
            t.IsBackground = true;
            t.Start();

            this.Text = $"Ahorcado";

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Método que se ejecuta en un hilo separado para manejar la conexión del cliente al servidor.
        /// </summary>
        private void Cliente()
        {
            while (true)
            {
                lock (l)
                {
                    Monitor.Wait(l);
                }

                using (client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    client.Connect(ep);
                    this.Invoke(new Action(() => Text = "Connect"));

                    using (NetworkStream ns = new NetworkStream(client))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        switch (command)
                        {
                            case string s when command == "getword":
                                GetWord();
                                break;
                        }
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConexionConfig();

            GetWord();
        }

        /// <summary>
        /// Obtiene el tiempo transcurrido en formato "mm:ss".
        /// </summary>
        public string Time
        {
            get { return $"Tiempo: {minutes:D2}:{seconds:D2}"; }
        }

        /// <summary>
        /// Se comunica el servdor, y solicita una palabra de la lista interna.
        /// </summary>
        private void GetWord()
        {
            this.Invoke(new Action(() =>
            {
                using (client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    client.Connect(ep);
                    using (NetworkStream ns = new NetworkStream(client))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        sw.WriteLine("getword");
                        sw.Flush();
                        palabra = sr.ReadLine();
                        label2.Text = palabra;
                        printLabels();
                    }
                }
            }));
        }
        
        /// <summary>
        /// Genera labels, o borra las que existan, para cada letra de la palabra a adivinar.
        /// </summary>
        private void printLabels()
        {
            //borra antiguas lavels (si existen)
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Label && this.Controls[i].Name.StartsWith("char"))
                {
                    this.Controls.RemoveAt(i);
                }
            }
            //nuevas labels
            for (int i = 0; i < palabra.Length; i++)
            {
                letraLabel = new Label();
                letraLabel.Name = "char" + i;
                letraLabel.Text = "_";
                letraLabel.Font = new Font("Arial", 24, FontStyle.Regular);
                letraLabel.AutoSize = true;
                letraLabel.Location = new Point(10 + i * 40, 361);
                Controls.Add(letraLabel);
            }
        }

        /// <summary>
        /// Lista de letras incorrectas.
        /// </summary>
        /// <param name="c"></param>
        private void printChar(char c)
        {
            textBox2.AppendText($"{c.ToString()} ");
        }

        /// <summary>
        /// Victoria del jugador, se pregunta si se quiere guardar el progreso.
        /// </summary>
        private void isWon()
        {
            timer.Stop();
            if (MessageBox.Show("Formidable, quieres guardar tu record?", "Enhorabuena", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                AddRecord form = new AddRecord(this);
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    records(true, $"{form.Name} {Time} {ahorcado1.NumErrores}");
                }
            }
        }

        /// <summary>
        /// Guarda o muestra los records del jugador.
        /// </summary>
        /// <param name="flag">Flag que decide si se guarda o se muestra el record</param>
        /// <param name="dato"></param>
        private void records(bool flag, string dato)
        {
            //try
            //{
            //    if (flag)
            //    {
            //        using (StreamWriter sw = new StreamWriter(fileRecords, true))
            //        {
            //            sw.WriteLine(dato);
            //        }
            //    }
            //    else
            //    {

            //        using (StreamReader reader = new StreamReader(fileRecords))
            //        {
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                ShowRecords showRecords = new ShowRecords();

            //                showRecords.textBox1.Text = reader.ReadToEnd();


            //                showRecords.ShowDialog();

            //            }
            //        }
            //    }
            //}
            //catch (FileNotFoundException ex9)
            //{
            //    MessageBox.Show("No existen records", "Nah Formidable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    using (StreamWriter sw = new StreamWriter(fileRecords))
            //    {

            //    }
            //}
            //catch (IOException ex)
            //{
            //    MessageBox.Show("No existen records", "Nah Formidable", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        /// <summary>
        /// Actualiza el tiempo transcurrido cada segundo y lo muestra en el título de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeSeconds = timeSeconds + 1;

            minutes = timeSeconds / 60;
            seconds = timeSeconds % 60;

            this.Text = $"Ahorcado - {Time}";
        }

        /// <summary>
        /// Evento que se dispara cuando el jugador pierde todas sus vidas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ahorcado_Ahorcado(object sender, EventArgs e)
        {
            timer?.Stop();
            btnTryWord.Enabled = false;
            MessageBox.Show("No tienes mas vidas", "Perdiste!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Intenta adivinar una letra de la palabra actual.
        /// Primero comprueba que la letra es valida, si lo es, comprueba si esta en la palabra.
        /// Si la letra esta en la palabra, actualiza las labels correspondientes.
        /// Luego comprueba si se ha adivinado toda la palabra, si es asi se gana el juego.
        /// Si la letra no esta en la palabra, se imprime la letra en el TextBox de letras incorrectas y se resta una vida, tambien se actualiza el componente de ahorcado aumentenado los errores.
        /// esto es un componente que dibuja el ahorcado y se actualiza cada vez que se comete un error.
        /// pase lo que pase el textbox es vaciado para que el jugador pueda introducir una nueva letra en la siguiente jugada.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryWord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && char.IsLetter(textBox1.Text[0]) && !string.IsNullOrEmpty(palabra))
            {
                char letra = textBox1.Text.ToLower()[0];
                bool acierto = palabra.Contains(letra);

                if (acierto)
                {
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        if (palabra[i] == letra)
                        {
                            Label label = this.Controls.Find("char" + i, true)[0] as Label;
                            if (label != null)
                            {
                                label.Text = letra.ToString().ToUpper();
                            }
                        }
                    }

                    bool checkIfFinish = true;
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        Label label = this.Controls.Find("char" + i, true)[0] as Label;
                        if (label != null && label.Text != palabra[i].ToString().ToUpper())
                        {
                            checkIfFinish = false;
                            break;
                        }
                    }
                    if (checkIfFinish)
                    {
                        isWon();
                        btnTryWord.Enabled = false;
                    }
                }
                else
                {
                    if (!textBox2.Text.Contains(letra))
                    {
                        printChar(letra);
                        ahorcado1.NumErrores++;

                        vidas--;
                        lblVidas.Text = $"Vidas: {vidas}";
                    }
                }
                textBox1.Clear();
            }
        }

        /// <summary>
        /// Inicia un nuevo juego, obteniendo una nueva palabra aleatoria, reiniciando todo el juego; palabra, errores, labels, vidas, tiempo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void juegoNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWord();
            label2.Text = palabra;
            ahorcado1.NumErrores = 0;
            printLabels();
            vidas = 7;
            lblVidas.Text = $"Vidas: {vidas}";
            textBox2.Clear();
            timeSeconds = 0;
            btnTryWord.Enabled = true;
            if (timer != null && !timer.Enabled)
            {
                timer?.Start();
            }
        }

        /// <summary>
        /// Muestra los records guardados en el archivo de records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            records(false, "");
        }

        /// <summary>
        /// Saca un modal para cambiar la configuracion red del cliente
        /// Si la respuesta es OK cambia la configuración de conexión y la guarda en un archivo de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConexionConfig(object sender, EventArgs e)
        {
            ConexionConfig config = new ConexionConfig(this);
            config.ShowDialog();

            if (config.DialogResult == DialogResult.OK)
            {
                SaveConexionConfig();
            }
        }

        /// <summary>
        /// Carga la configuración de conexión desde un archivo de texto.
        /// Si el archivo no existe, crea uno con la IP y puerto actuales.
        /// Si el archivo existe, lee la IP y el puerto y los asigna al IPEndPoint.
        /// </summary>
        private void LoadConexionConfig()
        {
            try
            {
                if (!File.Exists(config))
                {
                    // Guardar IP y puerto actuales
                    using (StreamWriter sw = new StreamWriter(config))
                    {
                        sw.WriteLine(ep.Address.ToString());
                        sw.WriteLine(ep.Port.ToString());
                    }
                }
                else
                {
                    // Leer IP y puerto del archivo
                    string[] lines = File.ReadAllLines(config);
                    if (lines.Length >= 2)
                    {
                        string ipStr = lines[0].Trim();
                        string portStr = lines[1].Trim();

                        if (IPAddress.TryParse(ipStr, out IPAddress ip) && int.TryParse(portStr, out int port))
                        {
                            ep = new IPEndPoint(ip, port);
                        }
                        else
                        {
                            MessageBox.Show("La configuración de IP o puerto no es válida.", "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda la configuración de conexión en un archivo de texto.
        /// </summary>
        private void SaveConexionConfig()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(config))
                {
                    sw.WriteLine(ep.Address.ToString());
                    sw.WriteLine(ep.Port.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
