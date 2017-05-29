using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
			AsyncSocketListener server = new AsyncSocketListener();

			while (true)
			{
				string inMess = server.ShowMessage();
				if (inMess == null)
					continue;
				Console.WriteLine("Сообщение клиента: {0}", inMess);
				Console.Write("Ваш ответ: ");
				string outMess = Console.ReadLine();
				server.SendMessage(outMess);
			}

        }
    }
}
