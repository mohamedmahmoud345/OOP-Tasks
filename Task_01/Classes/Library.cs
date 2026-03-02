using Task_01.Classes.HelperMethods;

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

    public Result AddBook(Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));
        if (Books.ContainsKey(book.ISBN))
            return Result.Failure("The book is already in the library");

        Books.Add(book.ISBN, book);
        return Result.Success("Book added successfully");
    }
    public Result RegisterMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));
        Members.TryGetValue(member, out Member member1);
        if (member1 != null)
            return Result.Failure("Member is already registered");

        Members.Add(member);
        return Result.Success("Member added successfully");
    }

    public Result BorrowByISBN(Member member, string isbn)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        Members.TryGetValue(member, out Member member1);
        if (member1 is null)
            return Result.Failure("Member should register first");

        if (Books.TryGetValue(isbn, out Book book))
        {
            if (!book.IsAvailable)
                return Result.Failure("The book isn't available");

            var borrowResult = member.BorrowBook(book);
            if (!borrowResult.IsSuccess)
                return borrowResult;

            book.Borrow();
        }
        else
            return Result.Failure("Book doesn't exist in library");

        return Result.Success("Book borrowed successfully");
    }

    public Result ReceiveBook(Member member, string isbn)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        Members.TryGetValue(member, out Member member1);
        if (member1 is null)
            return Result.Failure("Member should register first");

        if (Books.TryGetValue(isbn, out Book book))
        {
            var returnResult = member.ReturnBook(book);
            if (!returnResult.IsSuccess)
                return returnResult;

            book.ReturnBook();
        }
        else
            return Result.Failure("Book doesn't exist in library");

        return Result.Success("Book returned successfully");
    }

    public void DisplayAvailableBooks()
    {

        var books = Books.Any() ?
                string.Join(",\n", Books.Where(x => x.Value.IsAvailable)
                .Select(x => $"   {x.Value.Title} by {x.Value.Author} (ISBN: {x.Value.ISBN})")) :
                "None";

        System.Console.WriteLine($"Available books in {Name} Library: ");
        Console.WriteLine("{\n" + books + "\n}");
    }
}
