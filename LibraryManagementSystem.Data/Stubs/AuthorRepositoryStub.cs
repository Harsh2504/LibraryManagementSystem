using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Data.Stubs
{
    public class AuthorRepositoryStub : IAuthorRepository
    {
        private int _id = 1;
        private readonly List<Author> _authors = new();

        public Author AddIfNotExists(Author author)
        {
            var existing = _authors.FirstOrDefault(a => a.AuthorName == author.AuthorName);
            if (existing != null) return existing;

            author.AuthorId = _id++;
            _authors.Add(author);
            return author;
        }
    }

}
