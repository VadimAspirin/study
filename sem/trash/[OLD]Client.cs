using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Client
{

	public class AsyncClient 
	{
		private class StateObject 
		{
			public Socket WorkSocket = null; // Клиентский сокет.
			public const int BufferSize = 256; // Размер буфера приема.
			public byte[] Buffer = new byte[BufferSize]; // Получить буфер.
			public StringBuilder StringBuffer = new StringBuilder(); // Получена строка данных.
		}
		
		private string host; // Адрес сервера
		private int port; // Порт сервера
		private ManualResetEvent connectDone;
		private ManualResetEvent sendDone;
		private ManualResetEvent receiveDone;
		private String response; // Ответ с удаленного устройства.
		
		public AsyncClient(string host = "localhost", int port = 11000)
		{
			this.host = host;
			this.port = port;
			connectDone = new ManualResetEvent(false);
			sendDone = new ManualResetEvent(false);
			receiveDone = new ManualResetEvent(false);
			response = String.Empty;
		}

		public string sendMessage(String data) 
		{
			try 
			{
	            //IPHostEntry ipHostInfo = Dns.GetHostEntry("host.contoso.com");
				IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
				// Создаем сокет TCP/IP.
				Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				// Подключение к удаленной конечной точке.
				client.BeginConnect(remoteEP, new AsyncCallback(connectCallback), client);
				connectDone.WaitOne();
				
				send(client, data);
				sendDone.WaitOne();
				
				// Получать ответ с удаленного устройства.
				receive(client);
				receiveDone.WaitOne();
				// Записываем ответ на консоль.
				//Console.WriteLine("Сервер: {0}", response);
				
				client.Shutdown(SocketShutdown.Both);
				client.Close();
				
				return response;
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}

		private void connectCallback(IAsyncResult ar) 
		{
			try 
			{
				// Извлеките сокет из объекта состояния.
				Socket client = (Socket) ar.AsyncState;
				// Завершите соединение.
				client.EndConnect(ar);
				Console.WriteLine("Подключились к {0}", client.RemoteEndPoint.ToString());
				// Сигнал о том, что соединение выполнено.
				connectDone.Set();
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void receive(Socket client) 
		{
			try 
			{
				// Создаем объект состояния.
				StateObject state = new StateObject();
				state.WorkSocket = client;
				// Начнем получать данные с удаленного устройства.
				client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(receiveCallback), state);
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void receiveCallback(IAsyncResult ar)
		{
			try 
			{
				// Получить объект состояния и клиентский сокет из асинхронного объекта состояния.
				StateObject state = (StateObject) ar.AsyncState;
				Socket client = state.WorkSocket;
				// Чтение данных с удаленного устройства.
				int bytesRead = client.EndReceive(ar);
				
				Console.WriteLine("[bytesRead: {0}]", bytesRead);
				if (bytesRead > 0) 
				{
					// Может быть больше данных, поэтому храните данные, полученные до сих пор.
					state.StringBuffer.Append(Encoding.Unicode.GetString(state.Buffer, 0, bytesRead));
				    // Получить остальные данные.
					client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(receiveCallback), state);
				} 
				else 
				{
					response = state.StringBuffer.ToString();
					// Сигнал о том, что все байты были получены.
					receiveDone.Set();
				}
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void send(Socket client, String data) 
		{
			// Преобразуем строковые данные в байтовые данные, используя Unicode-кодировку.
			byte[] byteData = Encoding.Unicode.GetBytes(data+"<EOF>");
			// Начните отправку данных на удаленное устройство.
			client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(sendCallback), client);
		}

		private void sendCallback(IAsyncResult ar) 
		{
			try 
			{
				// Начнем отправку данных на удаленное устройство.
				Socket client = (Socket) ar.AsyncState;
				// Завершить отправку данных на удаленное устройство.
				int bytesSent = client.EndSend(ar);
				Console.WriteLine("Отправлено {0} байт на сервер.", bytesSent);
				// Сигнал о том, что все байты были отправлены.
				sendDone.Set();
			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}
	}

}
