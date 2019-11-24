namespace PropertyBagResearch.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Catel.Data;

    public class PropertyBagIntGetterBenchmark : BenchmarkBase
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

            _nonTyped = new TestType(new PropertyBag(dictionaryFactory));
            _typed = new TestType(new TypedPropertyBag(dictionaryFactory));

            _nonTyped.IntValue = 42;
            _nonTyped.BoolValue = true;

            _typed.IntValue = 42;
            _typed.BoolValue = true;

            _superTyped.IntValue = 42;
            _superTyped.BoolValue = true;
        }

        [Benchmark]
        public int Getter_NonTyped()
        {
            return GetInt(_nonTyped);
        }

        [Benchmark]
        public int Getter_Typed()
        {
            return GetInt(_typed);
        }

        [Benchmark]
        public int Getter_SuperTyped()
        {
            return GetInt(_superTyped);
        }

        private int GetInt(TestType instance)
        {
            return instance.IntValue;
        }
    }
}