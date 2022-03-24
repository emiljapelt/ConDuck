using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chroniker
{
    /// <summary>The <c>SequentialExecutor</c> executes all its routines sequentially, awaiting async routines before continuing. </summary> 
    public class SequentialExecutor : Executor
    {
        protected List<Delegate> Routines;

        public SequentialExecutor()
        {
            Routines = new List<Delegate>();
        }

        public override void AddRoutine(Delegate routine)
        {
            Routines.Add(routine);
        }

        public override async Task Execute()
        {
            foreach(Delegate routine in Routines)
            {
                var result = routine.DynamicInvoke();
                if (result is Task task) await task;
            }
        }
    }
}