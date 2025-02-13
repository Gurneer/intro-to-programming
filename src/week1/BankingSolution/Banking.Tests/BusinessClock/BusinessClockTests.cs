

using Banking.Domain;


using Microsoft.Extensions.Time.Testing;
namespace Banking.Tests.BusinessClock;

public class BusinessClockTests
{

  [Fact]
  public void ReturnsClosedOnSaturdays()
  {
    var testDate = new DateTime(2025, 2, 8);
    var fakeTime = new DateTimeOffset(testDate, TimeSpan.FromHours(-5));

    var fakeTimeProvider = new FakeTimeProvider(fakeTime);
    var clock = new BusinessClockProvider(fakeTimeProvider);

    Assert.False(clock.WeAreCurrentlyDuringBusinessHours());
  }
  [Fact]
  public void ReturnsOpenOnMondays()
  {
    var testDate = new DateTime(2025, 2, 10);
    var fakeTime = new DateTimeOffset(testDate, TimeSpan.FromHours(-5));

    var fakeTimeProvider = new FakeTimeProvider(fakeTime);
    var clock = new BusinessClockProvider(fakeTimeProvider);

    Assert.True(clock.WeAreCurrentlyDuringBusinessHours());
  }

}
