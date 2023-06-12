using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Trashtalk.Application.Common.Mappings
{
    public class AssemblyMapingProfile : Profile
    {
        public AssemblyMapingProfile(Assembly assembly)
        {
            ApplyMappingsAssembly(assembly);
        }

        private void ApplyMappingsAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type=>type.GetInterfaces()
                    .Any(i=>i.IsGenericType &&
                    i.GetGenericTypeDefinition()==typeof(IMapWith<>)))
                .ToList();

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping");
                method?.Invoke(instance, new object[] { this });
            }
        }
    }
}
