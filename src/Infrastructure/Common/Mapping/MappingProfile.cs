namespace BettingSystem.Infrastructure.Common.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Application;
    using Application.Common.Mapping;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
            => this.ApplyMappingsFromAssembly(
                typeof(ApplicationConfiguration).Assembly,
                typeof(InfrastructureConfiguration).Assembly);

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            var types = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                const string mappingMethodName = "Mapping";

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
