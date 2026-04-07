using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Interface.Librarian
{
    public interface IBookRepository
    {
        Book Add(Book book);
    }
}
