
namespace ConDuck;

/// <summary>The <c>SequentialExecutor</c> executes all its routines sequentially, awaiting async routines before continuing. </summary> 
public class SequentialExecutor : Executor
{
    protected List<Delegate> Routines;

    public SequentialExecutor()
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
        foreach(Delegate routine in Routines)
        {
            var result = routine.DynamicInvoke();
            if (result is Task task) await task;
        }
    }
}
