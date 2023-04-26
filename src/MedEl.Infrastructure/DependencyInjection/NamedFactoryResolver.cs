using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MedEl.Infrastructure
{
    public class NamedFactoryResolver<TFactory> : INamedFactoryResolver<TFactory>
    {
        private readonly IServiceProvider _provider;
 		private readonly ILogger<NamedFactoryResolver<TFactory>> _logger;
        private readonly NamedFactoryResolverConfiguration<TFactory> _configuration;

        public IEnumerable<string> Names => _configuration.Mappings.Keys;

        public NamedFactoryResolver(IServiceProvider provider, NamedFactoryResolverConfiguration<TFactory> configuration, ILogger<NamedFactoryResolver<TFactory>> logger)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TFactory GetFactory(string name)
        {
            _logger.LogDebug($"Get factory of type '{typeof(TFactory).FullName}' and with name '{name}'.");
            var factoryType = _configuration.Mappings[name];
            return (TFactory)_provider.GetService(factoryType);
        }
    }
}