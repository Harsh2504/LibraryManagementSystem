using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public interface IAuthorRepository
    {
        Author AddIfNotExists(Author author);
    }
}
