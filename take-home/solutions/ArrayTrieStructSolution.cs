using System.Diagnostics;
using System.Management;

namespace take_home.solutions;

public class ArrayTrieStructSolution : Solution
{
    private ArrayTrieStructNode[] _nodes;
    private int _length;

    public ArrayTrieStructSolution()
    {
        _nodes = new ArrayTrieStructNode[Utils.MAX_TRIE_NODES];
        Reset();
    }
    
    public override void Solve(Input input)
    {
        foreach (var word in input.Words)
        {
            AddWord(word);
        }
    }
    
    private void AddWord(string word)
    {
        int trieIndex = 0;

        foreach (var c in word)
        {
            var index = Utils.CharToIndex(c);

            if (_nodes[trieIndex].HasChild(index))
            {
                trieIndex = _nodes[trieIndex].GetChildIndex(index);
            } else {
                _nodes[trieIndex].SetChildIndex(index, _length);
                trieIndex = _length;
                _length += 1;
            }
        }
        _nodes[trieIndex].Visit();
    }
    
    public override void GetWords(List<(string, int)> acc)
    {
        void dfs(int index, string buffer, List<(string, int)> acc)
        {
            if (index < 0 || index >= Utils.MAX_TRIE_NODES) { return; }
                
            if (_nodes[index].WasVisited())
            {
                acc.Add((buffer, _nodes[index].GetTimesVisited()));
            }

            for (var i = 0; i < 26; i += 1)
            {
                if (_nodes[index].GetChildIndex(i) == -1) { continue; }

                dfs(_nodes[index].GetChildIndex(i), $"{buffer}{Utils.IndexToChar(i)}", acc);
            }
        }
        dfs(0, "", acc);
    }
    
    public override void Reset()
    {
        for (var i = 0; i < Utils.MAX_TRIE_NODES; i += 1)
        {
            _nodes[i].InitChildren();
            _nodes[i].Reset();
        }
        _length = 1;
    }
}

internal struct ArrayTrieStructNode
{
    private int[] _children;
    private int _timesVisited;

    public void InitChildren()
    {
        _children = new int[26];
    }
    public void Reset()
    {
        for (var i = 0; i < 26; i += 1)
        {
            _children[i] = -1;
        }
        _timesVisited = 0;
    }
    
    public bool HasChild(int index)
    {
        return _children[index] >= 0;
    }

    public int GetChildIndex(int index)
    {
        return _children[index];
    }
    public void SetChildIndex(int index, int nextNodeIndex)
    {
        _children[index] = nextNodeIndex;
    }

    public void Visit()
    {
        _timesVisited += 1;
    }

    public bool WasVisited()
    {
        return _timesVisited > 0;
    }

    public int GetTimesVisited()
    {
        return _timesVisited;
    }

    public int[] GetChildren()
    {
       return _children;
    }
        
}