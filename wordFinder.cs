using System;

namespace wordFinder
{
    class wordFinder
    {

        static void Main(string[] args)
        {
            List<string> words = new List<string> { "word", "words", "wood", "order", "were" };
            List<char> allowedChar = new List<char> { 'o', 'r', 's', 'd', 'o', 'w', 'e' };
            var results = wordFinder(words, allowedChar);
            foreach (var result in results)
                Console.WriteLine(result);
        }

        //checkWordChars is used to remove each char value from the word. If the word contains a char that is not within the chars list, 
        //the result is return false due to the word not being able to be created. Additionally, this will mitigate the issue of duplicates
        //as words with additional letters like two 'r's will be eliminated on the second pass of removal from the chars list
        public static bool checkWordChars(string word, List<char> chars)
        {
            string charString = string.Empty;
            List<char> temp = new List<char>(chars);

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!temp.Remove(c))
                    return false;
            }
            return true;
        }

        //wordFinder is used to pass checkWordChars individual words from the List of words. This function also will add words that return true
        //from checkWordChars into the result List. This List will be returned as the words that are acceptable and can be made from the chars List
        public static List<string> wordFinder(List<string> word, List<char> chars)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < word.Count; i++)
            {
                if (checkWordChars(word[i], chars))
                {
                    results.Add(word[i]);
                }
            }
            return results;
        }

    }
}