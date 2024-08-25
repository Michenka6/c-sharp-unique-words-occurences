using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace take_home.solutions;

public class ArrayTrieSolution : Solution
{
    private ArrayTrieNode[] _nodes;
    private int _length;
    
    public ArrayTrieSolution()
    {
        _nodes =  new ArrayTrieNode[Utils.MAX_TRIE_NODES];
        for (var i = 0; i < Utils.MAX_TRIE_NODES; i += 1)
        {
            _nodes[i] = new ArrayTrieNode();
        }
        Reset();
    }

    public override void Solve(Input input)
    {
        foreach (var word in input.Words)
        {
            AddWord(word);
        }
    }
    
    public override void Reset()
    {
        for (var i = 0; i < Utils.MAX_TRIE_NODES; i += 1)
        {
            _nodes[i].Reset();
        }
        _length = 1;
    }
    
    private void AddWord(string word)
    {
        var currentNode = _nodes[0];

        foreach (var c in word)
        {
            var index = Utils.CharToIndex(c);
            int trieIndex;

            if (currentNode.HasChild(index))
            {
                trieIndex = currentNode.GetChildIndex(index);
            } else {
                var nextNodeIndex = _length;
                currentNode.SetChildIndex(index, nextNodeIndex);
                _length += 1;
                trieIndex = nextNodeIndex;
            }

            currentNode = _nodes[trieIndex];
        }

        currentNode.Visit();
    }
    
    public override void GetWords(List<(string, int)> acc)
    {
        void dfs(int index, string buffer, List<(string, int)> acc)
        {
            if (index < 0 || index >= Utils.MAX_TRIE_NODES) { return; }
            var node = _nodes[index];
                
            if (node.WasVisited())
            {
                acc.Add((buffer, node.GetTimesVisited()));
            }

            for (var i = 0; i < 26; i += 1)
            {
                dfs(node.GetChildIndex(i), $"{buffer}{Utils.IndexToChar(i)}", acc);
            }
        }
        dfs(0, "", acc);
    }
}

internal class ArrayTrieNode
{
    private int[] _children;
    private int _timesVisited;

    public ArrayTrieNode()
    {
        _children = new int[26];
        this.Reset();
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
        _timesVisited+= 1;
    }

    public bool WasVisited()
    {
        return _timesVisited > 0;
    }

    public int GetTimesVisited()
    {
        return _timesVisited;
    }
}
 