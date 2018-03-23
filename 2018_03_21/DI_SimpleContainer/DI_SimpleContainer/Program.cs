using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;

namespace DI_SimpleContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bootstrapper
            // Composition-Root
            //var container = new UnityContainer();
            var container = new SimpleContainer();
            container.RegisterType<NavApp>(); // In Unity nicht nötig, in anderen DC ev. schon
            container.RegisterType<IPositionService, AndroidGpsModule>();
            container.RegisterType<IPrecisionService, AndroidSystemPrecision>();

            NavApp app = container.Resolve<NavApp>();
            //var app = new NavApp(new AndroidGpsModule(new AndroidSystemPrecision()));
            app.Run();
        }
    }

    public class AndroidGpsModule : IPositionService
    {
        public AndroidGpsModule(IPrecisionService precisionService)
        {
            Precision = precisionService.SystemPrecision;
        }

        public (double Longitude, double Latitude) GetPosition()
        {
            return (9.0, 48.0);
        }

        public double Precision { get; }
    }

    public class AndroidSystemPrecision : IPrecisionService
    {
        public double SystemPrecision => 5.0;
    }

    // --------------------------------------------

    public class SimpleContainer
    {
        private Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type t)
        {
            if(!_registrations.ContainsKey(t))
            {
                throw new ArgumentException("Type not registered");
            }

            Type resultType = _registrations[t];
            ConstructorInfo ctor = resultType
                .GetConstructors()
                .OrderBy((ConstructorInfo ci) => ci.GetParameters().Count())
                .FirstOrDefault();

            if (ctor == null)
            {
                throw new ArgumentException("Type has not public constuctors");
            }

            var parameters = new List<object>();
            foreach (var pi in ctor.GetParameters())
            {
                parameters.Add(Resolve(pi.ParameterType));
            }

            var result = ctor.Invoke(parameters.ToArray());
            return result;
        }

        public void RegisterType<T>()
        {
            RegisterType<T, T>();
        }

        public void RegisterType<I, T>()
        {
            Type t = typeof(T);
            Type i = typeof(I);

            // Falls T abstrakt => Exception!
            if (t.IsAbstract)
            {
                throw new ArgumentException("Type can't be abstract (must be creatable)");
            }
            _registrations[i] = t;
        }
    }

    public class NavApp
    {
        public NavApp(IPositionService service)
        {
            PositionService = service;
        }

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        private IPositionService PositionService { get; }

        public void Run()
        {
            // var gps = new AndroidGpsModule();
            var pos = PositionService.GetPosition();
            Longitude = pos.Longitude;
            Latitude = pos.Latitude;
        }
    }

    public interface IPositionService
    {
        (double Longitude, double Latitude) GetPosition();
        double Precision { get; }
    }

    public interface IPrecisionService
    {
        double SystemPrecision { get; }
    }
}
