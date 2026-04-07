using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; }

        public Author(string authorName)
        {
            AuthorName = authorName;
        }

    }
}
