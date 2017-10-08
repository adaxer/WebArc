using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> ii = new List<int> { 1 };

            foreach (var item in ii)
            {

            }

            foreach (var city in Cities.Items())
            {
                Console.WriteLine(city);
            }

            var enumerator = ii.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var item = enumerator.Current;
            }
        }

        public class Cities
        {
            public static IEnumerable<string> Items()
            {
                yield return "München";
                yield return "Stuttgart";
                if (DateTime.Now.Second % 2 == 0)
                    yield return "London";
                else
                    yield break;
            }
        }
    }
}
