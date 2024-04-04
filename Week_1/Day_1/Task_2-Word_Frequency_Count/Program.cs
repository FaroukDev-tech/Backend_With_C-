using System;
using System.Collections.Generic;

public class App{
    public static void Main(string[] args){
        /* TESTS */
        List<string> Tests = ["Coding is interesting ?", "My name is Farouk", "I am learning C-Sharp", "Recursion is Recursion"];

        foreach(string test in Tests){
            WordFreqCount(test).Select(item=>item.Key+": "+item.Value.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        };
    }

    public static Dictionary<string, int> WordFreqCount(string str){
        Dictionary<string, int> hashmap = [];

        foreach (string word in str.Split()){
            string w = word.ToLower();
            if (w.Length!=1 || !Char.IsPunctuation(Convert.ToChar(w))){
                if (hashmap.ContainsKey(w))
                    hashmap[w] += 1;
                else
                    hashmap[w] = 1;
            }
        }
        return hashmap;
    }
}