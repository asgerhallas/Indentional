using BenchmarkDotNet.Running;

namespace Indentional.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summaryShort = BenchmarkRunner.Run<IndentionalShortString>();
            var summaryLong = BenchmarkRunner.Run<IndentionalLongString>();
        }
    }
}
