using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Data.Interface;

namespace LibraryManagementSystem.UTests.Stubs.Librarian
{
    public class BookAuthorRepositoryStub : IBookAuthorRepository
    {
        public List<BookAuthor> Links { get; } = new();

        public void Add(BookAuthor bookAuthor)
        {
            Links.Add(bookAuthor);
        }
    }
}
