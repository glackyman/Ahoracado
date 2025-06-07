using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class MyServer //186
    {
        Socket serv;

        private string wordsTXT = Environment.GetEnvironmentVariable("programdata") + "/words.txt";
        private string recordsBIN = Environment.GetEnvironmentVariable("programdata") + "/records.bin";
        private string pinBIN = Environment.GetEnvironmentVariable("programdata") + "/pin.bin";

        private readonly object l = new object();
        List<Record> colRecords = new List<Record>();
        public void init()
        {
            int port = 31416;
            bool puertoEncontrado = false;

            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);

            using (serv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                while (!puertoEncontrado && port <= 65535)
                {
                    try
                    {
                        serv.Bind(ie);
                        puertoEncontrado = true;
                    }
                    catch (SocketException ex) when (ex.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                    {
                        Console.WriteLine($"El puerto {ie.Port} está en uso.");
                        port++;
                        ie.Port = ie.Port == port ? 1024 : ie.Port++;
                    }
                }

                try
                {
                    if (puertoEncontrado)
                    {
                        serv.Listen(10);
                        Console.WriteLine($"El servidor está esperando en el puerto {ie.Port}");

                        while (true)
                        {
                            Socket client = serv.Accept();
                            Thread thread = new Thread(() => threadClient(client));
                            thread.Start();
                            thread.IsBackground = true;
                        }
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("\nby");
                }

                if (!puertoEncontrado)
                {
                    Console.WriteLine("No se encontró ningún puerto disponible.");
                }
            }
        }

        public void threadClient(Socket client)
        {
            IPEndPoint ieCliente = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connected with client {0} at port {1}",
            ieCliente.Address, ieCliente.Port);

            using (NetworkStream ns = new NetworkStream(client))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                try
                {

                    string command = sr.ReadLine();
                    if (command != null)
                    {
                        string[] parts = command.Split(' ');

                        switch (parts[0])
                        {
                            case "getword":
                                sw.WriteLine(getWord());
                                Console.WriteLine("getWord loaded");
                                break;

                            case string s when parts[0] == ("sendword") && parts.Length == 2:
                                lock (l)
                                {
                                sw.WriteLine("etra sendword: " + parts[1]);
                                Console.WriteLine("newWord added");
                                addWord(parts[1]);
                                }
                                break;

                            // aun no realizado 
                            case "getrecords":
                                getRecords();
                                Console.WriteLine("getrecords");
                                break;

                            case string s when parts[0] == "sendrecord" && parts[1].Contains(","):
                                lock (l)
                                {
                                sendRecords(parts[1]);
                                sw.WriteLine("sendRecord");
                                }
                                break;

                            case string s when parts[0] == "closeserver" && parts.Length == 2:

                                if (parts[1] == getPin())
                                {
                                    sw.WriteLine("close");
                                    serv.Close();
                                }
                                break;

                            default:
                                sw.WriteLine("Invalid command");
                                break;
                                //
                        }
                        sw.Flush();
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("Finished connection with {0}:{1}",
               ieCliente.Address, ieCliente.Port);
            }
            client.Close();
        }
        public string getWord()
        {
            try
            {
                using (StreamReader sr = new StreamReader(wordsTXT))
                {
                    string[] usuariosFiltrados = sr.ReadToEnd().Split(',');

                    return usuariosFiltrados[new Random().Next(0, usuariosFiltrados.Length)];
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "-1";
        }
        public void addWord(string newWord)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(wordsTXT, true))
                {
                    sw.Write(String.Format($",{newWord}"));
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //falta por implementar bien opcion de eliminar records existentes
        public void sendRecords(string record)
        {
            try
            {
                string[] records = record.Split(',');
                if (records.Length == 2)
                {
                    using (BinWriterRecord bwr = new BinWriterRecord(new FileStream(recordsBIN, FileMode.Append)))
                    {
                        // Escribir los datos utilizando el formato UTF-8
                        bwr.WriteRecord(new Record(records[0], records[1]));
                    }
                }
                else
                {
                    Console.WriteLine("Formato de registro no válido. Se esperaba 'nombre,tiempo'.");
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        public void getRecords()
        {
            try
            {
                using (BinReaderRecord brr = new BinReaderRecord(new FileStream(recordsBIN, FileMode.Open)))
                {
                    // Leer los registros uno por uno hasta que no haya más
                    while (true)
                    {
                        Record r = brr.ReadRecord();
                        Console.WriteLine(r.Name + " " + r.Time);
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        public string getPin()
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(pinBIN, FileMode.Open)))
                {
                    return br.ReadString();
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message + " Nuevo archivo creado");
                using (BinaryWriter bw = new BinaryWriter(new FileStream(pinBIN, FileMode.CreateNew)))
                {
                    bw.Write("1234");
                }
                getPin();
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }

            return "-1";
        }
    }
}

