using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace JsonDeserialization5.Models
{
    public class KnownTypesBinder : ISerializationBinder
    {
        public List<string> GetAllTypeNames()
        {
            var expectedTypes = new List<string>();

            var expectedAssemblies = new List<Assembly>();
            var assembly = Assembly.Load("JsonDeserialization5");
            expectedAssemblies.Add(assembly);

            foreach (var assembly1 in expectedAssemblies)
            {
                foreach (var type in assembly1.GetTypes())
                {
                    expectedTypes.Add(type.FullName);
                }
            }

            return expectedTypes;
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = serializedType.AssemblyQualifiedName;
            typeName = serializedType.FullName;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            var expectedTypeNames = GetAllTypeNames();

            if (!expectedTypeNames.Contains(typeName))
            {
                //throw new Exception("invalid type");
                return null;
            }

            var type = Type.GetType(typeName);

            return type;
        }
    }
}