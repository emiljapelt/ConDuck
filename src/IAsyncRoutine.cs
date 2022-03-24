using System.Threading.Tasks;

namespace Chroniker
{
    public interface IAsyncRoutine
    {
        public Task Execute();
    }
}