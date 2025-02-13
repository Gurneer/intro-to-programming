namespace Banking.Domain;

public interface ICalculateBonusesForDepositsOnAccounts
{
  decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount);
}