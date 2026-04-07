using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Data.Interface
{
    public interface IBookAuthorRepository
    {
        void Add(BookAuthor bookAuthor);
    }
}
