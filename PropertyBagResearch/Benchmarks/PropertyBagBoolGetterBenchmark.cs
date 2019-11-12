namespace PropertyBagResearch.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class PropertyBagBoolGetterBenchmark : BenchmarkBase
    {
        private TestType _nonTyped;
        private TestType _superTyped;
        private TestType _typed;

        [Params(typeof(DictionaryFactory), typeof(SortedDictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;

            _nonTyped = new TestType(new NonTypedPropertyBag(dictionaryFactory));
            _typed = new TestType(new TypedPropertyBag(dictionaryFactory));
            _superTyped = new TestType(new SuperTypedPropertyBag(dictionaryFactory));

            _nonTyped.IntValue = 42;
            _nonTyped.BoolValue = true;

            _typed.IntValue = 42;
            _typed.BoolValue = true;

            _superTyped.IntValue = 42;
            _superTyped.BoolValue = true;
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

        [Benchmark]
        public bool Getter_SuperTyped()
        {
            return GetBool(_superTyped);
        }

        private bool GetBool(TestType instance)
        {
            return instance.BoolValue;
        }
    }
}