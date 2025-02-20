
namespace RecordsAndClassesDemo;

public class AccountLookupService
{
  // Nullable Reference Types - compiler thing.
  public async Task<Account?> GetAccountByAccountNumberAsync(string accountNumber)
  {

    // Imagine a Database lookup here.
    if(accountNumber == "")
    {
      return null;
    } else
    {
      return new Account
      {
        AccountNumber = accountNumber, // initializez
        Info = new AccountHolderInfo("Bob Smith", "555-1212", "bob@aol.com")
        {
          EmergencyContact = "sue@compuservce"
        }

      };

    }
  }

}

public class Account
{
  private decimal _currentBalance = 5000;

  // makes no sense from a source code level, it is a compiler trick called "Auto Property"

  

  public required string AccountNumber { get; init; } = string.Empty;


  public required AccountHolderInfo Info { get; init; }
  public decimal GetBalance()
  {
    return _currentBalance;
  }

  public void Deposit(decimal amount)
  {
    _currentBalance += amount;
  }
  public void Withdraw(decimal amount)
  {
    _currentBalance -= amount;
  }
}

//public record AccountHolderInfo 
//{
//  public required string Name { get; init; } = string.Empty;
//  public required string Phone { get; init; } = string.Empty;
//  public required string Email { get; init; } = string.Empty;

  
//}

public record AccountHolderInfo(string Name, string Phone, string Email)
{
  public string EmergencyContact { get; init; } = string.Empty;
}

