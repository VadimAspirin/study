using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace SocketServer
{
    class Server
    {
		private Socket sListener;
		private List<KeyValuePair<Socket, string>> clientsMessages;
		private Thread receiveThread;
		private Socket handler;

		public Server(int port = 11000, int backlog = 10)
		{
			clientsMessages = new List<KeyValuePair<Socket, string>>();
			// Устанавливаем для сокета локальную конечную точку
			IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
			// Создаем сокет Tcp/Ip
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			// Назначаем сокет локальной конечной точке и слушаем входящие сокеты
			sListener.Bind(ipEndPoint);
			sListener.Listen(backlog);
			Console.WriteLine("Сервер запущен. Ожидание подключений...");
			// запускаем новый поток для получения данных
			receiveThread = new Thread(new ThreadStart(receiveMessage));
			receiveThread.Start(); //старт потока
		}

		private void receiveMessage()
        {
			while (true)
			{
				// Начинаем слушать соединения
				handler = sListener.Accept();
				//string data = null;
				// Мы дождались клиента, пытающегося с нами соединиться
				//byte[] bytes = new byte[1024];
				//int bytesRec = handler.Receive(bytes);
				//data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
				// Показываем данные на консоли
				//Console.Write("Полученный текст: " + data + "\n\n");
				//clientsMessages.Add (new KeyValuePair<Socket, string>(handler, data));

				Thread th = new Thread(new ThreadStart(XX));
				th.Start();
			}
        }

		private void XX()
		{
			string data = null;
			// Мы дождались клиента, пытающегося с нами соединиться
			byte[] bytes = new byte[1024];
			int bytesRec = handler.Receive(bytes);
			data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
			// Показываем данные на консоли
			Console.Write("Полученный текст: " + data + "\n\n");
			clientsMessages.Add (new KeyValuePair<Socket, string>(handler, data));
		}
		
		public string ShowMessage()
		{
			if (clientsMessages.Count == 0)
				return null;
			return clientsMessages[0].Value;
		}

		public void SendMessage()
        {
			if (clientsMessages.Count == 0)
				return;
			string reply = "Спасибо за запрос";
			byte[] msg = Encoding.UTF8.GetBytes(reply);
			clientsMessages[0].Key.Send(msg);
			clientsMessages.RemoveAt(0);
        }

        public void Disconnect()
        {
			foreach (KeyValuePair<Socket, string> keyValue in clientsMessages)
			{
				keyValue.Key.Shutdown(SocketShutdown.Both);
				keyValue.Key.Close();
			}
			receiveThread.Abort();
        }
    }
}
