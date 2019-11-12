namespace PropertyBagResearch.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    [CoreJob]
    [RPlotExporter, RankColumn, MemoryDiagnoser]
    public abstract class BenchmarkBase
    {
    }
}
