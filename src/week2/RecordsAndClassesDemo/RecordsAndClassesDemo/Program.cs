// See https://aka.ms/new-console-template for more information

using RecordsAndClassesDemo;





var manager = new AccountLookupService();


var account1 = await manager.GetAccountByAccountNumberAsync("12");
var account2 = await manager.GetAccountByAccountNumberAsync("12");

// the code is fake, but those two accounts "should" be the same, right?

if(account1.GetBalance() == account2.GetBalance())
{
  Console.WriteLine("They both have the same balance");
}

if(account1.Info == account2.Info)
{
  Console.WriteLine("They have the same information");
  Console.WriteLine(account1);
  Console.WriteLine(account2);
}
else
{
  Console.WriteLine("They have different information");
  Console.WriteLine(account1);
  Console.WriteLine(account2);
}

var info1 = account1.Info;

Console.WriteLine(info1);
var updatedInfo = info1 with { Name = "Jones" };

Console.WriteLine(info1);
Console.WriteLine(updatedInfo);

// const movie = { title: 'Star Wars', yearReleased: 1978 }
// const updatedMovie = {...movie, yearReleased: 1977 }


//Console.Clear();
//Console.Write("Enter the Account Number: ");
//var accountNumber = Console.ReadLine();
//// I'm going to ignore this for now.

//if(accountNumber is null)
//{
//  accountNumber = "99";
//}

//var account = await manager.GetAccountByAccountNumberAsync(accountNumber);


//if (account == null)
//{
//  Console.WriteLine("No Account with That number!");

//} else {
//Console.WriteLine($"The account number is {account.AccountNumber}");



//  Console.WriteLine($"That Account has a balance of {account.GetBalance():c}");
//  Console.WriteLine($"It is owned by {account.Info.Name} ({account.Info.Phone} / {account.Info.Email})");
//  //account.AccountNumber = "tacos";

//  //account.Info.Name = "George Michael";
//  var looping = true;
//  while (looping)
//  {
//    Console.WriteLine("Deposit (D) / Withdrawal (W) / Quit (Q)");
//    Console.WriteLine($"Balance is {account.GetBalance():c} ");
//    var option = Console.ReadLine();

//    switch (option) {

//      case "D":
//        Console.Write("Deposit Amount: ");
//        var depositAmount = Console.ReadLine();
//        if (decimal.TryParse(depositAmount, out var depositVal))
//        {
//          account.Deposit(depositVal);
//        }
//        break;
//      case "W":
//        Console.Write("Withdraw Amount: ");
//        var withdrawalAmountString = Console.ReadLine();
//        if (decimal.TryParse(withdrawalAmountString, out var withdrawalAmount))
//        {
//          account.Withdraw(withdrawalAmount);
//        }
//        break;

//      case "Q":
//        looping = false;
//        break;
//    }
//  }
//}
