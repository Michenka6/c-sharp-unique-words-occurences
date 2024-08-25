using take_home.solutions;
using take_home;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[MemoryDiagnoser]
// [HardwareCounters(
    // HardwareCounter.BranchMispredictions,
    // HardwareCounter.BranchInstructions,
    // HardwareCounter.CacheMisses
    // )]
public class MyBenchmarks
{
    // private Input input;
    // private Solution solution;
    //
    // [Params(
    //     Utils.SolutionType.DICTIONARY_SOLUTION,
    //     Utils.SolutionType.NAIVE_TRIE_SOLUTION,
    //     Utils.SolutionType.NAIVE_TRIE_DICTIONARY_SOLUTION,
    //     Utils.SolutionType.ARRAY_TRIE_SOLUTION
    //     )]
    // public Utils.SolutionType st;
    //
    //
    // [GlobalSetup]
    // public void Setup()
    // {
    //     var filePath = "../../../../../../../text-files/sherlock-holms.txt";
    //     input = new Input(filePath);
    // }
    //
    // [Benchmark]
    // public void DictionarySolution()
    // {
    //     switch (st)
    //     {
    //         case Utils.SolutionType.DICTIONARY_SOLUTION:
    //             solution = new DictSolution();
    //             break;
    //         case Utils.SolutionType.NAIVE_TRIE_SOLUTION:
    //             solution = new NaiveTrieSolution();
    //             break;
    //         case Utils.SolutionType.NAIVE_TRIE_DICTIONARY_SOLUTION:
    //             solution = new NaiveTrieDictSolution();
    //             break;
    //         case Utils.SolutionType.ARRAY_TRIE_SOLUTION:
    //             solution = new ArrayTrieSolution();
    //             break;
    //         default:
    //             Environment.Exit(69420);
    //             break;
    //     }
    //     solution.Solve(input);
    // }
    //
    // [GlobalCleanup]
    // public void CleanUp()
    // {
    //     solution.Reset();
    // }
    
}