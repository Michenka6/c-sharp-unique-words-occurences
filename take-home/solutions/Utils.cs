namespace take_home.solutions;

public record Occurence(string Word, int Times);
public static class Utils
{
    public const int NUMBER_OF_RUNS = 10;
    public const int MAX_TRIE_NODES = 150_000;
    public static char IndexToChar(int i)
    {
        return (char)(i + 97);
    }
    
    public static int CharToIndex(char c)
    {
        return (int)(c) - 97;
    }
    
    public enum SolutionType
    {
        DICTIONARY_SOLUTION,
        NAIVE_TRIE_SOLUTION,
        NAIVE_TRIE_DICTIONARY_SOLUTION,
        ARRAY_TRIE_SOLUTION,
    }
}