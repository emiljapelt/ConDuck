
using ConDuck;

var task = TimedExecution.ExecuteIn(2, TimeUnit.HOURS, () => {
    Console.WriteLine("Take the meat of the grill!");
});

while(!task.IsCompleted);