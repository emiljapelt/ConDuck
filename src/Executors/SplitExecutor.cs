using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConDuck
{
    /// <summary>The <c>SplitExecutor</c> will start all asynchronous routines first, then run all synchronous routines, 
    /// and finally await all the asynchronous routines.</summary>
    public class SplitExecutor : Executor
    {
        protected List<Routine> Routines;
        protected List<AsyncRoutine> AsyncRoutines;

        public SplitExecutor()
        {
            Routines = new List<Routine>();
            AsyncRoutines = new List<AsyncRoutine>();
        }

        public override void AddRoutine(Delegate routine)
        {
            if (routine is AsyncRoutine) {
                AsyncRoutines.Add((AsyncRoutine) routine);
            }
            else if (routine is Routine) {
                Routines.Add((Routine) routine);
            }
        }

        public override async Task Execute()
        {
            List<Task> tasks = new List<Task>();
            foreach(AsyncRoutine routine in AsyncRoutines) tasks.Add(routine());
            foreach(Routine routine in Routines) routine();
            foreach(Task task in tasks) await task;
        } 
    }
}