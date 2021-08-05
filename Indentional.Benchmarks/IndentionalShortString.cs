using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Indentional.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp21, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net461)]
    public class IndentionalShortString

    {

        private readonly string shortString =
                @"
                You tried to do something tricky, but something was not true twice in i row.
                It might be better to do this:

                    DoDoingDone(checkForSomethingTrue: false);
                
                Don't ya think?";

        public IndentionalShortString()
        {

        }

        [Benchmark(Baseline = true)]
        public string OriginalShort() => IndentionalOriginal._(shortString);

        [Benchmark]
        public string CurrentShort() => Indentional._(shortString);

    }
}
