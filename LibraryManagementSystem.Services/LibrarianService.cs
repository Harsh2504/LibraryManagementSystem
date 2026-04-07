using LibraryManagementSystem.Data.Interface;
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
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (string.IsNullOrWhiteSpace(book.BookName)) throw new ArgumentException("Book name cannot be empty or whitespace.", nameof(book));

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    if (string.IsNullOrWhiteSpace(author.AuthorName)) throw new ArgumentException("Author name cannot be empty or whitespace.", nameof(authors));
                }
            }

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
