using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;

namespace UniversityProject.server
{
    class Client
    {
        static string userName;
        static TcpClient client;
        static NetworkStream stream;

        public static void Connect(string name, string ip, int port)
        {
            userName = name;
            client = new TcpClient();
            try
            {
                client.Connect(ip, port); //подключение клиента
                stream = client.GetStream(); // получаем поток

                string message = userName;
                //byte[] data = Encoding.Unicode.GetBytes(message);
                //stream.Write(data, 0, data.Length);

                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потокаd
                SendMessage(userName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        // отправка сообщений
        static void SendMessage(string mes)
        {
            string message = mes;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Disconnect();
                    Environment.Exit(0);
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
        }
    }
}