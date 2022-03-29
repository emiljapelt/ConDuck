
namespace ConDuck;

public abstract class TimedService
{
    private Thread Service;
    private bool Halt;
    protected Waiter PreWaiter = WaiterGallery.GetIntervalWaiter(0, TimeUnit.MILLISECONDS);
    protected Waiter PostWaiter = WaiterGallery.GetIntervalWaiter(0, TimeUnit.MILLISECONDS);
    protected Executor Executor;

    public void StartService()
    {
        Halt = false;
        Service = new Thread(async () => {
            await ServiceRoutine();
        });
        Service.Start();
    }

    public void StopService()
    {
        Halt = true;
    }

    public async Task RunOnce()
    {
        await Executor.Execute();
    }

    public void AddRoutine(IRoutine routine) 
    {
        Executor.AddRoutine(new Routine(routine.Execute));
    }
    public void AddRoutine(Routine routine)
    {
        Executor.AddRoutine(routine);
    }
    public void AddRoutine(IAsyncRoutine routine)
    {
        Executor.AddRoutine(new AsyncRoutine(routine.Execute));
    }
    public void AddRoutine(AsyncRoutine routine)
    {
        Executor.AddRoutine(routine);
    }

    private async Task ServiceRoutine()
    {
        while(!Halt)
        {
            Thread.Sleep(PreWaiter());
            await Executor.Execute();
            Thread.Sleep(PostWaiter());
        }
    }
}
