``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|        Method |                  Job |              Runtime |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |--------------------- |--------------------- |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
| OriginalShort |             .NET 5.0 |             .NET 5.0 | 3,677.0 ns | 15.39 ns | 14.40 ns |  0.94 | 5.5466 |     - |     - |     11 KB |
|  CurrentShort |             .NET 5.0 |             .NET 5.0 |   895.8 ns |  5.72 ns |  5.35 ns |  0.23 | 0.5188 |     - |     - |      1 KB |
| OriginalShort |        .NET Core 2.1 |        .NET Core 2.1 | 3,900.9 ns | 22.08 ns | 19.58 ns |  1.00 | 5.5542 |     - |     - |     11 KB |
|  CurrentShort |        .NET Core 2.1 |        .NET Core 2.1 | 3,659.8 ns | 35.29 ns | 29.47 ns |  0.94 | 5.5580 |     - |     - |     11 KB |
| OriginalShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 3,824.0 ns | 17.72 ns | 14.80 ns |  0.98 | 5.8746 |     - |     - |     12 KB |
|  CurrentShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 3,818.4 ns | 17.34 ns | 15.37 ns |  0.98 | 5.8746 |     - |     - |     12 KB |
