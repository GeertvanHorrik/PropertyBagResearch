namespace PropertyBagResearch.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class SortedDictionaryBenchmark : BenchmarkBase
    {
        private TestType testObject;

        [Params(typeof(DictionaryFactory), typeof(SortedDictionaryFactory), typeof(SortedListDictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [Params(typeof(NonTypedPropertyBag), typeof(TypedPropertyBag), typeof(SuperTypedPropertyBag))]
        public Type PropertyBagType { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;
            var constructorInfo = PropertyBagType.GetConstructor(new[] {typeof(IDictionaryFactory)});
            var propertryBag = (IPropertyBag) constructorInfo.Invoke(new object[] {dictionaryFactory});
            testObject = new TestType(propertryBag)
            {
                BoolValue = true, 
                // ShortValue = 42,
                IntValue = 42, 
                // LongValue = 42l,
                IntProperty00 = 1,
                IntProperty01 = 1,
                IntProperty02 = 1,
                IntProperty03 = 1,
                IntProperty04 = 1,
                IntProperty05 = 1,
                IntProperty06 = 1,
                IntProperty07 = 1,
                IntProperty08 = 1,
                IntProperty09 = 1
            };
        }

        [Benchmark]
        public int GetIntProperty00()
        {
            return testObject.IntProperty00;
        }

        [Benchmark]
        public int GetIntProperty09()
        {
            return testObject.IntProperty09;
        }

        [Benchmark]
        public int GetIntProperty05()
        {
            return testObject.IntProperty05;
        }
    }
}