using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();

        Console.WriteLine("\n======================\nFirst Duplicate\n======================");
        try {
            Console.WriteLine($"First duplicate in 'apple': {FirstDuplicate.Find("apple")}");
            Console.WriteLine($"First duplicate in 'abcdefga': {FirstDuplicate.Find("abcdefga")}");
            Console.WriteLine($"First duplicate in 'Hello World!': {FirstDuplicate.Find("Hello World!")}");
            Console.WriteLine($"First duplicate in 'cat': {FirstDuplicate.Find("cat")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected exception for 'cat': {ex.Message}");
        }
    }
}