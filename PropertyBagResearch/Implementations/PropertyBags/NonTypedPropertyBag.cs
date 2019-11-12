namespace PropertyBagResearch
{
    using System.Collections.Generic;

    public class NonTypedPropertyBag : IPropertyBag
    {
        private readonly IDictionary<string, object> _values;

        public NonTypedPropertyBag(IDictionaryFactory dictionaryFactory)
        {
            _values = dictionaryFactory.GenerateDictionary<object>();
        }

        public void SetValue<TValue>(string name, TValue value)
        {
            _values[name] = value;
        }

        public TValue GetValue<TValue>(string name)
        {
            return (TValue)_values[name];
        }
    }
}
