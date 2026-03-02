using Task_01.Classes;

// Create a library
var library = new Library("City Central Library");

// Create books
var book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
var book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
var book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");
var book4 = new Book("The Programmer", "uAndy ", "345-0135957059");

// Add books to library
var res1 = library.AddBook(book1);
if (!res1.IsSuccess)
    System.Console.WriteLine(res1.Message);

var res2 = library.AddBook(book2);
if (!res2.IsSuccess)
    System.Console.WriteLine(res2.Message);

var res3 = library.AddBook(book3);
if (!res3.IsSuccess)
    System.Console.WriteLine(res3.Message);

var res4 = library.AddBook(book4);
if (!res4.IsSuccess)
    System.Console.WriteLine(res4.Message);

// Register members
var member1 = new Member("Alice Johnson");
var member2 = new Member("Bob Smith");

var regRes1 = library.RegisterMember(member1);
if (!regRes1.IsSuccess)
    System.Console.WriteLine(regRes1.Message);
var regRes2 = library.RegisterMember(member2);
if (!regRes2.IsSuccess)
    System.Console.WriteLine(regRes2.Message);

// Display available books
library.DisplayAvailableBooks();

// Member borrows a book
var borrowResult1 = library.BorrowByISBN(member1, "978-0201633610");
if (!borrowResult1.IsSuccess)
    Console.WriteLine(borrowResult1.Message);

var borrowResult2 = library.BorrowByISBN(member1, "978-0132350884");
if (!borrowResult2.IsSuccess)
    Console.WriteLine(borrowResult2.Message);

var borrowResult3 = library.BorrowByISBN(member1, "978-0135957059");
if (!borrowResult3.IsSuccess)
    Console.WriteLine(borrowResult3.Message);

var borrowResult4 = library.BorrowByISBN(member1, "345-0135957059");
if (!borrowResult4.IsSuccess)
    Console.WriteLine(borrowResult4.Message);

// Display available books again
library.DisplayAvailableBooks();

// Member returns a book
var receiveRes1 = library.ReceiveBook(member1, "978-0201633610");
if (!receiveRes1.IsSuccess)
    System.Console.WriteLine(receiveRes1.Message);
