/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var totals = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // skip header

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (totals.ContainsKey(playerId))
                totals[playerId] += points;
            else
                totals[playerId] = points;
        }

        var top = totals.OrderByDescending(p => p.Value).Take(10);

        Console.WriteLine("\nTop 10 Players by Career Points:");
        foreach (var p in top)
        {
            Console.WriteLine($"{p.Key}: {p.Value}");
        }
    }
}