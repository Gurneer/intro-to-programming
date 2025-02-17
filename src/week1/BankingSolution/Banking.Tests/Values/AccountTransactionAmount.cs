

namespace Banking.Tests.Values;
public class AccountTransactionAmountTests
{
  [Fact]
  public void ThrowsOnNegativeAmount()
  {
    Assert.Throws<AccountNegativeTransactionAmountException>(() =>  AccountTransactionAmount.FromDecimal(-3));
  }

  [Fact]
  public void ThrowsOnAmountsOverThreshold()
  {
    Assert.Throws<AccountTranactionAmountBeyondLimits>(() =>  AccountTransactionAmount.FromDecimal(10_000.01M));
  }

  [Fact]
  public void CanGetValue()
  {
    var amountToDeposit = AccountTransactionAmount.FromDecimal(232.55M);

   

   // var amountToWithdraw = new AccountTransactionAmount(); // this shouldn't be allowed.
    //Assert.Equal(0, amountToWithdraw);

    decimal balance = amountToDeposit;

    AccountTransactionAmount yourPay = 12.23M;

   Assert.Equal<decimal>(232.55M, amountToDeposit);
  }
}
