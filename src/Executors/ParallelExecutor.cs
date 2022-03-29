
namespace ConDuck;

/// <summary>The <c>ParallelExecutor</c> will use Parallel.ForEach to start execution of all routines at the same time.</summary>
public class ParallelExecutor : Executor
{
    protected List<Delegate> Routines;

    public ParallelExecutor()
    {
        Routines = new List<Delegate>();
    }

    public override void AddRoutine(Delegate routine)
    {
        Routines.Add(routine);
    }

    public override async Task Execute()
    {
        await Task.Run(() => Parallel.ForEach(Routines, routine => {
            routine.DynamicInvoke();
        }));
    }
}
