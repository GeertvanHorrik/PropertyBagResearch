namespace PropertyBagResearch
{
    using System;
    using System.Collections.Generic;

    public class TypedPropertyBag : IPropertyBag
    {
        private readonly IDictionary<string, int> _intValues;
        private readonly IDictionary<string, bool> _boolValues;
        private readonly IDictionary<string, short> _shortValues;
        private readonly IDictionary<string, long> _longValues;
        private readonly IDictionary<string, object> _referenceValues;

        private static readonly Dictionary<Type, object> _setters = new Dictionary<Type, object>();
        private static readonly Dictionary<Type, object> _getters = new Dictionary<Type, object>();

        static TypedPropertyBag()
        {
            _setters[typeof(int)] = (Action<TypedPropertyBag, string, int>)SetIntValue;
            _setters[typeof(bool)] = (Action<TypedPropertyBag, string, bool>)SetBoolValue;
            _setters[typeof(short)] = (Action<TypedPropertyBag, string, short>)SetShortValue;
            _setters[typeof(long)] = (Action<TypedPropertyBag, string, long>)SetLongValue;

            _getters[typeof(int)] = (Func<TypedPropertyBag, string, int>)GetIntValue;
            _getters[typeof(bool)] = (Func<TypedPropertyBag, string, bool>)GetBoolValue;
            _getters[typeof(short)] = (Func<TypedPropertyBag, string, short>)GetShortValue;
            _getters[typeof(long)] = (Func<TypedPropertyBag, string, long>)GetLongValue;
        }

        public TypedPropertyBag(IDictionaryFactory dictionaryFactory)
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

            if (_setters.TryGetValue(targetValue, out var setterObj))
            {
                var setter = (Action<TypedPropertyBag, string, TValue>)setterObj;
                if (!(setter is null))
                {
                    setter(this, name, value);
                    return;
                }
            }

            // Old-fashioned, potentially boxing, method
            _referenceValues[name] = value;
        }

        private static void SetIntValue(TypedPropertyBag instance, string name, int value)
        {
            instance._intValues[name] = value;
        }

        private static void SetBoolValue(TypedPropertyBag instance, string name, bool value)
        {
            instance._boolValues[name] = value;
        }

        private static void SetShortValue(TypedPropertyBag instance, string name, short value)
        {
            instance._shortValues[name] = value;
        }

        private static void SetLongValue(TypedPropertyBag instance, string name, long value)
        {
            instance._longValues[name] = value;
        }

        public TValue GetValue<TValue>(string name)
        {
            var targetValue = typeof(TValue);

            if (_getters.TryGetValue(targetValue, out var retrievalFuncObj))
            {
                var retrievalFunc = (Func<TypedPropertyBag, string, TValue>)retrievalFuncObj;
                return retrievalFunc(this, name);
            }

            throw new NotSupportedException();
        }

        private static int GetIntValue(TypedPropertyBag instance, string name)
        {
            return instance._intValues[name];
        }

        private static bool GetBoolValue(TypedPropertyBag instance, string name)
        {
            return instance._boolValues[name];
        }

        private static short GetShortValue(TypedPropertyBag instance, string name)
        {
            return instance._shortValues[name];
        }

        private static long GetLongValue(TypedPropertyBag instance, string name)
        {
            return instance._longValues[name];
        }
    }
}
