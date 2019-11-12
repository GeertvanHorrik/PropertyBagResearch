namespace PropertyBagResearch
{
    using System.Collections.Generic;

    public class SortedDictionaryFactory : IDictionaryFactory
    {
        public IDictionary<string, TValue> GenerateDictionary<TValue>()
        {
            return new SortedDictionary<string, TValue>();
        }
    }
}
