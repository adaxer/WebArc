using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var max = new Person { FirstName = "Max", LastName = "Müller" };
            string maxname = PersonExtensions.GetFullName(max);
            maxname = max.GetFullName();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public string FullName => FirstName +" "+ LastName;
    }

    public static class PersonExtensions
    {
        public static string GetFullName(this Person p)
        {
            return p.FirstName + " " + p.LastName;
        }
    }
}