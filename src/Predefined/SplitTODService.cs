
namespace ConDuck;

public class SplitTODService : TimedService
{
    public SplitTODService(params (int, int)[] times)
    {
        PreWaiter = WaiterGallery.GetTODWaiter(times);
        Executor = new SplitExecutor();
    }
}
