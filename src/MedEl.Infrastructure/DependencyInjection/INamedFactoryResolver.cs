using System.Collections.Generic;

namespace MedEl.Infrastructure
{
    public interface INamedFactoryResolver<TFactory>
    {
        IEnumerable<string> Names { get; }

        TFactory GetFactory(string name);
    }
}