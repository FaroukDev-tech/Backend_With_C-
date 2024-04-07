using System;

namespace books_component{
    public class Book(string title, string author, string isbn, int year){
        public string? Title {get; set;} = title;
        public string? Author {get; set;} = author;
        public string? ISBN {get; set;} = isbn;
        public int PublicationYear {get; set;} = year;
    }
}