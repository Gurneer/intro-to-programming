namespace Banking.Domain
{
    public class Account
    {
        private decimal _openingBalance = 5000;

        public void Withdraw(decimal amountToWithdraw)
        {
            _openingBalance -= amountToWithdraw;

        }
        public void Deposit(decimal amountToDeposit){
            _openingBalance += amountToDeposit;
        }
        public decimal GetBalance()
        {
            //"slime it"
            return _openingBalance;
        }
    }
}