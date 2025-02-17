
using System.Reflection.Metadata.Ecma335;

namespace Banking.Domain;

public class AccountTransactionAmount
{
  private readonly decimal _amount;

  //public decimal GetValue()
  //{
  //  return _amount;
  //}
  private decimal Value
  {
    get
    {
      return _amount;
    }

  }

  private AccountTransactionAmount() { } // this just says nobody can use this.
  private AccountTransactionAmount(decimal value)
  {
    if (value < 0)
    {
      throw new AccountNegativeTransactionAmountException();
    }
    if (value > 10_000)
    {
      throw new AccountTranactionAmountBeyondLimits();
    }
    _amount = value;
  }
  public static AccountTransactionAmount FromDecimal(decimal value)
  {
    return new AccountTransactionAmount(value);
  }

  public static AccountTransactionAmount FromInt(int x)
  {
    return new AccountTransactionAmount(x);
  }

  public static AccountTransactionAmount Parse(string amount)
  {
    return new(decimal.Parse(amount));
  }
  public static implicit operator Decimal(AccountTransactionAmount a) => a.Value;

  public static implicit operator AccountTransactionAmount(decimal value) => new(value);
  

}
