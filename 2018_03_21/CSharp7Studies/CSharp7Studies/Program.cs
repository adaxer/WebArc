using System;
using System.IO;

namespace CSharp7Studies
{
    class Program
    {
        private int myVar = 1;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int Id { get; set; } = 1;

        public int Id2 = 1;

        public string Name { get; } = "Program";

        public double PI => 3.14159;

        public double W2
        {
            get
            {
                return 1.41;
            }
        }

        // Ab hier ist C# 7
        private (int id, bool isOk) GetIntBool(bool isAlsoOk)
        {
            return (1, true);
        }

        private void Something()
        {
            bool func()
            {
                return true;
            }

            for (int i = 0; i < 10; i++)
            {
                bool isTrue = func();
            }
        }

        void Inlinecast(object x)
        {
            if (x is Stream)
            {
                var s = x as Stream;
            }

            Stream s3 = x as Stream;
            if (s3 != null)
            {

            }

            if (x is Stream s2)
            {
                s2.Close();
            }
        }

        // Ende C#7

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
