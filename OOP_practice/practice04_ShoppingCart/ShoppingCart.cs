public class ShoppingCart
{
  // property
  public string CustomerName { get; private set; }
  public double TotalPrice { get; private set; }
  public int TotalNumberOfItems { get; private set; }
  public bool IsComplete { get; private set; }

  // constructor
  public ShoppingCart(string customername)
  {
    if (string.IsNullOrWhiteSpace(customername))
    {
      throw new ArgumentException("Customer name must be provided.");
    }

    CustomerName = customername;
    TotalPrice = 0;
    TotalNumberOfItems = 0;
    IsComplete = false;
  }

  // public methods
  public bool AddItem(double unitprice, int numberofitem)
  {
    if (IsComplete)
    {
      Console.WriteLine("Cannot add items after checkout.");
      return false;
    }
    if (!IsValidPrice(unitprice))
    {
      return false;
    }

    TotalPrice += unitprice * numberofitem;
    TotalNumberOfItems += numberofitem;
    return true;
  }

  public bool RemoveItem(double unitprice, int numberofitem)
  {
    if (IsComplete)
    {
      Console.WriteLine("Cannot add items after checkout.");
      return false;
    }
    if (!IsValidPrice(unitprice))
    {
      return false;
    }

    if (IsCartEmpty())
    {
      return false;
    }

    TotalPrice -= unitprice * numberofitem;
    TotalNumberOfItems -= numberofitem;
    return true;
  }

  public bool CheckOut()
  {
    if (IsCartEmpty())
    {
      Console.WriteLine("Cannot checkout because the cart is empty.");
      return false;
    }

    // assign IsComplete to true, return true
    IsComplete = true;
    return true;
    // return IsComplete == true; -> check whether it is true
  }


  public double GetTotalPrice()
  {
    return TotalPrice;
  }

  public int GetItemCount()
  {
    if (IsCartEmpty())
    {
      return 0;
    }
    return TotalNumberOfItems;
  }


  // private methods
  private bool IsValidPrice(double unitprice)
  {
    if (unitprice <= 0)
    {
      throw new ArgumentException("Item price must be greater than 0.");
      return false;
    }
    return true;
  }
  // no parameter needed, should check the cart's won internal state
  private bool IsCartEmpty()
  {
    return TotalNumberOfItems == 0;
  }
}
