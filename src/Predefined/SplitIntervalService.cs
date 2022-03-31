
namespace ConDuck;

public class SplitIntervalService : TimedService
{
    public SplitIntervalService(int pauseTime, TimeUnit unit = TimeUnit.MILLISECONDS)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, unit);
        Executor = new SplitExecutor();
    }
}
