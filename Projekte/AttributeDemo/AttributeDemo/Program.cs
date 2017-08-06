using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [Author("You")]
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var type = typeof(Program);
            var method = type.GetMethod("Main", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var atts = method.GetCustomAttributes(true);
        }
    }

    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    [Author("Me")]
    sealed class AuthorAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string name;

        // This is a positional argument
        public AuthorAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
