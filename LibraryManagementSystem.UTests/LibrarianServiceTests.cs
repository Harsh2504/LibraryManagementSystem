using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Stubs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

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
        public void OneBookShouldBeAddedToTheLibrary()
        {
            var bookRepo = new BookRepositoryStub();
            var authorRepo = new AuthorRepositoryStub();
            var bookAuthorRepo = new BookAuthorRepositoryStub();

            var librarianService = new LibrarianService(bookRepo, authorRepo, bookAuthorRepo);

            var book = new Book("Clean Code");

            var authors = new List<Author>
            {
                new Author("Robert Martin"),
                new Author("Uncle Bob")
            };


            // Act
            librarianService.AddBook(book, authors);

            // Assert
            Assert.That(bookAuthorRepo.Links.Count, Is.EqualTo(2));

        }
    }
}
