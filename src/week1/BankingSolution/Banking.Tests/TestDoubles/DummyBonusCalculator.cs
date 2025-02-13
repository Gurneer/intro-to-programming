


namespace Banking.Tests.TestDoubles;
public class DummyBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{
  public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
  {
        return 0;
  }
}
