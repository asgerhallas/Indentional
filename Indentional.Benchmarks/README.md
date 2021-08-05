``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|        Method |                  Job |              Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |--------------------- |--------------------- |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| OriginalShort |             .NET 5.0 |             .NET 5.0 | 4.415 μs | 0.0483 μs | 0.0428 μs |  1.01 |    0.02 | 5.5466 |     - |     - |     11 KB |
|  CurrentShort |             .NET 5.0 |             .NET 5.0 | 1.055 μs | 0.0158 μs | 0.0148 μs |  0.24 |    0.00 | 0.5188 |     - |     - |      1 KB |
| OriginalShort |        .NET Core 2.1 |        .NET Core 2.1 | 4.354 μs | 0.0595 μs | 0.0496 μs |  1.00 |    0.00 | 5.5542 |     - |     - |     11 KB |
|  CurrentShort |        .NET Core 2.1 |        .NET Core 2.1 | 3.261 μs | 0.0302 μs | 0.0252 μs |  0.75 |    0.01 | 5.5428 |     - |     - |     11 KB |
| OriginalShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 4.620 μs | 0.0851 μs | 0.0836 μs |  1.06 |    0.03 | 5.8746 |     - |     - |     12 KB |
|  CurrentShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 3.632 μs | 0.0358 μs | 0.0318 μs |  0.83 |    0.01 | 5.8632 |     - |     - |     12 KB |

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|       Method |                  Job |              Runtime |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |--------------------- |--------------------- |----------:|---------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
| OriginalLong |             .NET 5.0 |             .NET 5.0 | 117.71 μs | 1.248 μs |  1.225 μs | 117.74 μs |  1.10 |    0.03 | 92.0410 |     - |     - |    188 KB |
|  CurrentLong |             .NET 5.0 |             .NET 5.0 |  25.73 μs | 0.156 μs |  0.138 μs |  25.72 μs |  0.24 |    0.01 | 26.3062 |     - |     - |     54 KB |
| OriginalLong |        .NET Core 2.1 |        .NET Core 2.1 | 120.76 μs | 5.777 μs | 16.761 μs | 114.01 μs |  1.00 |    0.00 | 91.7969 |     - |     - |    189 KB |
|  CurrentLong |        .NET Core 2.1 |        .NET Core 2.1 |  39.13 μs | 0.688 μs |  0.574 μs |  39.01 μs |  0.37 |    0.01 | 90.8813 |     - |     - |    188 KB |
| OriginalLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 109.98 μs | 2.062 μs |  1.929 μs | 109.36 μs |  1.03 |    0.03 | 94.2383 |     - |     - |    194 KB |
|  CurrentLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 |  49.06 μs | 0.474 μs |  0.396 μs |  48.95 μs |  0.46 |    0.01 | 93.9941 |     - |     - |    193 KB |