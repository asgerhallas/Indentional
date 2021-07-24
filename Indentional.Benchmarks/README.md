``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.301
  [Host]        : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT
  .NET 5.0      : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  .NET Core 2.1 : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT


```
|        Method |           Job |       Runtime |       Mean |     Error |    StdDev | Ratio | RatioSD |
|-------------- |-------------- |-------------- |-----------:|----------:|----------:|------:|--------:|
| OriginalShort |      .NET 5.0 |      .NET 5.0 |   3.764 μs | 0.0351 μs | 0.0311 μs |  1.00 |    0.00 |
|  CurrentShort |      .NET 5.0 |      .NET 5.0 |   1.054 μs | 0.0105 μs | 0.0098 μs |  0.28 |    0.00 |
|  OriginalLong |      .NET 5.0 |      .NET 5.0 | 101.011 μs | 0.3511 μs | 0.2932 μs | 26.83 |    0.29 |
|   CurrentLong |      .NET 5.0 |      .NET 5.0 |  25.808 μs | 0.1358 μs | 0.1270 μs |  6.86 |    0.06 |
| OriginalShort | .NET Core 2.1 | .NET Core 2.1 |   3.679 μs | 0.0149 μs | 0.0124 μs |  0.98 |    0.01 |
|  CurrentShort | .NET Core 2.1 | .NET Core 2.1 |   3.694 μs | 0.0089 μs | 0.0074 μs |  0.98 |    0.01 |
|  OriginalLong | .NET Core 2.1 | .NET Core 2.1 |  90.478 μs | 0.4927 μs | 0.4115 μs | 24.03 |    0.22 |
|   CurrentLong | .NET Core 2.1 | .NET Core 2.1 |  90.937 μs | 0.8616 μs | 0.7195 μs | 24.15 |    0.26 |
