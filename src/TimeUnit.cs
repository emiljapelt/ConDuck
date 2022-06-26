
namespace ConDuck;

public enum TimeUnit
{
    MILLISECONDS,
    SECONDS,
    MINUTES,
    HOURS
}


public static class TimeUnitMethods
{
    public static int ToMillieseconds(int amount, TimeUnit unit)
    {
        switch(unit)
        {
            case TimeUnit.MILLISECONDS:
                return amount;
            case TimeUnit.SECONDS:
                return amount * 1000;
            case TimeUnit.MINUTES:
                return amount * 60000;
            case TimeUnit.HOURS:
                return amount * 3600000;
            default:
                return amount;
        }
    }

    public static int ToMillieseconds(params (int, TimeUnit)[] amounts)
    {
        var accumulator = 0;
        foreach(var (time, unit) in amounts)
        {
            accumulator += ToMillieseconds(time, unit);
        }
        return accumulator;
    }
}
