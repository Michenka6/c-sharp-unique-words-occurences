using System.Text;

namespace take_home;

public class Input
{  
    public readonly string[] Words;
    
    public Input(string filePath)
    {
        var input = File.ReadAllText(filePath);
        var sb = new StringBuilder();
        var spaceAdded = false;
        foreach (var c in input)
        {
            if (char.IsAsciiLetter(c))
            {
                sb.Append(char.ToLower(c));
                spaceAdded = false;
            }
            else if (!spaceAdded)
            {
                sb.Append(' ');
                spaceAdded = true;
            }
        }
        
        Words = sb.ToString().Trim().Split(' ');
    }
}