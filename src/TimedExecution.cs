
namespace ConDuck;

public static class TimedExecution
{
    public static Task ExecuteIn(int amount, TimeUnit unit, Delegate routine)
    {
        Task task = new Task(() => {
            Thread.Sleep(TimeUnitMethods.ToMillieseconds(amount, unit));
            routine.DynamicInvoke();
        });
        task.Start();
        return task;
    }

    public static Task ExecuteIn(int amount, Delegate routine)
    {
        Task task = new Task(() => {
            Thread.Sleep(amount);
            routine.DynamicInvoke();
        });
        task.Start();
        return task;
    }

    public static Task ExecuteAt(TimeOfDay tod, Delegate routine)
    {
        Task task = new Task(() => {
            Thread.Sleep(tod.TimeUntil);
            routine.DynamicInvoke();
        });
        task.Start();
        return task;
    }
}