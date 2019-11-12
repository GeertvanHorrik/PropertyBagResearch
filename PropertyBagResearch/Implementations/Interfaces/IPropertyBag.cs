namespace PropertyBagResearch
{
    public interface IPropertyBag
    {
        void SetValue<TValue>(string name, TValue value);
        TValue GetValue<TValue>(string name);
    }
}
