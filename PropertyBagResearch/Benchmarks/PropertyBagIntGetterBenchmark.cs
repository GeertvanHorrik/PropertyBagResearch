namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PropertyBagIntGetterBenchmark : BenchmarkBase
    {
        private TestType _nonTyped = new TestType(new NonTypedPropertyBag(new DictionaryFactory()));
        private TestType _typed = new TestType(new TypedPropertyBag(new DictionaryFactory()));
        private TestType _superTyped = new TestType(new SuperTypedPropertyBag(new DictionaryFactory()));

        [GlobalSetup]
        public void Setup()
        {
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
