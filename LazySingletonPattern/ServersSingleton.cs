using System;
using System.Collections.Generic;
using System.Linq;

namespace LazySingletonPattern
{
    public class Servers
    {
        private static readonly Lazy<Servers> _instance = new Lazy<Servers>(() => new Servers());
        private readonly List<string> _serversList = new List<string>();
        private static object syncRoot = new object();

        private Servers() {
            _serversList = new List<string>();
        }

        public static Servers Instance => _instance.Value;

        public bool AddServer(string server)
        {
            lock (syncRoot)
            {
                if (server == "" || !server.StartsWith("http") && !server.StartsWith("https"))
                {
                    Console.WriteLine("неверный формат");
                    return false;
                }
                    
                else
                {
                    if (_serversList.Contains(server))
                        return false;
                    else
                    {
                        _serversList.Add(server);
                        return true;
                    }
                }
            }
        }

        public IEnumerable<string> GetHttpServers()
        {
            lock (syncRoot)
                return _serversList.Where(server => server.StartsWith("http:"));
        }

        public IEnumerable<string> GetHttpsServers()
        {
           lock (syncRoot)
                return _serversList.Where(server => server.StartsWith("https:"));
        }
    }
}
