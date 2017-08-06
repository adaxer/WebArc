using FullNetLibrary;
using PortableLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new WelcomeService().Hello();
            string isPortable = new PortableService().Portable();
        }
    }

}
