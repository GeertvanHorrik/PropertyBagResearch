namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PropertyBagCtorBenchmark : BenchmarkBase
    {
        [Benchmark]
        public TestType Ctor_NonTyped()
        {
            var type = new TestType(new NonTypedPropertyBag(new DictionaryFactory()));
            return type;
        }

        [Benchmark]
        public TestType Ctor_Typed()
        {
            var type = new TestType(new TypedPropertyBag(new DictionaryFactory()));
            return type;
        }

        [Benchmark]
        public TestType Ctor_SuperTyped()
        {
            var type = new TestType(new SuperTypedPropertyBag(new DictionaryFactory()));
            return type;
        }
    }
}
