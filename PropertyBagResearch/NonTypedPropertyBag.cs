using System.Collections.Generic;

namespace PropertyBagResearch
{
    public class NonTypedPropertyBag : IPropertyBag
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

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
