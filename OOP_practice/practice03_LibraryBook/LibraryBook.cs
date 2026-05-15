/*

Class name:
- class LibraryBook{}

Fields/properties:
- public string BookName{get; private set;}
- public string AuthorName{get; private set}
- private bool isBorrowed;
- public string BorrowerName{get; private set;}

Constructor:
- public LibraryBook(string bookname, string authorname){
    // validate book name
    // validate author name
    // assign value
    isBorrowed = false;
}

Public methods:

- public bool BorrowBook(){
  // check is borrowed -> if yes, return false 
  // if no, check borrower name -> not empty, return true
  // return false
}

- public bool ReturnBook(){
  // book becomes available
  // clear borrower name 
}

- public bool IsBorrowed(){
  // return isBooked;
}

- public string GetBookName(string bookname){
  // return book name
}

Private helper methods:

*/
class LibraryBook
{
  // property 
  public string BookTitle
  {
    get; private set;
  }

  public string AuthorName
  {
    get; private set;
  }
  public string BorrowerName { get; private set; }
  public bool IsBorrowed { get; private set; }


  // constructor 
  public LibraryBook(string booktitle, string authorname)
  {
    if (string.IsNullOrWhiteSpace(booktitle))
    {
      throw new ArgumentException("Book title can't be empty.");
    }

    if (string.IsNullOrWhiteSpace(authorname))
    {
      throw new ArgumentException("Author name can't be empty.");
    }

    BookTitle = booktitle;
    AuthorName = authorname;
    // borrower name should only be provided when someone actually borrows the book
    BorrowerName = "";
    IsBorrowed = false;
  }

  // public methods
  public bool BorrowBook(string borrowername)
  {
    if (IsBorrowed)
    {
      Console.WriteLine("This Book is already borrowed.");
      return false;
    }

    if (string.IsNullOrWhiteSpace(borrowername))
    {
      Console.WriteLine("Borrower name must be provided.");
      return false;
    }

    BorrowerName = borrowername;
    IsBorrowed = true;
    return true;
  }

  public bool ReturnBook()
  {
    if (!IsBorrowed)
    {
      return false;
    }

    IsBorrowed = false;
    BorrowerName = "";
    return true;
  }

  public string GetBookTitle()
  {
    return BookTitle;
  }

  public string GetAuthorName()
  {
    return AuthorName;
  }

  public string GetBorrowerName()
  {
    return BorrowerName;
  }

}
