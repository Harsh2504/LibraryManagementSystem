using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Data.Stubs
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
