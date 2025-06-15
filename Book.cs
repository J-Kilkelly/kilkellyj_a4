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

    public static void CheckOut()
    {
        LibraryCatalog.ListAvailableBooks(); //outputs a list of books available for check out
        Console.WriteLine("\nWhat is the title of the book you would like to checkout?");
        string? titleToCheckOut = Console.ReadLine();
        Book? toCheckOut = LibraryCatalog.books.Find(bk => bk.Title.Equals(titleToCheckOut, StringComparison.OrdinalIgnoreCase)); //is book on list of available books
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
        List<Book> checkedOutBooks = LibraryCatalog.books
                   .Where(book => book.IsCheckedOut) //limits list to books that are checked out (IsCheckedOut == true)
                   .ToList();
        if (!checkedOutBooks.Any()) //true if there are any items in the list of checked out books; not (!) true = no books checked out
        {
            Console.WriteLine("\nThere are no books checked out.");
            return;
        }
        else
            Console.WriteLine($"---Books currently checked out.---\n");
        foreach (Book book in checkedOutBooks) //generate list of books that are checked out; these are the books that may be checked in
            Console.WriteLine(book.Title);
        Console.WriteLine("\nWhat is the title of the book you would like to check in?");
        string? titleToCheckIn = Console.ReadLine();
        Book? toCheckIn = checkedOutBooks.FirstOrDefault(bk => bk.Title.Equals(titleToCheckIn, StringComparison.OrdinalIgnoreCase)); //is the book to be check in, currently checked out?
        if (toCheckIn != null) //book was found on the list of checked out books; proceed to check in the book
        {
            toCheckIn.IsCheckedOut = false;
            Console.WriteLine($"\nYou have checked in {toCheckIn.Title}.");
            return;
        }
        else
        {
            Console.WriteLine($"\nTitle not found in the list of checked out books.");
            return;
        }
    }
}