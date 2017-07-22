using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfInterceptor
{
    class Program
    {
        const string baseAddress = "net.pipe://localhost/pi";
        static Binding WcfBinding { get { return new NetNamedPipeBinding(); } }

        static void Main(string[] args)
        {
            StartServer();

            ICalcPi calc = new CalcPi();
            Console.WriteLine(calc.GetPi(10));

            calc = GetCalcProxy(); // GetService<ICalcPi>();
            Console.WriteLine(calc.GetPi(5));

            calc = GetInterceptorProxy();
            Console.WriteLine(calc.GetPi(-5));

            Console.ReadLine();
        }

        private static ICalcPi GetInterceptorProxy()
        {
            var interceptor = new ClientProxyInterceptor(()=> GetCalcProxy() as ICommunicationObject, 
                typeof(ICalcPi));
            ICalcPi result = new ProxyGenerator()
                .CreateInterfaceProxyWithoutTarget<ICalcPi>(interceptor);
            return result;
        }

        private static ICalcPi GetCalcProxy()
        {
            ICalcPi channel = ChannelFactory<ICalcPi>.CreateChannel(
                WcfBinding, 
                new EndpointAddress(baseAddress));
            return channel;
        }

        private static void StartServer()
        {
            var host=new ServiceHost(typeof(CalcPi), new Uri(baseAddress));
            host.Description
                .Behaviors
                .OfType<ServiceDebugBehavior>()
                .Single()
                .IncludeExceptionDetailInFaults = true;
            host.Open();
        }
    }

    [ServiceContract]
    public interface ICalcPi
    {
        [OperationContract]
        double GetPi(int digits);
    }

    public class CalcPi : ICalcPi
    {
        public double GetPi(int digits)
        {
            Console.WriteLine("GetPi: {0} digits, Context: {1}", digits, ContextInfo());
            Thread.Sleep(digits * 200);
            var pi = Math.PI.ToString();
            return double.Parse(pi.Substring(0, digits + 2));
        }

        private string ContextInfo()
        {
            if (OperationContext.Current == null)
                return "no wcf";
            return "wcf from " + OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
        }
    }

}
