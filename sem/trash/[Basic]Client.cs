using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

// Объект State для приема данных с удаленного устройства.
public class StateObject {
    // Клиентский сокет.
    public Socket workSocket = null;
    // Размер буфера приема.
    public const int BufferSize = 256;
    // Получить буфер.
    public byte[] buffer = new byte[BufferSize];
    // Получена строка данных.
    public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient {
    // Номер порта для удаленного устройства.
    private const int port = 11000;

    // экземпляры ManualResetEvent сигналы завершения.
    private static ManualResetEvent connectDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone = 
        new ManualResetEvent(false);

    // Ответ с удаленного устройства.
    private static String response = String.Empty;

    private static void StartClient() {
        // Подключение к удаленному устройству.
        try {
            // Установите удаленную конечную точку для сокета.
            // Имя удаленного устройства - «host.contoso.com».
            //IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
			IPHostEntry ipHostInfo = Dns.Resolve("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Создаем сокет TCP/IP.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Подключение к удаленной конечной точке.
            client.BeginConnect( remoteEP, 
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();

            // Отправлять тестовые данные на удаленное устройство.
            Send(client,"This is a test<EOF>");
            sendDone.WaitOne();

            // Получать ответ с удаленного устройства.
            Receive(client);
            receiveDone.WaitOne();

            // Записываем ответ на консоль.
            Console.WriteLine("Response received : {0}", response);

            // Отпустите сокет.
            client.Shutdown(SocketShutdown.Both);
            client.Close();

        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ConnectCallback(IAsyncResult ar) {
        try {
            // Извлеките сокет из объекта состояния.
            Socket client = (Socket) ar.AsyncState;

            // Завершите соединение.
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Сигнал о том, что соединение выполнено.
            connectDone.Set();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Receive(Socket client) {
        try {
            // Создаем объект состояния.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Начнем получать данные с удаленного устройства.
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ReceiveCallback( IAsyncResult ar ) {
        try {
            // Получить объект состояния и клиентский сокет
            // из асинхронного объекта состояния.
            StateObject state = (StateObject) ar.AsyncState;
            Socket client = state.workSocket;

            // Чтение данных с удаленного устройства.
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0) {
                // Может быть больше данных, поэтому храните данные, полученные до сих пор.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));

                // Получить остальные данные.
                client.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
                    new AsyncCallback(ReceiveCallback), state);
            } else {
                // Все данные прибыли; Ответьте.
                if (state.sb.Length > 1) {
                    response = state.sb.ToString();
                }
                // Сигнал о том, что все байты были получены.
                receiveDone.Set();
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Send(Socket client, String data) {
        // Преобразуем строковые данные в байтовые данные, используя ASCII-кодировку.
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    private static void SendCallback(IAsyncResult ar) {
        try {
            // Начнем отправку данных на удаленное устройство.
            Socket client = (Socket) ar.AsyncState;

            // Завершить отправку данных на удаленное устройство.
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Сигнал о том, что все байты были отправлены.
            sendDone.Set();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    public static int Main(String[] args) {
        StartClient();
        return 0;
    }
}
