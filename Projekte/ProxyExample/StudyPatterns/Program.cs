using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace StudyPatterns
{
    public class StopwatchInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stop = Stopwatch.StartNew();
            invocation.Proceed();
            Console.WriteLine(stop.Elapsed);
        }
    }

    public class CatchInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                Console.WriteLine("Succeeded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e); ;
            }
        }
    }

    public class ProxyClassClient
    {
        static void Main()
        {
            RealClass rc;
            //if (settings.UseProxy)
            rc = new ProxyGenerator().CreateClassProxy(typeof(RealClass), new StopwatchInterceptor()) as RealClass;
            //else
            //rc = new RealClass();
            rc.Operation();

            IContract ic = new ProxyGenerator().CreateInterfaceProxyWithTargetInterface<IContract>(new RealClass(), new CatchInterceptor(), new StopwatchInterceptor());
            ic.Operation();

            IContract ProxyClass = new ProxyClass(new RealClass());
            ProxyClass.Operation();
        }
    }

    // Could be a base class with virtual methods too
    public interface IContract
    {
        void Operation();
    }

    public class ProxyClass : IContract
    {
        IContract m_RealClass;

        public ProxyClass(IContract forRealClass)
        {
            m_RealClass = forRealClass;
        }

        public void Operation()
        {
            m_RealClass.Operation();
        }
    }

    public class RealClass : IContract
    {
        public void Operation()
        {
        }
    }

}
