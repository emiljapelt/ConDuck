
namespace ConDuck;

/// <summary>The <c>ParallelExecutor</c> will use Parallel.ForEach to start execution of all routines at the same time.</summary>
public class ParallelExecutor : Executor
{
    protected List<Delegate> Routines;

    public ParallelExecutor()
    {
        Routines = new List<Delegate>();
    }

    public override void AddRoutine(Routine routine)
    { Routines.Add(routine); }

    public override void AddRoutine(AsyncRoutine routine)
    { Routines.Add(routine); }

    public override void AddRoutine(IRoutine routine)
    { Routines.Add(routine.Execute); }

    public override void AddRoutine(IAsyncRoutine routine)
    { Routines.Add(routine.Execute); }

    public override async Task Execute()
    {
        await Task.Run(() => Parallel.ForEach(Routines, routine => {
            var result = routine.DynamicInvoke();
            if (result is Task task) task.Wait();
        }));
    }
}
