
using ConDuck;

var service = new CustomTimedService(
    null,
    new SequentialExecutor(),
    Delegates.GetTODWaiter((11,26),(11,28),(11,27))
);

service.AddRoutine(() => System.Console.WriteLine(DateTime.Now));

service.StartService();

while(true);