using LibraryManagementSystem.Models;
using LibraryManagementSystem.Data.Interface.Librarian;

namespace LibraryManagementSystem.UTests.Stubs.Librarian
{
    public class BookRepositoryStub : IBookRepository
    {

        private int _id = 1;

        public Book Add(Book book)
        {
            book.BookId = _id++;
            return book;

        }
    }

}
