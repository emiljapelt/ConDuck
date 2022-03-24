using System.Threading.Tasks;
using System.Collections.Generic;

namespace Chroniker
{
    public delegate void Routine();
    public delegate Task AsyncRoutine();
    public delegate int Waiter();

    public static class Delegates
    {
        public static Waiter GetIntervalWaiter(int amount, TimeUnit unit)
        {
            switch(unit)
            {
                case TimeUnit.MILLISECONDS:
                    return () => amount;
                case TimeUnit.SECONDS:
                    return () => amount * 1000;
                case TimeUnit.MINUTES:
                    return () => amount * 60000;
                case TimeUnit.HOURS:
                    return () => amount * 3600000;
                default:
                    return () => amount;
            }
        }

        public static Waiter GetTODWaiter(params (int, int)[] times)
        {
            var Index = 0;
            var Times = new List<TimeOfDay>();
            foreach((int hour, int minute) in times)
            {
                Times.Add(new TimeOfDay(hour, minute));
            }
            return () => {
                int time = Times[Index].TimeUntil();
                Index = (Index + 1) % Times.Count;
                return time;
            };
        }
    }
}