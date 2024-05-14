using System;

namespace LazySingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // добавляем сервера
            Console.WriteLine("Добавляю НЕверный сервер " + Servers.Instance.AddServer("ht://example.ru"));
            Console.WriteLine("Добавляю Верный 1 сервер http " + Servers.Instance.AddServer("http://example.ru"));
            Console.WriteLine("Добавляю Верный 2 сервер http " + Servers.Instance.AddServer("http://example2.ru"));
            Console.WriteLine("Добавляю Верный 1 сервер https " + Servers.Instance.AddServer("https://example.ru"));
            Console.WriteLine("Добавляю Верный 2 сервер https " + Servers.Instance.AddServer("https://example2.ru"));
            Console.WriteLine("Добавляю Верный 2 сервер https, но повторно " + Servers.Instance.AddServer("https://example2.ru"));

            // проверяем http
            Console.WriteLine("http сервера:");
            foreach (var server in Servers.Instance.GetHttpServers())
            {
                Console.WriteLine(server);
            }

            Console.WriteLine("----------------------------------");

            // проверяем  https
            Console.WriteLine("https сервера:");
            foreach (var server in Servers.Instance.GetHttpsServers())
            {
                Console.WriteLine(server);
            }

            Console.ReadLine();
        }
    }
}
