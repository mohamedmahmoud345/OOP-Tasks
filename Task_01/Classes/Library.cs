namespace Task_01.Classes;

public class Library
{
    public Library(string name)
    {
        Name = name;
        Books = new();
        Members = new();
    }

    public string Name { get; set; }
    private Dictionary<string, Book> Books { get; }
    private HashSet<Member> Members { get; }

    public (bool IsSuccess, string Message) AddBook(Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));
        if (Books.ContainsKey(book.ISBN))
            return (false, "The book is already in the library");

        Books.Add(book.ISBN, book);
        return (true, "Book added successfully");
    }
    public (bool IsSuccess, string Message) RegisterMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));
        Members.TryGetValue(member, out Member member1);
        if (member1 != null)
            return (false, "Member is already registered");

        Members.Add(member);
        return (true, "Member added successfully");
    }

    public (bool IsSuccess, string Message) BorrowByISBN(Member member, string isbn)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        Members.TryGetValue(member, out Member member1);
        if (member1 is null)
            return (false, "Member should register first");

        if (Books.TryGetValue(isbn, out Book book))
        {
            if (!book.IsAvailable)
                return (false, "The book isn't available");

            var borrowResult = member.BorrowBook(book);
            if (!borrowResult.IsSuccess)
                return borrowResult;

            book.Borrow();
        }
        else
            return (false, "Book doesn't exist in library");

        return (true, "Book borrowed successfully");
    }

    public (bool IsSuccess, string Message) ReceiveBook(Member member, string isbn)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        Members.TryGetValue(member, out Member member1);
        if (member1 is null)
            return (false, "Member should register first");

        if (Books.TryGetValue(isbn, out Book book))
        {
            var returnResult = member.ReturnBook(book);
            if (!returnResult.IsSuccess)
                return returnResult;

            book.ReturnBook();
        }
        else
            return (false, "Book doesn't exist in library");

        return (true, "Book returned successfully");
    }

    public void DisplayAvailableBooks()
    {
        var books = Books.Any() ?
                string.Join(",\n", Books.Where(x => x.Value.IsAvailable).Select(x => x.Value.Title)) :
                "None";

        Console.WriteLine(books);
    }
}
