namespace BettingSystem.Infrastructure.Common.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Application.Common.Configuration;
    using Application.Common.Mapping;
    using AutoMapper;
    using Configuration;

    public class MappingProfile : Profile
    {
        public MappingProfile()
            => this.ApplyMappingsFromAssembly(
                typeof(ApplicationConfiguration).Assembly,
                typeof(InfrastructureConfiguration).Assembly);

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            const string mappingMethodName = "Mapping";

            var mapFromTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in mapFromTypes)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }

            var mapToTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              (i.IsPublic || i.IsNotPublic) &&
                              i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .ToList();

            foreach (var type in mapToTypes)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapTo`1")?.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
