using System.Diagnostics;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsCheckedOut { get; set; } = false;

    public Book(string title, string author, bool isCheckedOut = false)
    {
        Title = title;
        Author = author;
        IsCheckedOut = isCheckedOut;
    }

    public static List<Book> books = new List<Book>()
    {
        new Book("A land remembered", "Patrick D. Smith"),
        new Book("Touching History", "Lynn Spencer"),
        new Book("American Assassin", "Vince Flynn")
    };

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

    public static void CheckOut()
    {
        Book.ListAvailableBooks();
        Console.WriteLine("\nWhat is the title of the book you would like to checkout?");
        string? titleToCheckOut = Console.ReadLine();
        Book? toCheckOut = books.Find(bk => bk.Title.Equals(titleToCheckOut, StringComparison.OrdinalIgnoreCase));
        if (toCheckOut != null)
        {
            toCheckOut.IsCheckedOut = true;
            //string checkOutTitle = toCheckOut.Title;
            Console.WriteLine($"\nYou have checked out {toCheckOut.Title}.");
            return;
        }
        else
        {
            Console.WriteLine($"Title not found. Please try again.");
            return;
        }
    }

    public static void CheckIn()
    {
        List<Book> checkedOutBooks = books
                   .Where(book => book.IsCheckedOut) //limits list to books that are checked out (IsCheckedOut == true)
                   .ToList();

        if (!checkedOutBooks.Any()) //true if there are any items in the list of checked out books; not (!) true = no books checked out
        {
            Console.WriteLine("\nThere are no books checked out.");
            return;
        }
        else
            Console.WriteLine($"---Books currently checked out.---\n");
        foreach (Book book in checkedOutBooks)
            Console.WriteLine(book.Title);
        Console.WriteLine("\nWhat is the title of the book you would like to check in?");
        string? titleToCheckIn = Console.ReadLine();
        Book? toCheckIn = checkedOutBooks.FirstOrDefault(bk => bk.Title.Equals(titleToCheckIn, StringComparison.OrdinalIgnoreCase));
        if (toCheckIn != null)
        {
            toCheckIn.IsCheckedOut = false;
            Console.WriteLine($"\nYou have checked in {toCheckIn.Title}.");
            return;
        }
        else
        {
            Console.WriteLine($"\nTitle not found.");
            return;
        }

    }
}