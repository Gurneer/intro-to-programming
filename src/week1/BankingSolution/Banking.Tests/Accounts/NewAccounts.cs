using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain;

//note: control + period to see an error solution
using Banking.Domain;

namespace Banking.Tests.Accounts;
public class NewAccounts
{
    [Fact]
    public void BalanceIsCorrect()
    {
        var correctOpeningBalance = 5000M;
        // "Write the Code You Wish You Had" - More Corey Haines Wisdom
        var myAccount = new Account();
        var yourAccount = new Account();

        var myBalance = myAccount.GetBalance();
        decimal yourBalance = yourAccount.GetBalance();

        Assert.Equal(correctOpeningBalance, myBalance);
        Assert.Equal(correctOpeningBalance,yourBalance);


    }
}



