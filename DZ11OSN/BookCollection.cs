using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11OSN
{
    public class BookCollection
    {
        public delegate int BookCompare(Book x, Book y);
      
        private Book[] books;
        public BookCollection(Book[] books)
        {
            this.books = books;
        
    

        }
        public void Sort(BookCompare comparer)
        {
            Array.Sort(books, new Comparison<Book>(comparer));
        }

    }
}
