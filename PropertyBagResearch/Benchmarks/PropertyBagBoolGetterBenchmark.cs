namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PropertyBagBoolGetterBenchmark : BenchmarkBase
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
