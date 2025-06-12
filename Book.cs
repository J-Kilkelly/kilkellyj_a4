public class Book
{
    string Title { get; set; }
    string Author { get; set; }
    bool IsCheckedOut { get; set; } = false;

    public Book(string title, string author, bool IsCheckedOut)
    {
        Title = title;
        Author = author;
        this.IsCheckedOut = IsCheckedOut;
    }

    public void CheckOut()
    {
        IsCheckedOut = true;
    }

    public void CheckIn()
    {
        IsCheckedOut = false;
    }
    
}