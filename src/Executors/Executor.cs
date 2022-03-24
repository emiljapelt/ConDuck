using System;
using System.Threading.Tasks;

namespace Chroniker
{
    public abstract class Executor
    {
        public abstract Task Execute();
        public abstract void AddRoutine(Delegate routine);
    }
}