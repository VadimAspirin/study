using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
			while (true)
			{
				Console.Write("Ваш запрос: ");
				string message = Console.ReadLine();
				if (message == "<exit>")
					break;
				Console.WriteLine("Сервер: {0}", AsyncClient.sendMessage(message));
			}
        }
    }
}


