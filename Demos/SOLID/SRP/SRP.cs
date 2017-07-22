using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    class SRP
    {
        static void Main(string[] args)
        {
            var service = new Service();
            string info = service.GetInfo(1);
        }
    }

    public class Service
    {
        public string GetInfo(int key)
        {
            File.AppendAllText("log.txt", "Get Info for " + key.ToString());
            var data = new DataBase();
            string result = data.GetForId(key);
            File.AppendAllText("log.txt", "Result: " + result);
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
}
