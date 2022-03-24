using System.Threading;
using System.Threading.Tasks;

namespace Chroniker
{
    public abstract class TimedService
    {
        private Thread Service;
        private bool Halt;
        protected Waiter PreWaiter = Delegates.GetIntervalWaiter(0, TimeUnit.MILLISECONDS);
        protected Waiter PostWaiter = Delegates.GetIntervalWaiter(0, TimeUnit.MILLISECONDS);
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
}