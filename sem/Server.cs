using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// Объект State для чтения данных клиента асинхронно
public class StateObject {
    // Клиентский сокет.
    public Socket workSocket = null;
    // Размер буфера приема.
    public const int BufferSize = 1024;
    // Получить буфер.
    public byte[] buffer = new byte[BufferSize];
	// Получена строка данных.
    public StringBuilder sb = new StringBuilder();  
}

public class AsynchronousSocketListener {
    // Сигнал потока.
    public static ManualResetEvent allDone = new ManualResetEvent(false);

    public AsynchronousSocketListener() {
    }

    public static void StartListening() {
        // Буфер данных для входящих данных.
        byte[] bytes = new Byte[1024];

        // Установите локальную конечную точку для сокета.
        // DNS-имя компьютера, на котором запущен слушатель, - «host.contoso.com».
        //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
		IPHostEntry ipHostInfo = Dns.Resolve("localhost");
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        // Создаем сокет TCP/IP.
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp );

        // Связывание сокета с локальной конечной точкой и прослушивание входящих соединений.
        try {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true) {
                 // Устанавливаем событие в несогласованное состояние.
                allDone.Reset();

                // Запустите асинхронный сокет для прослушивания соединений.
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept( 
                    new AsyncCallback(AcceptCallback),
                    listener );

                // Подождите, пока соединение не будет выполнено до продолжения.
                allDone.WaitOne();
            }

        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }

    public static void AcceptCallback(IAsyncResult ar) {
        // Сигнал основного потока для продолжения.
        allDone.Set();

        // Получает сокет, обрабатывающий клиентский запрос.
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        // Создаем объект состояния.
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
    }

    public static void ReadCallback(IAsyncResult ar) {
        String content = String.Empty;

        // Получить объект состояния и сокет обработчика
        // из асинхронного объекта состояния.
        StateObject state = (StateObject) ar.AsyncState;
        Socket handler = state.workSocket;

        // Чтение данных из клиентского сокета. 
        int bytesRead = handler.EndReceive(ar);

        if (bytesRead > 0) {
            // Может быть больше данных, поэтому храните данные, полученные до сих пор.
            state.sb.Append(Encoding.ASCII.GetString(
                state.buffer,0,bytesRead));

            // Проверяем тег конца файла. Если его нет, прочитайте больше данных.
            content = state.sb.ToString();
            if (content.IndexOf("<EOF>") > -1) {
                // Все данные были прочитаны от клиента. Отобразите его на консоли.
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                    content.Length, content );
                // Повторить данные обратно клиенту.
                Send(handler, content);
            } else {
                // Не все полученные данные. Получите больше.
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            }
        }
    }

    private static void Send(Socket handler, String data) {
        // Преобразуем строковые данные в байтовые данные, используя ASCII-кодировку.
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Начнем отправку данных на удаленное устройство.
        handler.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), handler);
    }

    private static void SendCallback(IAsyncResult ar) {
        try {
            // Извлеките сокет из объекта состояния.
            Socket handler = (Socket) ar.AsyncState;

            // Завершение отправки данных на удаленное устройство.
            int bytesSent = handler.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to client.", bytesSent);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }


    public static int Main(String[] args) {
        StartListening();
        return 0;
    }
}
