using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
    {
        Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
        if (serviceAssembly == null)
        {
            throw new InvalidOperationException("Invalid service type provided!");
        }

        Type[] sType = serviceAssembly
            .GetTypes()
            .Where(st => st.Name.EndsWith("Service") && !st.IsInterface)
            .ToArray();

        foreach (Type st in sType)
        {
            var interfaceType = st
                .GetInterface($"I{st.Name}");

            if (interfaceType == null)
            {
                throw new InvalidOperationException($"No interface is provided for the service with name {st.Name}");
            }

            if (interfaceType.Name == "IEmailSender")
            {
                services.AddTransient(interfaceType, st);
                continue;
            }

            services.AddScoped(interfaceType, st);
        }
    }
}