

using Banking.Domain;
using Banking.Tests.TestDoubles;
using NSubstitute;

namespace Banking.Tests.Accounts;
public class NewAccounts
{
  [Fact]
  public void BalanceIsCorrect()
  {
    var correctOpeningBalance = 5000M;
    // "Write the Code You Wish You Had" - More Corey Haines Wisdom
    var myAccount = new Account(Substitute.For<ICalculateBonusesForDepositsOnAccounts>());
    var yourAccount = new Account(Substitute.For<ICalculateBonusesForDepositsOnAccounts>());

    var myBalance = myAccount.GetBalance();
    decimal yourBalance = yourAccount.GetBalance();

    Assert.Equal(correctOpeningBalance, myBalance);
    Assert.Equal(correctOpeningBalance, yourBalance);
    Assert.Equal(myAccount.GetBalance(), yourAccount.GetBalance());
    myAccount.Deposit(300);

    Assert.NotEqual(myAccount.GetBalance(), yourAccount.GetBalance());


  }
}
