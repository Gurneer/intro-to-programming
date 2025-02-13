
using Banking.Domain;
using Banking.Tests.TestDoubles;
using NSubstitute;

namespace Banking.Tests.GoldAccounts;
public class GetBonusOnDeposits
{

    [Fact]
    public void GetBonus()
    {
        // Given
        var stubbedBonusCalculator = Substitute.For<ICalculateBonusesForDepositsOnAccounts>();

        var account = new Account(stubbedBonusCalculator);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedBonus = 420.69M;
        stubbedBonusCalculator.CalculateBonusForDeposit(
          openingBalance,
          amountToDeposit).Returns(expectedBonus);

        var expectedNewBalance = openingBalance + amountToDeposit + expectedBonus;

        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(expectedNewBalance, account.GetBalance());
            
    }
}


public class StubbedBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{
  public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
  {
    if(balance == 5000 && depositAmount==  100M)
        {
            return 420.69M;
        }  else
        {
            return 0;
        }
  }
}
