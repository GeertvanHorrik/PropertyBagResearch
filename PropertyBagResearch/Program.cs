namespace PropertyBagResearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Running;

    using PropertyBagResearch.Benchmarks;

    class Program
    {
        public static void Main(string[] args)
        {
            Action separatorAction = () => Console.ReadKey();
            //Action separatorAction = null;

            RunAllSorted(separatorAction);
            //RunAllDynamic(separatorAction);
        }

        static void RunAllSorted(Action separatorAction)
        {
            var benchmarkTypes = new List<Type>();
            benchmarkTypes.Add(typeof(PropertyBagPropertyChangedBenchmark));
            benchmarkTypes.Add(typeof(PropertyBagAllocBenchmark));
            benchmarkTypes.Add(typeof(SortedDictionaryBenchmark));
            benchmarkTypes.Add(typeof(SortedDictionaryBenchmark2));
            benchmarkTypes.Add(typeof(PropertyBagBoolGetterBenchmark));
            benchmarkTypes.Add(typeof(PropertyBagIntGetterBenchmark));
            benchmarkTypes.Add(typeof(PropertyBagCtorBenchmark));

            RunAllBenchmarks(benchmarkTypes, separatorAction);
        }

        static void RunAllDynamic(Action separatorAction)
        {
            var benchmarkTypes = typeof(Program).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && typeof(BenchmarkBase).IsAssignableFrom(x))
                .ToList();

            RunAllBenchmarks(benchmarkTypes, separatorAction);
        }

        static void RunAllBenchmarks(List<Type> benchmarkTypes, Action separatorAction)
        {
            foreach (var benchmarkType in benchmarkTypes)
            {
                var summary = BenchmarkRunner.Run(benchmarkType);

                if (separatorAction != null)
                {
                    separatorAction();
                }
            }
        }
    }
}
