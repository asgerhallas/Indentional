using BenchmarkDotNet.Running;

namespace Indentional.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IndentionalBenchmarks>();
        }
    }
}
