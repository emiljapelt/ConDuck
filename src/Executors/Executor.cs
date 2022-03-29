
namespace ConDuck;

public abstract class Executor
{
    public abstract Task Execute();
    public abstract void AddRoutine(Delegate routine);
}
