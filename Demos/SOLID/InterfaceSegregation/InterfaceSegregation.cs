using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    class InterfaceSegregation
    {
        static void Main(string[] args)
        {
            IService s1 = new LoggingService { LogFile = "firstlog.txt" };
            var result = s1.GetInfo(1);

            IService s2 = new NonLoggingService();
            result = s2.GetInfo(2);
        }
    }

    public class LoggingService : IService
    {
        public string LogFile { get; set; }

        public LoggingService()
        {
            LogFile = "log.txt";
        }

        public string GetInfo(int key)
        {
            File.AppendAllText(LogFile, "Get Info for " + key.ToString());
            var data = new DataBase();
            string result = data.GetForId(key);
            File.AppendAllText(LogFile, "Result: " + result);
            return result;
        }
    }

    public class DataBase
    {
        public string GetForId(int key)
        {
            return string.Format("Info for {0} = {1}", key, new Random().Next(0, 100));
        }
    }

    public interface IService
    {
        string GetInfo(int key);
        string LogFile { get; set; }
    }

    public class NonLoggingService : IService
    {
        public string GetInfo(int key)
        {
            return key.ToString();
        }

        public string LogFile
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
