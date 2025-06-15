
public enum menuChoices
{
    AddBook = 1,
    CheckOutBook = 2,
    CheckInBook = 3,
    ViewAvailableBooks = 4,
    ViewAllBooks = 5,
    Exit = 6
}

public class UserMenu : Book
{
    static string mainMenuText =
     @"
    Select:
    1. Add a Book
    2. Check out a book
    3. Check in a book
    4. View available books
    5. View all books
    6. Exit";

    public static menuChoices UserSelection { get; set; } = menuChoices.AddBook;
    //public static string Title { get; set; } = "";
    //public static string Author { get; set; } = "";

    public UserMenu(string title, string author, bool isCheckedOut = false) : base(title, author, isCheckedOut)
    {
    }

    public static void DisplayMenu()
    {
        Console.WriteLine(mainMenuText);
        menuChoices userSelection = menuChoices.CheckOutBook; //initialize userSelection
        //bool validSelection = false; //initialize to 'false'

        while (true) //loop will run until exited by user
        {
            if (int.TryParse(Console.ReadLine(), out int selection) && Enum.IsDefined(typeof(menuChoices), selection))
            {
                //if TryParse is successful
                userSelection = (menuChoices)selection;
                ActOnUserSelection(userSelection);
            }
            else
            {
                Console.WriteLine("Enter your selection as 1, 2, 3, 4, 5, or 6.");
                Console.WriteLine(mainMenuText);
            }
        }
    }

    public static void ActOnUserSelection(menuChoices userSelection)
    {
        switch (userSelection)
        {
            case menuChoices.AddBook:
                LibraryCatalog.AddBooks();
                break;
            case menuChoices.CheckOutBook:
                Book.CheckOut();
                UserMenu.DisplayMenu();
                break;
            case menuChoices.CheckInBook:
                Book.CheckIn();
                UserMenu.DisplayMenu();
                break;
            case menuChoices.ViewAvailableBooks:
                LibraryCatalog.ListAvailableBooks();
                UserMenu.DisplayMenu();
                break;
            case menuChoices.ViewAllBooks:
                LibraryCatalog.ViewAllBooks();
                UserMenu.DisplayMenu();
                break;
            case menuChoices.Exit:
                Console.WriteLine("\nYou are exiting the application.\n");
                Environment.Exit(0);
                break;
        }
    }
}