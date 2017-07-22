using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class DI
    {
        static void Main(string[] args)
        {
            new Client().Work();

            
        }
    }

    public class DIService : IService
    {
        ILogger m_Logger;
        IDatabase m_Database;

        public DIService(ILogger logger, IDatabase database)
        {
            m_Logger = logger;
            m_Database = database;
        }

        public string GetInformation()
        {
            throw new NotImplementedException();
        }
    }

    public interface IDatabase
    {
        string GetData();
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public interface IService
    {
        string GetInformation();
    }

    public class Client
    {
        public void Work()
        {
            string info = new Service().GetInformation();
            Console.WriteLine(info);
        }
    }

    public class Service
    {
        //public Service(ILogger logger, IDatabase dataBase)
        //{

        //}
        public string GetInformation()
        {
            new ConsoleLogger().Log("Hole Info");
            return new Database().GetData();
        }
    }

    public class Database : IDatabase
    {
        List<string> m_Data = new List<string>();

        public string GetData()
        {
            int value = new Random().Next(100);
            new ConsoleLogger().Log("Gebe " + value.ToString() + " zurück");
            return string.Format("Data: {0}", value);
        }

        public void AddData(string data)
        {
            m_Data.Add(data);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
