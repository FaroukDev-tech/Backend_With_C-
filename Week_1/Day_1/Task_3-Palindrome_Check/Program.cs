using System;

public class App
{
    public static void Main(string[] args){
        // TESTS
        List<string> Tests = ["      ", "1234321", "a1a2a1", "", "AbCdE", "ABA", "abcba", "asb", "    aba  ?", "????", "b b b b", "a**kdmfd/"];

        foreach(string test in Tests){
            Console.WriteLine(PalindromeCheck(test));
        }
    }

    public static bool PalindromeCheck(string s){
        // Remove extra spaces at beginning and end of input string
        s = s.Trim();

        // Convert to common case (lower case in this example) 
        s = s.ToLower();

        // Remove any spaces in string input
        s = s.Replace(" ", "");

        // Create new string from input devoid of punctuations (data cleaning)
        string new_s = new(s.Where(ch=>!Char.IsPunctuation(ch)).ToArray());

        // Reverse new string
        string reversed_new_s = new string(new_s.Reverse().ToArray());

        bool res = new_s!="" && new_s == reversed_new_s;  // Check for palindrome;
        return res;
    }
}
