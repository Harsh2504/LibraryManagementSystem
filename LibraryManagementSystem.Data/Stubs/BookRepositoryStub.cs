using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Stubs
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
