# How to build
```console
    $ cd take-home
    $ dotnet build
```

## Debug
```console
    $ dotnet run
```
In debug mode, 
as far I know many optimizations are not applied, 
so the results of timing solution heavily skewed towarsds in-built dictionary,
as per the table below:

| Solution        | Average Time~ (ms) |
|-----------------|--------------------|
| Dictionary      | 40                 |
| Naive Trie      | 60                 |
| Naive Trie Dict | 122                |
| Array Trie      | 60                 |

## Release
```console
    $ dotnet run -c Release
```
However, in release after many vm optimizations,
there is significant improvements in these solutions.

| Solution        | Average Time~ (ms) |
|-----------------|--------------------|
| Dictionary      | 40                 |
| Naive Trie      | 42                 |
| Naive Trie Dict | 100                |
| Array Trie      | 21                 |

# Validating
The idea of validating the results is that every solution has to produce the same answer,
so I would print them out into json and compare them.
To run the validation, follow these steps:
```console
    $ cd take-home
    $ dotnet run -c Release
    $ python ./validation.py
```