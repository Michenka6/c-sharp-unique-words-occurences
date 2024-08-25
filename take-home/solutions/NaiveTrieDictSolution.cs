using System.Diagnostics;

namespace take_home.solutions;

using System.Collections;

public class NaiveTrieDictSolution : Solution
{
    private NaiveTrieDict _root = new NaiveTrieDict();

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

internal class NaiveTrieDict
{
    private int _timesVisited = 0;
    private Dictionary<char, NaiveTrieDict> _children = new Dictionary<char, NaiveTrieDict>();

    public void AddWord(string word)
    {
        var currentNode = this;
        foreach (var c in word)
        {
            var index = Utils.CharToIndex(c);
            if (!currentNode._children.ContainsKey(c))
            {
                var node = new NaiveTrieDict();
                currentNode._children[c] = node;
            }
            currentNode = currentNode._children[c]; 
        } 
        currentNode._timesVisited += 1;
    }
    
    public void GetWords(List<(string, int)> acc)
    {
        void dfs(NaiveTrieDict currentNode, string buffer, List<(string, int)> acc)
        {
            if (currentNode == null) { return; }

            if (currentNode._timesVisited > 0)
            {
                acc.Add((buffer, currentNode._timesVisited));
            }

            for (var i = 0; i < 26; i += 1)
            {
                var c = Utils.IndexToChar(i);
                if (!currentNode._children.ContainsKey(c)) { continue;}
                
                var child = currentNode._children[c];
                dfs(child, $"{buffer}{c}", acc);
            }
        }
        
        dfs(this, "", acc);
    }

    public void Reset()
    {
        _children.Clear();
    }
}