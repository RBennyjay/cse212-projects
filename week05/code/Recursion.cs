using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;               // base case
        return n * n + SumSquaresRecursive(n - 1); // recursive step
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)            // base case: we built a word of correct size
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            // choose letter[i], remove it from the remaining pool
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs with memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx == -1)               // base case: no wildcards left
        {
            results.Add(pattern);
            return;
        }

        // replace * with 0
        WildcardBinary(pattern.Substring(0, idx) + "0" + pattern[(idx + 1)..], results);
        // replace * with 1
        WildcardBinary(pattern.Substring(0, idx) + "1" + pattern[(idx + 1)..], results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // explore all four directions
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath)); // right
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath)); // left
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath)); // down
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath)); // up

        currPath.RemoveAt(currPath.Count - 1);
    }
}
