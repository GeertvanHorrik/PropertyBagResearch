namespace PropertyBagResearch
{
    using System.Collections.Generic;

    public interface IDictionaryFactory
    {
        IDictionary<string, TValue> GenerateDictionary<TValue>();
    }
}
