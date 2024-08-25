using System.Diagnostics;

namespace take_home.solutions;

using System.Collections;

public class NaiveTrieSolution : Solution
{
    private NaiveTrie _root = new NaiveTrie();

    public override void Solve(Input input)
    {
        foreach (var word in input.Words)
        {
            _root.AddWord(word);
        }
    }
    
    public override void Reset() { _root.Reset(); }

    public override void GetWords(List<(string, int)> acc) { _root.GetWords(acc); }
}

internal class NaiveTrie
{
    private int _timesVisited = 0;
    private NaiveTrie[] _children = new NaiveTrie[26];

    public void AddWord(string word)
    {
        var currentNode = this;
        foreach (var c in word)
        {
            var index = Utils.CharToIndex(c);
            if (currentNode._children[index] == null)
            {
                currentNode._children[index] = new NaiveTrie();
            }
            currentNode = currentNode._children[index];
        } 
        currentNode._timesVisited += 1;
    }
    
    public void GetWords(List<(string, int)> acc)
    {
        void dfs(NaiveTrie currentNode, string buffer, List<(string, int)> acc)
        {
            if (currentNode == null) { return; }

            if (currentNode._timesVisited > 0)
            {
                acc.Add((buffer, currentNode._timesVisited));
            }

            for (var i = 0; i < 26; i += 1)
            {
                var child = currentNode._children[i];
                dfs(child, $"{buffer}{Utils.IndexToChar(i)}", acc);
            }
        }
        
        dfs(this, "", acc);
    }
    
    public void Reset()
    {
        for (var i = 0; i < _children.Length; i++)
        {
            _children[i] = null;
        }
    }
}