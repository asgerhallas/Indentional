``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|       Method |                  Job |              Runtime |      Mean |    Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |--------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|------:|------:|----------:|
| OriginalLong |             .NET 5.0 |             .NET 5.0 | 103.86 μs | 0.522 μs | 0.488 μs |  1.12 | 92.0410 |     - |     - |    188 KB |
|  CurrentLong |             .NET 5.0 |             .NET 5.0 |  24.10 μs | 0.172 μs | 0.152 μs |  0.26 | 25.9705 |     - |     - |     53 KB |
| OriginalLong |        .NET Core 2.1 |        .NET Core 2.1 |  93.07 μs | 1.244 μs | 1.039 μs |  1.00 | 91.7969 |     - |     - |    189 KB |
|  CurrentLong |        .NET Core 2.1 |        .NET Core 2.1 |  93.33 μs | 0.644 μs | 0.538 μs |  1.00 | 91.7969 |     - |     - |    189 KB |
| OriginalLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 |  97.61 μs | 1.165 μs | 1.032 μs |  1.05 | 94.2383 |     - |     - |    194 KB |
|  CurrentLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 |  97.21 μs | 0.786 μs | 0.697 μs |  1.04 | 94.2383 |     - |     - |    194 KB |
