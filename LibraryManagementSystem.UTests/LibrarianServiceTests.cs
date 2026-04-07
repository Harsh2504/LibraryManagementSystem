using LibraryManagementSystem.Data;
using LibraryManagementSystem.UTests.Stubs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using LibraryManagementSystem.UTests.Stubs.Librarian;
using LibraryManagementSystem.Data.Interface.Librarian;

namespace LibraryManagementSystem.UTests
{
    public class Tests
    {
        private LibrarianService _librarianServiceSut;
        private IBookRepository _bookRepositoryStub;

        [SetUp]
        public void Setup()
        {
            //_librarianServiceSut = new LibrarianService();
        }

        [Test]
        public void OneBookWithOneAuthor_AddToTheLibrary()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();

            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);

            var book = new Book("Clean Code");

            var authors = new List<Author>
            {
                new Author("Robert Martin")
            };


            // Act
            librarianService.AddBook(book, authors);

            // Assert
            Assert.That(bookAuthorRepo.Links.Count, Is.EqualTo(1));

        }

        [Test]
        public void OneBookWithMultipleAuthor_AddToTheLibrary()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();

            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);

            var book = new Book("Clean Code");

            var authors = new List<Author>
            {
                new Author("Robert Martin"),
                new Author("Uncle Bob"),
                new Author("Vedang Atre")
            };


            // Act
            librarianService.AddBook(book, authors);

            // Assert
            Assert.That(bookAuthorRepo.Links.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddBook_NullBook_ThrowsException()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();
            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);
            
            var authors = new List<Author> { new Author("Robert Martin") };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => librarianService.AddBook(null, authors));
        }

        [Test]
        public void AddBook_WhitespaceBookTitle_ThrowsException()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();
            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);
            
            var book = new Book("   "); // Whitespace title
            var authors = new List<Author> { new Author("Robert Martin") };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => librarianService.AddBook(book, authors));
        }

        [Test]
        public void AddBook_WhitespaceAuthorName_ThrowsException()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();
            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);
            
            var book = new Book("Clean Code");
            var authors = new List<Author> { new Author("   ") }; // Whitespace author

            // Act & Assert
            Assert.Throws<ArgumentException>(() => librarianService.AddBook(book, authors));
        }

        //Delete entries from book as well as book_author
        
    }
}
