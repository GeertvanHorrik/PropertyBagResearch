namespace PropertyBagResearch.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Catel.Data;

    public class PropertyBagCtorBenchmark : BenchmarkBase
    {
        private IDictionaryFactory _dictionaryFactory;

        [Params(typeof(DictionaryFactory), typeof(SortedDictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;
        }


        [Benchmark]
        public TestType Ctor_NonTyped()
        {
            var type = new TestType(new PropertyBag(_dictionaryFactory));
            return type;
        }

        [Benchmark]
        public TestType Ctor_Typed()
        {
            var type = new TestType(new TypedPropertyBag(_dictionaryFactory));
            return type;
        }
    }
}