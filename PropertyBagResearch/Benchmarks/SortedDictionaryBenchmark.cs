namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SortedDictionaryBenchmark : BenchmarkBase
    {
        private TestType _regularDictionary = new TestType(new NonTypedPropertyBag(new DictionaryFactory()));
        private TestType _sortedDictionary = new TestType(new NonTypedPropertyBag(new SortedDictionaryFactory()));

        public SortedDictionaryBenchmark()
        {
            InitializeDefaultValues(_regularDictionary);
            InitializeDefaultValues(_sortedDictionary);
        }

        private void InitializeDefaultValues(TestType testType)
        {
            // Important: int must be the first value
            testType.IntValue = 42;
            testType.BoolValue = true;
            testType.ShortValue = 42;
            testType.LongValue = 42l;
            testType.IntValue1 = 42;
            testType.IntValue2 = 42;
            testType.IntValue3 = 42;
            testType.IntValue4 = 42;
            testType.IntValue5 = 42;
            testType.IntValue6 = 42;
            testType.IntValue7 = 42;
            testType.IntValue8 = 42;
            testType.IntValue9 = 42;
        }

        [Benchmark]
        public int SortedDictionary_FirstValue()
        {
            return GetFirstInt(_sortedDictionary);
        }

        [Benchmark]
        public int SortedDictionary_LastValue()
        {
            return GetLastInt(_sortedDictionary);
        }

        [Benchmark]
        public int RegularDictionary_FirstValue()
        {
            return GetFirstInt(_regularDictionary);
        }

        [Benchmark]
        public int RegularDictionary_LastValue()
        {
            return GetLastInt(_regularDictionary);
        }

        public int GetFirstInt(TestType testType)
        {
            return testType.IntValue;
        }

        public int GetLastInt(TestType testType)
        {
            return testType.IntValue9;
        }
    }
}
