using lasReader.Catalog;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace lasReader
{
    public static class Factory
    {
        public static ISourceProvider[] SourceProvidersFactory { get; private set; } = GetSourceProviders();

        private static ISourceProvider[] GetSourceProviders()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            List<ISourceProvider> sourceProviderTypes = new List<ISourceProvider>();
            foreach (var type in types)
            {
                if (typeof(ISourceProvider).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    var instance = Activator.CreateInstance(type);
                    sourceProviderTypes.Add((ISourceProvider)instance);
                }
            }
            return sourceProviderTypes.ToArray();
        }
    }
}