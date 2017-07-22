using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfInterceptor
{
    public class ClientProxyInterceptor : IInterceptor
    {
        private readonly Func<ICommunicationObject> proxyCreator;
        private readonly Type typeToProxy;
        private ICommunicationObject proxyInstance;

        public ClientProxyInterceptor(Func<ICommunicationObject> proxyCreator, Type typeToProxy)
        {
            this.typeToProxy = typeToProxy;
            this.proxyCreator = proxyCreator;
        }

        public ICommunicationObject CachedProxy
        {
            get
            {
                this.EnsureProxyExists();
                return this.proxyInstance;
            }
            set
            {
                this.proxyInstance = value;
            }
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.ReturnValue = invocation.Method.Invoke(this.CachedProxy, invocation.Arguments);
            }
            catch (TargetInvocationException ex)
            {
                Exception innerException = ex.InnerException;

                throw innerException;
            }
            finally
            {
                this.CloseProxy(invocation.Method);
            }
        }

        private void EnsureProxyExists()
        {
            if (this.proxyInstance == null)
            {
                this.proxyInstance = this.proxyCreator();
            }
        }

        private void CloseProxy(MethodInfo methodInfo)
        {
            var wcfProxy = this.CachedProxy;

            if (wcfProxy != null && this.typeToProxy.IsAssignableFrom(methodInfo.DeclaringType))
            {
                if (wcfProxy.State == CommunicationState.Faulted)
                {
                    this.AbortCommunicationObject(wcfProxy);
                }
                else if (wcfProxy.State != CommunicationState.Closed)
                {
                    try
                    {
                        wcfProxy.Close();

                        this.CachedProxy = null;
                    }
                    catch (CommunicationException)
                    {
                        this.AbortCommunicationObject(wcfProxy);
                    }
                    catch (TimeoutException)
                    {
                        this.AbortCommunicationObject(wcfProxy);
                    }
                    catch (Exception)
                    {
                        this.AbortCommunicationObject(wcfProxy);
                        throw;
                    }
                }
            }
        }

        private void AbortCommunicationObject(ICommunicationObject wcfProxy)
        {
            wcfProxy.Abort();

            this.CachedProxy = null;
        }
    }
}
