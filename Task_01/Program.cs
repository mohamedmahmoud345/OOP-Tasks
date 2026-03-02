// Create a library
using Task_01.Classes;

var library = new Library("City Central Library");

// Create books
var book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
var book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
var book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");

// Add books to library
library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);

// Register members
var member1 = new Member("Alice Johnson");
var member2 = new Member("Bob Smith");

library.RegisterMember(member1);
library.RegisterMember(member2);

// Display available books
library.DisplayAvailableBooks();

// Member borrows a book
library.BorrowByISBN(member1, "978-0201633610");

// Display available books again
library.DisplayAvailableBooks();

// Member returns a book
library.ReceiveBook(member1, "978-0201633610");
