namespace CustomIoC.IoC;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SimpleIoCContainer
{
    private readonly Dictionary<Type, Type> _transientServices = new Dictionary<Type, Type>();
    private readonly Dictionary<Type, object> _singletonServices = new Dictionary<Type, object>();

    // Register a transient service
    public void Register<TService, TImplementation>()
        where TImplementation : TService
    {
        _transientServices[typeof(TService)] = typeof(TImplementation);
    }

    // Register a service with an existing instance (singleton)
    public void RegisterSingleton<TService>(TService instance)
    {
        _singletonServices[typeof(TService)] = instance;
    }

    // Register a singleton service with a type
    public void RegisterSingleton<TService, TImplementation>()
        where TImplementation : TService, new()
    {
        var instance = new TImplementation();
        _singletonServices[typeof(TService)] = instance;
    }

    // Register a service for resolution
    public void Register<TService>()
    {
        Register<TService, TService>(); // Assume TService itself is the implementation
    }

    // Resolve a service by type
    public TService Resolve<TService>()
    {
        return (TService)Resolve(typeof(TService));
    }

    // Resolve a service by type
    private object Resolve(Type serviceType)
    {
        // Check for singleton services first
        if (_singletonServices.TryGetValue(serviceType, out var singleton))
        {
            return singleton;
        }

        // Resolve transient services
        if (_transientServices.TryGetValue(serviceType, out var implementationType))
        {
            var constructor = implementationType.GetConstructors().First();
            var parameters = constructor.GetParameters();
            var parameterInstances = parameters.Select(p => Resolve(p.ParameterType)).ToArray();
            var instance = constructor.Invoke(parameterInstances);
            return instance;
        }

        throw new InvalidOperationException($"Service of type {serviceType.FullName} is not registered.");
    }
}
