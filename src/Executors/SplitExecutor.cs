
namespace ConDuck;

    /// <summary>The <c>SplitExecutor</c> will start all asynchronous routines first, then run all synchronous routines, 
    /// and finally await all the asynchronous routines.</summary>
public class SplitExecutor : Executor
{
    protected List<Routine> Routines;
    protected List<AsyncRoutine> AsyncRoutines;

    public SplitExecutor()
    {
        Routines = new List<Routine>();
        AsyncRoutines = new List<AsyncRoutine>();
    }

    public override void AddRoutine(Routine routine)
    { Routines.Add(routine); }

    public override void AddRoutine(AsyncRoutine routine)
    { AsyncRoutines.Add(routine); }

    public override void AddRoutine(IRoutine routine)
    { Routines.Add(routine.Execute); }

    public override void AddRoutine(IAsyncRoutine routine)
    { AsyncRoutines.Add(routine.Execute); }

    public override async Task Execute()
    {
        List<Task> tasks = new List<Task>();
        foreach(AsyncRoutine routine in AsyncRoutines) tasks.Add(routine());
        foreach(Routine routine in Routines) routine();
        foreach(Task task in tasks) await task;
    } 
}
