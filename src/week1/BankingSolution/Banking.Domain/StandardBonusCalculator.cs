
namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{


  public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
  {
    return balance >= 5000 ? depositAmount * .10M : 0;
  }

    public decimal GetBonusForCertificateOfDepositCreation()
    {
        return 5000;
    }
}

