namespace PropertyBagResearch
{
    using System.Collections.Generic;

    public class DictionaryFactory : IDictionaryFactory
    {
        public IDictionary<string, TValue> GenerateDictionary<TValue>()
        {
            return new Dictionary<string, TValue>();
        }
    }
}
