
namespace Chroniker
{
    public class SplitIntervalService : TimedService
    {
        public SplitIntervalService(int pauseTime)
        {
            PostWaiter = Delegates.GetIntervalWaiter(pauseTime, TimeUnit.MILLISECONDS);
            Executor = new SplitExecutor();
        }

        public SplitIntervalService(int pauseTime, TimeUnit unit)
        {
            PostWaiter = Delegates.GetIntervalWaiter(pauseTime, unit);
            Executor = new SplitExecutor();
        }
    }
}