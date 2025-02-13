
using Banking.Domain;

namespace Banking.Tests.BonusCalculation;
public class TimeBasedBonusCalculatorTests
{
  [Theory]
  [InlineData(5000, 100, 10)]
  [InlineData(5000, 200, 20)]
  [InlineData(10_000, 200, 20)]

  public void BonusesThatMeetThresholdGetBonusIfDuringBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
  {
    var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();
    stubbedBusinessClock.WeAreCurrentlyDuringBusinessHours().Returns(true);
    var bonusCalculator = new TimeBoundBonusCalculator(stubbedBusinessClock);

    decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

    Assert.Equal(expectedBonus, bonus);

  }


  [Theory]
  [InlineData(5000, 100, 0)]
  [InlineData(5000, 200, 0)]
  [InlineData(10_000, 200, 0)]

  public void BonusesThatMeetThresholdGetNoBonusOutsideBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
  {
    var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();
    stubbedBusinessClock.WeAreCurrentlyDuringBusinessHours().Returns(false);
    var bonusCalculator = new TimeBoundBonusCalculator(stubbedBusinessClock);

    decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

    Assert.Equal(expectedBonus, bonus);

  }
  [Theory]
  [InlineData(5, 100, 0)]
  [InlineData(4999.99, 200, 0)]
  [InlineData(0, 1000, 0)]

  public void BonusesBelowThresholdGetnoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
  {
    var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();
    stubbedBusinessClock.WeAreCurrentlyDuringBusinessHours().Returns(true);
    var bonusCalculator = new TimeBoundBonusCalculator(stubbedBusinessClock);
   

    decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

    Assert.Equal(expectedBonus, bonus);

  }
}
