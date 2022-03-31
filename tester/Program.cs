
using ConDuck;

var service = new CustomTimedService(
    () => 1000,
    new ParallelExecutor(),
    null
);

service.AddRoutine(() => System.Console.WriteLine("1"));
service.AddRoutine(async () => await Task.Run(() => {Thread.Sleep(2000); System.Console.WriteLine("2");}));
service.AddRoutine(() => System.Console.WriteLine("3"));

System.Console.WriteLine("Starting");
service.StartService();

while(true);