using System;

namespace ConDuck
{
    public class CustomTimedService : TimedService
    {
        public CustomTimedService(Waiter preWaiter, Executor executor, Waiter postWaiter)
        {
            if (preWaiter is not null) PreWaiter = preWaiter;
            if (postWaiter is not null) PostWaiter = postWaiter;
            if (executor is null) throw new ArgumentNullException("Executor cannot be null");
            else Executor = executor;
        }
    }
}