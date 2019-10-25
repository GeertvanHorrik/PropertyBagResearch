using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System;

namespace PropertyBagResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TypedVsNonTypedPropertyBag_Ctor>();

            Console.ReadKey();

            summary = BenchmarkRunner.Run<TypedVsNonTypedPropertyBag_IntGetter>();

            Console.ReadKey();

            summary = BenchmarkRunner.Run<TypedVsNonTypedPropertyBag_BoolGetter>();

            Console.ReadKey();
        }
    }

    //[SimpleJob(RunStrategy.Throughput, launchCount: 3, warmupCount: 2, targetCount: 5, invocationCount: 10000)]
    [CoreJob]
    [RPlotExporter, RankColumn, MemoryDiagnoser]
    public class TypedVsNonTypedPropertyBag_Ctor
    {
        private TestType _nonTyped = new TestType(new NonTypedPropertyBag());
        private TestType _typed = new TestType(new TypedPropertyBag());
        private TestType _superTyped = new TestType(new SuperTypedPropertyBag());

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
        public TestType Ctor_NonTyped()
        {
            var type = new TestType(new NonTypedPropertyBag());
            return type;
        }

        [Benchmark]
        public TestType Ctor_Typed()
        {
            var type = new TestType(new TypedPropertyBag());
            return type;
        }

        [Benchmark]
        public TestType Ctor_SuperTyped()
        {
            var type = new TestType(new SuperTypedPropertyBag());
            return type;
        }
    }

    [CoreJob]
    [RPlotExporter, RankColumn, MemoryDiagnoser]
    public class TypedVsNonTypedPropertyBag_IntGetter
    {
        private TestType _nonTyped = new TestType(new NonTypedPropertyBag());
        private TestType _typed = new TestType(new TypedPropertyBag());
        private TestType _superTyped = new TestType(new SuperTypedPropertyBag());

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

    [CoreJob]
    [RPlotExporter, RankColumn, MemoryDiagnoser]
    public class TypedVsNonTypedPropertyBag_BoolGetter
    {
        private TestType _nonTyped = new TestType(new NonTypedPropertyBag());
        private TestType _typed = new TestType(new TypedPropertyBag());
        private TestType _superTyped = new TestType(new SuperTypedPropertyBag());

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
