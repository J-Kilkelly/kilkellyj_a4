public static class LibraryCatalog
{
    public static List<Book> books = new List<Book>() //create and populate books list
    {
        new Book("A Land Remembered", "Patrick D. Smith"),
        new Book("Touching History", "Lynn Spencer"),
        new Book("American Assassin", "Vince Flynn"),
        new Book(title:"Baby in the Mirror", author: "Dorothy Kilkelly")
    };

    public static void ViewAllBooks()
    {
        Console.WriteLine($"--- All Books ---\n");
        foreach (Book book in LibraryCatalog.books)
        {
            Console.WriteLine($"Title: {book.Title}; Author: {book.Author}; Checked Out: {book.IsCheckedOut}");
        }
    }

    public static void ListAvailableBooks()
    {
        List<Book> availableBooks = books
            .Where(bk => bk.IsCheckedOut == false)
            .ToList();
        Console.WriteLine("---Available Books---\n");
        foreach (Book book in availableBooks)
            Console.WriteLine(book.Title);
        return;
    }

    public static void AddBooks()
    {
        Console.WriteLine("What is the title of the new book?");
        string? newTitle = Console.ReadLine();
        Console.WriteLine("\nWhat is the author's name?");
        string? newAuthor = Console.ReadLine();
        books.Add(new Book(newTitle, newAuthor));
        Console.WriteLine($"\nThe book {newTitle} has been added.\n");
        UserMenu.DisplayMenu();
    }

    public static void CheckOutBook(string title)
    {
        var checkOut = books.FirstOrDefault(book => book.Title.Equals(title));
        checkOut.IsCheckedOut = true;
        Console.WriteLine($"You have checked out the book {checkOut.Title.ToString()}");
    }
}