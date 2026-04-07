namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; }

        public Book(string bookName)
        {
            BookName = bookName;
        }


    }
}
