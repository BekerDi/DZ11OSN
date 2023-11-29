using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11OSN
{
    public class Book
    {
        public string Title {  get;}
        public string Author { get;}
        public string   Publisher { get;}

        public Book(string tittle, string autor, string publisher)
        {
            this.Title = tittle;
            this.Author = autor;
            this.Publisher = publisher;
        }
    }
}
