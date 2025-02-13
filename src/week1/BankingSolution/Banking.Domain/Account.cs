


namespace Banking.Domain;


public class Account
{
    private ICalculateBonusesForDepositsOnAccounts _bonusCalculator;

  public Account(ICalculateBonusesForDepositsOnAccounts bonusCalculator)
  {
    _currentBalance = 5000M;
    _bonusCalculator = bonusCalculator;
  }

  private decimal _currentBalance;

    // Queries (methods where we ask for stuff)
    public decimal GetBalance()
    { 
        return _currentBalance;
    }
    public void Deposit(decimal amountToDeposit)
    {
        
        CheckTransactionAmount(amountToDeposit);

        var bonus = _bonusCalculator.CalculateBonusForDeposit( _currentBalance, amountToDeposit);
        _currentBalance += amountToDeposit + bonus;
    }

    // Commands - telling our account to do some work.
    public void Withdraw(decimal amountToWithdraw)
    {
        CheckTransactionAmount(amountToWithdraw);
        if (_currentBalance >= amountToWithdraw)
        {
            _currentBalance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }

    }

    // Helpers, etc. extracted from the above.
    private void CheckTransactionAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new AccountNegativeTransactionAmountException();
        }
    }
}


