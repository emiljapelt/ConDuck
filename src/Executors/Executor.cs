
namespace ConDuck;

public abstract class Executor
{
    public abstract Task Execute();
    public abstract void AddRoutine(Routine routine);
    public abstract void AddRoutine(AsyncRoutine routine);
    public abstract void AddRoutine(IRoutine routine);
    public abstract void AddRoutine(IAsyncRoutine routine);
}
