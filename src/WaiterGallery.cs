
namespace ConDuck;

public static class WaiterGallery 
{
    public static Waiter GetIntervalWaiter(int amount, TimeUnit unit)
    {
        return () => TimeUnitMethods.ToMillieseconds(amount, unit);
    }

    public static Waiter GetTODWaiter(params (int, int)[] times)
    {
        var Index = 0;
        var Times = new List<TimeOfDay>();
        foreach((int hour, int minute) in times)
        {
            Times.Add(new TimeOfDay(hour, minute));
        }
        Times.Sort((fst, snd) => {
            if (fst.TimeUntil < snd.TimeUntil) return -1;
            else return 1;
        });
        return () => {
            int time = Times[Index].TimeUntil;
            Index = (Index + 1) % Times.Count;
            return time;
        };
    }
}