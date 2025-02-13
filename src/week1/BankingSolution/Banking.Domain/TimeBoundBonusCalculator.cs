namespace Banking.Domain;

public class TimeBoundBonusCalculator(IProvideTheBusinessClockForBonusCalculation _businessClock) : ICalculateBonusesForDepositsOnAccounts
{
  //private IProvideTheBusinessClockForBonusCalculation _businessClock;

  //public TimeBoundBonusCalculator(IProvideTheBusinessClockForBonusCalculation businessClock)
  //{
  //  _businessClock = businessClock;
  //}

  public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
  {

    if (_businessClock.WeAreCurrentlyDuringBusinessHours())
    {

      return balance >= 5000 ? depositAmount * .10M : 0;
    } else
    {
      return 0;
    }
  }
}

public interface IProvideTheBusinessClockForBonusCalculation
{
  bool WeAreCurrentlyDuringBusinessHours();
}
