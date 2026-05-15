using System;

class Program
{
  static void Main()
  {
    Console.WriteLine("=== LibraryBook Test ===");

    LibraryBook book = new LibraryBook("Clean Code", "Robert C. Martin");

    Console.WriteLine("\n--- Initial status ---");
    Console.WriteLine($"Title: {book.GetBookTitle()}");
    Console.WriteLine($"Author: {book.GetAuthorName()}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 1: Borrow book successfully ---");
    bool borrowResult1 = book.BorrowBook("Alice");
    Console.WriteLine($"Borrow result: {borrowResult1}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 2: Try to borrow again ---");
    bool borrowResult2 = book.BorrowBook("Bob");
    Console.WriteLine($"Borrow result: {borrowResult2}");
    Console.WriteLine($"Borrower should still be Alice: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 3: Return book successfully ---");
    bool returnResult1 = book.ReturnBook();
    Console.WriteLine($"Return result: {returnResult1}");
    Console.WriteLine($"Borrower should be empty: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 4: Try to return again ---");
    bool returnResult2 = book.ReturnBook();
    Console.WriteLine($"Return result: {returnResult2}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 5: Try to borrow with empty borrower name ---");
    bool borrowResult3 = book.BorrowBook("");
    Console.WriteLine($"Borrow result: {borrowResult3}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 6: Try to borrow with whitespace borrower name ---");
    bool borrowResult4 = book.BorrowBook("   ");
    Console.WriteLine($"Borrow result: {borrowResult4}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n--- Test 7: Borrow again after return ---");
    bool borrowResult5 = book.BorrowBook("Charlie");
    Console.WriteLine($"Borrow result: {borrowResult5}");
    Console.WriteLine($"Borrower: '{book.GetBorrowerName()}'");
    Console.WriteLine($"Is borrowed: {book.IsBorrowed}");

    Console.WriteLine("\n=== Test finished ===");
  }
}
