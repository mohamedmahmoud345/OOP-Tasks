namespace Task_01.Classes;

public class Member
{
    public string Name { get; set; }
    public Guid Id { get; }
    private HashSet<Book> BorrowedBooks { get; }

    public Member(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        BorrowedBooks = new();
    }

    public string GetInfo()
    {
        var books = BorrowedBooks.Any() ?
                string.Join(",\n", BorrowedBooks.Select(x => x.Title)) :
                "None";

        return "{\n" +
            $"   MemberId: {Id},\n" +
            $"   Name: {Name},\n" +
            $"   BorrowedBooks: {books}" +
        "}";
    }
    public (bool IsSuccess, string Message) BorrowBook(Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));

        if (BorrowedBooks.Contains(book))
            return (false, $"The book with title {book.Title} is already borrowed and cannot be borrowed again");

        BorrowedBooks.Add(book);
        return (true, "Book borrowed successfully");
    }
    public (bool IsSuccess, string Message) ReturnBook(Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));

        if (!BorrowedBooks.Contains(book))
            return (false, $"The book with title {book.Title} was not borrowed, so it cannot be returned");

        BorrowedBooks.Remove(book);
        return (true, "Book returned successfully");
    }

    public override bool Equals(object? obj)
    {
        if (obj is Member other)
            return Id == other.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
