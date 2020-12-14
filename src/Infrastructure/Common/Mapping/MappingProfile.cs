namespace BettingSystem.Infrastructure.Common.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Application;
    using Application.Common.Mapping;
    using AutoMapper;
    using AutoMapper.Internal;

    public class MappingProfile : Profile
    {
        public MappingProfile()
            => this.ApplyMappingsFromAssembly(
                typeof(ApplicationConfiguration).Assembly,
                typeof(InfrastructureConfiguration).Assembly);

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            var types =assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(i =>
                        i.IsGenericType &&
                        (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) ||
                         i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                const string mappingMethodName = "Mapping";

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo is null)
                {
                    type
                        .GetInterfaces()
                        .ForAll(i => i
                            ?.GetMethod(mappingMethodName)
                            ?.Invoke(instance, new object[] { this }));
                }
                else
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
            }
        }
    }
}
