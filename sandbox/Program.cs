
using ConDuck;

var task = TimedExecution.ExecuteIn(TimeUnitMethods.ToMillieseconds((2,TimeUnit.HOURS),(2,TimeUnit.MINUTES)), () => {
    Console.WriteLine("Take the meat of the grill!");
});

while(!task.IsCompleted);