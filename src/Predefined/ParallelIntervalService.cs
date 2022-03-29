
namespace ConDuck
{
    public class ParallelIntervalService : TimedService
    {
        public ParallelIntervalService(int pauseTime)
        {
            PostWaiter = Delegates.GetIntervalWaiter(pauseTime, TimeUnit.MILLISECONDS);
            Executor = new ParallelExecutor();
        }

        public ParallelIntervalService(int pauseTime, TimeUnit unit)
        {
            PostWaiter = Delegates.GetIntervalWaiter(pauseTime, unit);
            Executor = new ParallelExecutor();
        }
    }
}