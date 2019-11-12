namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SortedDictionaryBenchmark : BenchmarkBase
    {
        private TestType _regularDictionary = new TestType(new NonTypedPropertyBag(new DictionaryFactory()));
        private TestType _sortedDictionary = new TestType(new NonTypedPropertyBag(new DictionaryFactory()));

        public SortedDictionaryBenchmark()
        {
            _regularDictionary.BoolValue = true;
            _regularDictionary.ShortValue = 42;
            _regularDictionary.IntValue = 42;
            _regularDictionary.LongValue = 42l;

            _sortedDictionary.BoolValue = true;
            _sortedDictionary.ShortValue = 42;
            _sortedDictionary.IntValue = 42;
            _sortedDictionary.LongValue = 42l;
        }

        [Benchmark]
        public int SortedDictionary()
        {
            return GetInt(_sortedDictionary);
        }

        [Benchmark]
        public int RegularDictionary()
        {
            return GetInt(_regularDictionary);
        }

        public int GetInt(TestType testType)
        {
            return testType.IntValue;
        }
    }
}
