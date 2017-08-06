using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new Service();
            svc = new ProxyGenerator().CreateClassProxyWithTarget<Service>(svc, new LogParametersInterceptor());
            string result = svc.Answer(42);
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
    public class LogParametersInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            foreach (var item in invocation.Arguments)
            {
                Console.WriteLine(string.Format("Argument: {0}, Wert: {1}", item.GetType().FullName, item.ToString()));
            }
            invocation.Proceed();
            Console.WriteLine($"Result: {invocation.ReturnValue.GetType().FullName}, Wert: {invocation.ReturnValue.ToString()}");
        }
    }

    public class Service
    {
        public virtual string Answer(int number)
        {
            return number.ToString();
        }
    }
}
