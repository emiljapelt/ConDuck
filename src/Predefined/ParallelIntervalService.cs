
namespace ConDuck;

public class ParallelIntervalService : TimedService
{
    public ParallelIntervalService(int pauseTime)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, TimeUnit.MILLISECONDS);
        Executor = new ParallelExecutor();
    }

    public ParallelIntervalService(int pauseTime, TimeUnit unit)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, unit);
        Executor = new ParallelExecutor();
    }
}
