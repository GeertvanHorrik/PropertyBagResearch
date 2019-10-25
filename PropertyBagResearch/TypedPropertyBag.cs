using System;
using System.Collections.Generic;

namespace PropertyBagResearch
{
    public class TypedPropertyBag : IPropertyBag
    {
        private readonly Dictionary<string, int> _intValues = new Dictionary<string, int>();
        private readonly Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
        private readonly Dictionary<string, short> _shortValues = new Dictionary<string, short>();
        private readonly Dictionary<string, long> _longValues = new Dictionary<string, long>();
        private readonly Dictionary<string, object> _referenceValues = new Dictionary<string, object>();

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
