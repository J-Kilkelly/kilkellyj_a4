public static class LibraryCatalog
{
    public static List<Book> books = new List<Book>();

    public static void AddBooks(Book book)
    {
        books.Add(book);
        Console.WriteLine($"{book.Title} was added.");
    }

    public static void CheckOutBook(string title)
    {
        var checkOut = books.FirstOrDefault(book => book.Title.Equals(title));
        checkOut.IsCheckedOut = true;
        Console.WriteLine($"You have checked out the book {checkOut.Title.ToString()}");
    }

    public static void CheckInBook(string title)
    {

    }
}