``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.302
  [Host]               : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET 5.0             : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  .NET Core 2.1        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT


```
|        Method |                  Job |              Runtime |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |--------------------- |--------------------- |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
| OriginalShort |             .NET 5.0 |             .NET 5.0 | 3,865.5 ns | 24.55 ns | 21.76 ns |  1.02 | 5.5466 |     - |     - |  11,600 B |
|  CurrentShort |             .NET 5.0 |             .NET 5.0 |   901.4 ns |  8.58 ns |  8.02 ns |  0.24 | 0.2365 |     - |     - |     496 B |
| OriginalShort |        .NET Core 2.1 |        .NET Core 2.1 | 3,778.4 ns | 48.14 ns | 42.67 ns |  1.00 | 5.5580 |     - |     - |  11,664 B |
|  CurrentShort |        .NET Core 2.1 |        .NET Core 2.1 | 3,790.1 ns | 24.21 ns | 21.46 ns |  1.00 | 5.5542 |     - |     - |  11,664 B |
| OriginalShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 3,976.6 ns | 29.81 ns | 26.43 ns |  1.05 | 5.8746 |     - |     - |  12,332 B |
|  CurrentShort | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 3,972.5 ns | 20.41 ns | 18.09 ns |  1.05 | 5.8746 |     - |     - |  12,332 B |
