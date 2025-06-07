using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private Timer timer;
        private int elapsedSeconds;
        private string playerName;
        private string currentWord;
        private List<string> records;

        public Form1()
        {
            InitializeComponent();

            ConnectToServer();

            // Configurar temporizador
            //timer = new Timer();
            //timer.Interval = 1000; // 1 segundo
            //timer.Tick += Timer_Tick;
        }

        private void ConnectToServer()
        {
            client = new TcpClient("localhost", 31416); // Dirección IP y puerto del servidor
            stream = client.GetStream();
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    elapsedSeconds++;
        //    // Actualizar etiqueta de tiempo transcurrido
        //    lblTimeElapsed.Text = $"Time elapsed: {elapsedSeconds} seconds";
        //}

        // Método para iniciar un nuevo juego
        private void StartNewGame()
        {
            // Pedir una nueva palabra al servidor
            writer.WriteLine("getword");
            currentWord = reader.ReadLine();

            // Mostrar la palabra a adivinar en el formulario de juego
            DisplayWordToGuess(currentWord);

            // Iniciar el temporizador
            elapsedSeconds = 0;
            timer.Start();
        }

        // Método para mostrar la palabra a adivinar en el formulario de juego
        private void DisplayWordToGuess(string word)
        {
            // Implementar lógica para mostrar la palabra en el formulario
        }

        // Método para manejar la lógica al enviar una palabra al servidor
        private void SendWordToServer(string word)
        {
            writer.WriteLine($"sendword {word}");
            string response = reader.ReadLine();
            // Manejar la respuesta del servidor
        }

        // Método para manejar la lógica al enviar un récord al servidor
        private void SendRecordToServer(int seconds)
        {
            writer.WriteLine($"sendrecord {playerName} {seconds}");
            string response = reader.ReadLine();
            // Manejar la respuesta del servidor
        }

        // Método para mostrar la tabla de récords recibida del servidor
        private void ShowRecords()
        {
            // Pedir la tabla de récords al servidor
            writer.WriteLine("getrecords");
            // Leer y mostrar la tabla de récords recibida del servidor
        }
    }
}
