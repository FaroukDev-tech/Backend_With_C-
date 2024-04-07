using System;
using System.Collections.Generic;
using books_component;
using mediaitems_component;

namespace library_component{
    public class Library(string name, string addr, List<Book> books, List<MediaItem> mediaitems){
        public string? Name {get; set;} = name;
        public string? Address {get; set;} = addr;
        public List<Book> Books = books;
        public List<MediaItem> MediaItems = mediaitems;

        public void AddBook(Book book){
            Books.Add(book);
        }

        public void RemoveBook(Book book){
            Books.Remove(book);
        }

        public void AddMediaItem(MediaItem item){
            MediaItems.Add(item);
        }

        public void RemoveMediaItem(MediaItem item){
            MediaItems.Remove(item);
        }

        public void PrintCatalog(){
            Console.WriteLine("Books\n-----------------------");

            foreach(var book in Books){
                Console.WriteLine($"{book.Title}");
            }

            Console.WriteLine();

            Console.WriteLine("Media Items\n-----------------------");

            foreach(var item in MediaItems){
                Console.WriteLine($"{item.Title}");
            }
            Console.WriteLine();
        }

        public List<Book> SearchBook(string search_term){
            List<Book> res = [];

            foreach(Book book in Books){
                if (book.Title==search_term || book.Author==search_term || book.ISBN==search_term){
                    res.Add(book);
                }
            }

            return res;
        }

        public List<MediaItem> SearchMedia(string search_term){
            List<MediaItem> res = [];

            foreach(MediaItem item in MediaItems){
                if (item.Title==search_term || item.MediaType==search_term){
                    res.Add(item);
                }
            }

            return res;
        }
    }
}