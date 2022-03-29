using System.Threading.Tasks;

namespace ConDuck
{
    public interface IAsyncRoutine
    {
        public Task Execute();
    }
}