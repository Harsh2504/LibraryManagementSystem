using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public interface IBookRepository
    {
        Book Add(Book book);
    }
}
