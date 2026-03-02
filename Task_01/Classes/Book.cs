namespace Task_01.Classes;

public class Book
{
    public Book(string title, string author, string iSBN)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        IsAvailable = true;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public string GetInfo()
    {
        return "{\n" +
            $"   Title: {Title},\n" +
            $"   Author: {Author},\n" +
            $"   ISBN: {ISBN},\n" +
            $"   IsAvailable: {IsAvailable},\n" +
        "}";
    }

    public bool Borrow()
    {
        if (!IsAvailable) return false;
        IsAvailable = false;
        return true;
    }
    public bool ReturnBook()
    {
        if (IsAvailable) return false;
        IsAvailable = true;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Book other)
            return ISBN == other.ISBN;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ISBN);
    }
}
