
namespace ConDuck;

public class SplitIntervalService : TimedService
{
    public SplitIntervalService(int pauseTime)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, TimeUnit.MILLISECONDS);
        Executor = new SplitExecutor();
    }

    public SplitIntervalService(int pauseTime, TimeUnit unit)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, unit);
        Executor = new SplitExecutor();
    }
}
