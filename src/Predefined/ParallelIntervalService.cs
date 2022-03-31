
namespace ConDuck;

public class ParallelIntervalService : TimedService
{
    public ParallelIntervalService(int pauseTime, TimeUnit unit = TimeUnit.MILLISECONDS)
    {
        PostWaiter = WaiterGallery.GetIntervalWaiter(pauseTime, unit);
        Executor = new ParallelExecutor();
    }
}
