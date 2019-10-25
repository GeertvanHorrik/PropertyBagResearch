using System;
using System.Collections.Generic;

namespace PropertyBagResearch
{
    public class SuperTypedPropertyBag : IPropertyBag
    {
        private readonly Dictionary<string, int> _intValues = new Dictionary<string, int>();
        private readonly Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
        private readonly Dictionary<string, short> _shortValues = new Dictionary<string, short>();
        private readonly Dictionary<string, long> _longValues = new Dictionary<string, long>();
        private readonly Dictionary<string, object> _referenceValues = new Dictionary<string, object>();

        public void SetValue<TValue>(string name, TValue value)
        {
            var targetValue = typeof(TValue);
            if (targetValue == typeof(bool))
            {
                var tr = __makeref(value);
                var bagValue = __refvalue(tr, bool);

                _boolValues[name] = bagValue;
                return;
            }
            else if (targetValue == typeof(int))
            {
                var tr = __makeref(value);
                var bagValue = __refvalue(tr, int);

                _intValues[name] = bagValue;
                return;
            }

            throw new NotSupportedException();
        }

        public TValue GetValue<TValue>(string name)
        {
            var targetValue = typeof(TValue);
            if (targetValue == typeof(bool))
            {
                if (_boolValues.TryGetValue(name, out var bagValue))
                {
                    var tr = __makeref(bagValue);
                    var value = __refvalue(tr, TValue);
                    return value;
                }

                return default;
            }
            else if (targetValue == typeof(int))
            {
                if (_intValues.TryGetValue(name, out var bagValue))
                {
                    var tr = __makeref(bagValue);
                    var value = __refvalue(tr, TValue);
                    return value;
                }

                return default;
            }

            throw new NotSupportedException();
        }
    }
}
