using BenchmarkDotNet.Running;
using take_home;
using take_home.solutions;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "./text-files/sherlock-holms.txt";
        RunSolution(Utils.SolutionType.DICTIONARY_SOLUTION, filePath);
        RunSolution(Utils.SolutionType.NAIVE_TRIE_SOLUTION, filePath);
        RunSolution(Utils.SolutionType.NAIVE_TRIE_DICTIONARY_SOLUTION, filePath);
        RunSolution(Utils.SolutionType.ARRAY_TRIE_SOLUTION, filePath);
        
        // var summary = BenchmarkRunner.Run<MyBenchmarks>();
    }

    static void RunSolution(Utils.SolutionType sn, string filePath)
    {
        var input = new Input(filePath);
        
        string outFilePath = "";
        string message = "";
        double time;
        Solution solution = new Solution(); // @TODO Initialized, but should be reassigned
        
        switch (sn)
        {
            case Utils.SolutionType.DICTIONARY_SOLUTION:
                solution = new DictSolution();
                outFilePath = "./occurence-tables/01-solution.json";
                message = "Dictionary solution took";
                break;
            case Utils.SolutionType.NAIVE_TRIE_SOLUTION:
                solution = new NaiveTrieSolution();
                outFilePath = "./occurence-tables/02-solution.json";
                message = "NaiveTrie solution took";
                break;
            case Utils.SolutionType.NAIVE_TRIE_DICTIONARY_SOLUTION:
                solution = new NaiveTrieDictSolution();
                outFilePath = "./occurence-tables/03-solution.json";
                message = "NaiveTrieDict solution took";
                break;
            case Utils.SolutionType.ARRAY_TRIE_SOLUTION:
                solution = new ArrayTrieSolution();
                outFilePath = "./occurence-tables/04-solution.json";
                message = "ArrayTrie solution took";
                break;
            default:
                Environment.Exit(69420);
                break;
        }
        
        solution.Solve(input);
        solution.PrintToFile(outFilePath);
        
        time = solution.SolveAndTime(input, 100);
        Console.WriteLine($"{message} {time}ms");
    }

    
}
