namespace PropertyBagResearch.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Catel.Data;

    public class PropertyBagBoolGetterBenchmark : BenchmarkBase
    {
        private TestType _nonTyped;
        private TestType _typed;

        [Params(typeof(DictionaryFactory), typeof(SortedDictionaryFactory), typeof(SortedListDictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;

            _nonTyped = new TestType(new PropertyBag(dictionaryFactory));
            _typed = new TestType(new TypedPropertyBag(dictionaryFactory));

            _nonTyped.IntValue = 42;
            _nonTyped.BoolValue = true;

            _typed.IntValue = 42;
            _typed.BoolValue = true;
        }

        [Benchmark]
        public bool Getter_NonTyped()
        {
            return GetBool(_nonTyped);
        }

        [Benchmark]
        public bool Getter_Typed()
        {
            return GetBool(_typed);
        }

        private bool GetBool(TestType instance)
        {
            return instance.BoolValue;
        }
    }
}