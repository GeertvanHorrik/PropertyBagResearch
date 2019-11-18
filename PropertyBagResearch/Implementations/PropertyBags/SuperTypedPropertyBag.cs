namespace PropertyBagResearch
{
    using System;
    using System.Collections.Generic;

    public class SuperTypedPropertyBag : IPropertyBag
    {
        private readonly IDictionary<string, int> _intValues;
        private readonly IDictionary<string, bool> _boolValues;
        private readonly IDictionary<string, short> _shortValues;
        private readonly IDictionary<string, long> _longValues;
        private readonly IDictionary<string, object> _referenceValues;

        public SuperTypedPropertyBag(IDictionaryFactory dictionaryFactory)
        {
            _intValues = dictionaryFactory.GenerateDictionary<int>();
            _boolValues = dictionaryFactory.GenerateDictionary<bool>();
            _shortValues = dictionaryFactory.GenerateDictionary<short>();
            _longValues = dictionaryFactory.GenerateDictionary<long>();
            _referenceValues = dictionaryFactory.GenerateDictionary<object>();
        }

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

            {
                var tr = __makeref(value);
                var bagValue = __refvalue(tr, object);
                _referenceValues[name] = bagValue;
            }
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

            {
                if (_referenceValues.TryGetValue(name, out var bagValue))
                {
                    var tr = __makeref(bagValue);
                    var value = __refvalue(tr, TValue);
                    return value;
                }

                return default;
            }
        }
    }
}
