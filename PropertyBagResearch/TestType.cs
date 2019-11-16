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

        public int IntProperty00
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty00)); }
            set { _propertyBag.SetValue(nameof(IntProperty00), value); }
        }
        public int IntProperty01
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty01)); }
            set { _propertyBag.SetValue(nameof(IntProperty01), value); }
        }
        
        public int IntProperty02
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty02)); }
            set { _propertyBag.SetValue(nameof(IntProperty02), value); }
        }
        public int IntProperty03
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty03)); }
            set { _propertyBag.SetValue(nameof(IntProperty03), value); }
        }
        public int IntProperty04
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty04)); }
            set { _propertyBag.SetValue(nameof(IntProperty04), value); }
        }
        public int IntProperty05
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty05)); }
            set { _propertyBag.SetValue(nameof(IntProperty05), value); }
        }
        
        public int IntProperty06
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty06)); }
            set { _propertyBag.SetValue(nameof(IntProperty06), value); }
        }

        public int IntProperty07
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty07)); }
            set { _propertyBag.SetValue(nameof(IntProperty07), value); }
        }
        
        public int IntProperty08
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty08)); }
            set { _propertyBag.SetValue(nameof(IntProperty08), value); }
        }

        public int IntProperty09
        {
            get { return _propertyBag.GetValue<int>(nameof(IntProperty09)); }
            set { _propertyBag.SetValue(nameof(IntProperty09), value); }
        }
    }
}
