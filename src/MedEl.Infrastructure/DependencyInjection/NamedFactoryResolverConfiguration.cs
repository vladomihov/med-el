using System;
using System.Collections.Generic;

namespace MedEl.Infrastructure
{
    public record class NamedFactoryResolverConfiguration<TFactory>(IDictionary<string, Type> Mappings);
}