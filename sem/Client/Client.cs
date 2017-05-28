using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketClient
{
    class Client
    {
		private Socket handler;
		private Thread receiveThread;

		public Client(string host = "localhost", int port = 11000)
		{
			// Устанавливаем удаленную точку для сокета
			IPHostEntry ipHost = Dns.GetHostEntry(host);
			IPAddress ipAddr = ipHost.AddressList[0];
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
			handler = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			// Соединяем сокет с удаленной точкой
			handler.Connect(ipEndPoint);
			// запускаем новый поток для получения данных
			receiveThread = new Thread(new ThreadStart(receiveMessage));
			receiveThread.Start(); //старт потока
		}

		private void receiveMessage()
		{
			while (true)
			{
				// Буфер для входящих данных
				byte[] bytes = new byte[1024];
				// Получаем ответ от сервера
				int bytesRec = handler.Receive(bytes);
				Console.WriteLine("Ответ от сервера: {0}\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
			}
		}

		public void SendMessage()
		{
			while (true)
			{
				Console.Write("Введите сообщение: ");
				string message = Console.ReadLine();
				Console.WriteLine("Сокет соединяется с {0} ", handler.RemoteEndPoint.ToString());
				byte[] msg = Encoding.UTF8.GetBytes(message);
				// Отправляем данные через сокет
				handler.Send(msg);
			}
		}

		public void Disconnect()
		{
			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
			receiveThread.Abort();
        }
    }
}
