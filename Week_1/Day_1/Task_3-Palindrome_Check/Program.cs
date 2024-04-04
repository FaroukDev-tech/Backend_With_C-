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
        s = s.Trim().ToLower().Replace(" ", "");
        string new_s = new(s.Where(ch=>!Char.IsPunctuation(ch)).ToArray());
        return new_s!="" && new_s ==new string(new_s.Reverse().ToArray());
    }
}
