using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class LibrarianService
    {

        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookAuthorRepository _bookAuthorRepo;


        public LibrarianService(
            IBookRepository bookRepo,
            IAuthorRepository authorRepo,
            IBookAuthorRepository bookAuthorRepo
         ){
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _bookAuthorRepo = bookAuthorRepo;

        }

        public void AddBook(Book book, List<Author> authors)
        {

            // 1. Add book
            var savedBook = _bookRepo.Add(book);

            // 2. Add authors & create relations
            foreach (var author in authors)
            {
                var savedAuthor = _authorRepo.AddIfNotExists(author);

                var link = new BookAuthor(
                    savedBook.BookId,
                    savedAuthor.AuthorId
                );

                _bookAuthorRepo.Add(link);
            }

        }
    }
}
