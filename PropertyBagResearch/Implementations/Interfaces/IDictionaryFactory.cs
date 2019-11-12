namespace PropertyBagResearch
{
    using System.Collections.Generic;

    public interface IDictionaryFactory
    {
        public IDictionary<string, TValue> GenerateDictionary<TValue>();
    }
}
