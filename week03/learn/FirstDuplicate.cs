using System;
using System.Collections.Generic;

public class FirstDuplicate
{
    /*
     * Articulating Answers to Technical Questions:
     *
     * 1. What are possible scenarios to consider?
     *    - "apple" -> returns 'p'
     *    - "abcdefga" -> returns 'a'
     *    - "Hello World!" -> returns 'l' (only considering letters, case-sensitive if 'l' is duplicated)
     *    - "cat" -> throws exception (no duplicates)
     *    - "" or null -> throws exception (empty or null input)
     *    - "123456" -> throws exception (no letters)
     *
     * 2. What are some data structures that may be useful? And what would their performance be?
     *    - A HashSet<char> would be very useful here.
     *    - Performance: Checking if an item exists in a HashSet is an O(1) operation on average.
     *      Inserting an item is also O(1).
     *      Therefore, the overall time complexity would be O(N) where N is the length of the string.
     *      Space complexity would be O(M) where M is the number of unique letters in the string.
     *
     * 3. What are the boundary conditions that you should consider for this problem?
     *    - Empty strings or null strings (handled by throwing an exception).
     *    - Strings with no duplicate letters (handled by throwing an exception).
     *    - Strings with characters other than letters (numbers, symbols, spaces). We only want to consider letters,
     *      so we must filter or check if the character is a letter before checking for duplication.
     *
     * 4. Outline a possible solution.
     *    - First, check if the input string is null or empty. If so, throw an ArgumentException.
     *    - Initialize an empty HashSet<char> to keep track of letters we've seen.
     *    - Loop through each character in the string.
     *    - Check if the character is a letter (e.g., using char.IsLetter).
     *    - If it is a letter, check if it's already in the HashSet.
     *    - If it is in the HashSet, we found our first duplicate! Return that character.
     *    - If it is not in the HashSet, add it to the HashSet.
     *    - If the loop finishes without returning, it means no duplicate letter was found.
     *    - Throw an InvalidOperationException since no duplicate was found.
     */

    public static char Find(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }

        HashSet<char> seenLetters = new HashSet<char>();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                if (seenLetters.Contains(c))
                {
                    return c;
                }
                seenLetters.Add(c);
            }
        }

        throw new InvalidOperationException("No duplicate letter found in the string.");
    }
}
