
namespace Chroniker
{
    public class SplitTODService : TimedService
    {
        public SplitTODService(params (int, int)[] times)
        {
            PreWaiter = Delegates.GetTODWaiter(times);
            Executor = new SplitExecutor();
        }
    }
}