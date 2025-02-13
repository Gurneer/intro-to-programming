using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Tests.Accounts;
public class DumbTestIntegration
{
  [Fact]
  public void Integrating()
  {
    var account = new Account(new TimeBoundBonusCalculator(new BusinessClockProvider(TimeProvider.System)));

    account.Deposit(999.99M);

    // not sure what to assert on?
    // This is not something you can unit test. 
  }
}
