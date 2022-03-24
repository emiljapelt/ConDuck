using Xunit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chroniker.Tests
{
    public class ExecutorTest
    {
        [Fact]
        public async Task SequentialExecutorTest()
        {
            var expected = new List<int> {1,2,3,4} ;
            var results = new List<int>();
            var executor = new SequentialExecutor();
            executor.AddRoutine(new Routine(() => {results.Add(1);}));
            executor.AddRoutine(new Routine(() => {results.Add(2);Thread.Sleep(10);}));
            executor.AddRoutine(new Routine(() => {results.Add(3);}));
            executor.AddRoutine(new Routine(() => {results.Add(4);}));

            await executor.Execute();

            Assert.Equal(expected, results);
        }
    }
}