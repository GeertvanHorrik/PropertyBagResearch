namespace PropertyBagResearch
{
    public class TestType
    {
        private readonly IPropertyBag _propertyBag;

        public TestType(IPropertyBag propertyBag)
        {
            _propertyBag = propertyBag;
        }

        public int IntValue
        {
            get { return _propertyBag.GetValue<int>("int"); }
            set { _propertyBag.SetValue("int", value); }
        }

        public bool BoolValue
        {
            get { return _propertyBag.GetValue<bool>("bool"); }
            set { _propertyBag.SetValue("bool", value); }
        }

        public short ShortValue
        {
            get { return _propertyBag.GetValue<short>("short"); }
            set { _propertyBag.SetValue("short", value); }
        }

        public long LongValue
        {
            get { return _propertyBag.GetValue<long>("long"); }
            set { _propertyBag.SetValue("long", value); }
        }

        public object ReferenceValue
        {
            get { return _propertyBag.GetValue<object>("reference"); }
            set { _propertyBag.SetValue("reference", value); }
        }
    }
}
