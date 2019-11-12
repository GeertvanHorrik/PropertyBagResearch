namespace PropertyBagResearch
{
    using BenchmarkDotNet.Running;
    using PropertyBagResearch.Benchmarks;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var benchmarkTypes = typeof(Program).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && typeof(BenchmarkBase).IsAssignableFrom(x))
                .ToList();

            foreach (var benchmarkType in benchmarkTypes)
            {
                var summary = BenchmarkRunner.Run(benchmarkType);

                Console.ReadKey();
            }
        }
    }
}
