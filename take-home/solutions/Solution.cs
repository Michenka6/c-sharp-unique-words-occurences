using System.Diagnostics;

namespace take_home.solutions;

public class Solution
{
    public virtual void Solve(Input input) { }
    public virtual void Reset() {}

    public virtual void GetWords(List<(string, int)> acc) {}

    public double SolveAndTime(Input input, int numberOfRuns)
    {
        var total = 0.0;
        for (var i = 0; i < numberOfRuns; i++)
        {
            Reset();
            
            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            
            Solve(input);
            
            stopwatch.Stop();
            
            var timespan = stopwatch.Elapsed;
            total += timespan.TotalMilliseconds;
        }
        return total/numberOfRuns;
    }

    public void PrintToFile(string filePath)
    {
        
        var sw = new StreamWriter(filePath);
        
        sw.WriteLine("{");

        var flag = false;
        var acc = new List<(string, int)>();
        GetWords(acc);
        foreach (var (word, count) in acc)
        {
            if (flag) { sw.WriteLine(","); }
            sw.Write($"\"{word}\" : {count}");
            flag = true;
        }
        sw.WriteLine();
        sw.WriteLine("}");
        sw.Dispose();
        
    }

}