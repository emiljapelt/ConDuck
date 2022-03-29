using System;
using Xunit;

using ConDuck;

namespace ConDuck.Tests
{
    public class WaiterTest
    {
        [Theory]
        [InlineData(536, TimeUnit.MILLISECONDS, 536)]
        [InlineData(1363, TimeUnit.SECONDS, 1363000)]
        [InlineData(144, TimeUnit.MINUTES, 8640000)]
        [InlineData(15, TimeUnit.HOURS, 54000000)]
        public void IntervalWaiterTests(int amount, TimeUnit unit, int expected)
        {
            Waiter w = WaiterGallery.GetIntervalWaiter(amount, unit);
            Assert.Equal(w(), expected);
        }
    }
}
