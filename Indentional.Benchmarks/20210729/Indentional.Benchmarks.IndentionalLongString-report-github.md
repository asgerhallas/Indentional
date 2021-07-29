``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|       Method |                  Job |              Runtime |     Mean |    Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |--------------------- |--------------------- |---------:|---------:|---------:|------:|--------:|------:|------:|----------:|
| OriginalLong |             .NET 5.0 |             .NET 5.0 | 99.81 μs | 0.382 μs | 0.339 μs |  1.13 | 92.0410 |     - |     - |    188 KB |
|  CurrentLong |             .NET 5.0 |             .NET 5.0 | 22.34 μs | 0.087 μs | 0.068 μs |  0.25 | 26.3062 |     - |     - |     54 KB |
| OriginalLong |        .NET Core 2.1 |        .NET Core 2.1 | 88.69 μs | 0.473 μs | 0.395 μs |  1.00 | 91.7969 |     - |     - |    189 KB |
|  CurrentLong |        .NET Core 2.1 |        .NET Core 2.1 | 88.59 μs | 0.282 μs | 0.250 μs |  1.00 | 91.7969 |     - |     - |    189 KB |
| OriginalLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 93.31 μs | 0.210 μs | 0.175 μs |  1.05 | 94.2383 |     - |     - |    194 KB |
|  CurrentLong | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 93.65 μs | 0.988 μs | 0.876 μs |  1.05 | 94.2383 |     - |     - |    194 KB |
