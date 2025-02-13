namespace Banking.Domain;

public class BusinessClockProvider(TimeProvider _clock) : IProvideTheBusinessClockForBonusCalculation
{
  public bool WeAreCurrentlyDuringBusinessHours()
  {

    var dayOfTheWeek = _clock.GetLocalNow().DayOfWeek;
    if(dayOfTheWeek == DayOfWeek.Saturday)
    {
      return false;
    }
    if (dayOfTheWeek == DayOfWeek.Monday)
    {
      return true;
    }
    return false;
  }
}
