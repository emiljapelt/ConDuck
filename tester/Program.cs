
using ConDuck;
System.Console.WriteLine("Starting");

var task = TimedExecution.ExecuteAt(new TimeOfDay(10,8), () => {
    Console.WriteLine("I DID IT!");
});

while(!task.IsCompleted);

System.Console.WriteLine("Ending");