using System.Diagnostics;

namespace take_home.solutions;

public class DictSolution : Solution
{
    private readonly Dictionary<string, int> _dict = new Dictionary<string, int>();

    public override void Solve(Input input)
    {
        foreach (var word in input.Words)
        {
            _dict.TryGetValue(word, out var value);
            _dict[word] = value + 1;
        }
    }

    public override void GetWords(List<(string, int)> acc)
    {
        foreach (var kv in _dict)
        {
            acc.Add((kv.Key, kv.Value));
        }
    }

    public override void Reset()
    {
        _dict.Clear();
    }
}