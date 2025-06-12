public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsCheckedOut { get; set; } = false;

    public Book(string title, string author, bool isCheckedOut)
    {
        Title = title;
        Author = author;
        IsCheckedOut = isCheckedOut;
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