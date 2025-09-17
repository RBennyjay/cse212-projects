using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();

        // Build dictionary
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        // Test translations (case-insensitive now!)
        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("TRAIN"));  // ???
    }

    // Dictionary with case-insensitive key comparer
    private Dictionary<string, string> _words = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the fromWord into the stored translation.
    /// If not found, returns "???"
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        else
        {
            return "???";
        }
    }
}
