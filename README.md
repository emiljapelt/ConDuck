# ConDuck
 
ConDuck (A funky mixup of the word 'Conduct') is a library for controlling the time of execution in C#. It gives some predefined classes, but does also allow for customization. 

The following is an example of a piece of code, which everyday both at 08:30 and at 18:45, remindes the user to do something and then tells the user a joke.

```
using ConDuck;

var service = new CustomTimedService(
    WaiterGallery.GetTODWaiter((8,30),(18,45)),
    new SequentialExecutor(),
    null
);

service.AddRoutine(() => Console.WriteLine("Remember to do something!"));
service.AddRoutine(() => Console.WriteLine(JokeGenerator.Generate()));

service.StartService();

while(true);
```

The following is an example of a piece of code, which gives the user a reminder after two hours.

```
using ConDuck;

var task = TimedExecution.ExecuteIn(2, TimeUnit.HOURS, () => {
    Console.WriteLine("Take the meat of the grill!");
});

while(!task.IsCompleted);
```

The remaining part of this document will give a more indepth explaination of the different parts of ConDuck.

## TimeUnit

This is an enum, representing the time units that ConDuck works with. HOURS, MINUTES, SECONDS AND MILLISECONDS. It also has a static method for turning some amount of one unit, into MILLISECONDS.

## TimeOfDay

This class represents some time of day, in the format hh:mm:ss. Attempting to construct an object, with a time of day that does not exist, will throw an ArgumentExeception. 

Likely the most interresting part of this class is the property TimeUntil, which gives how many milliseconds there are until the specified time occures again.

## TimedExecution

This static class, contain methods for one-off timed executions of delegates. All these methods return the Task that they create, which means that it is possible to wait for the execution to finish. If the delegate returns a value, it wont be acquirable.

| Method | Explaination |
|:-:|:-:|
| ExecuteIn() | Waits the specified amount of time before execution. If no TimeUnit is specifed, milliseconds will be used. |
| ExecuteAt() | Waits until the specifed time of day arrives, before execution. |

## Waiter

This is simply a delegate, which returns some integer value. The class WaiterGallery, contain methods that will return a Waiter.

| Method | Explaination |
|:-:|:-:|
| GetIntervalWaiter | Returns a method, which return a given amount of time, converted to milliseconds. |
| GetTODWaiter | Returns a method which returns the TimeUntil the closest TimeOfDay, of a given list |

## Routine/IRoutine

These are delegates (or an object with a method) that, take no parameters, and return nothing. They also come in asynchronous variants.

## Executor

An object that can get Routines added to it, and has a method for executing those Routines. There are currently three predefined Executors.

| Executor | Explaination |
|:-:|:-:|
| SequentialExecutor | Executes its Routines, in the order that they were added, awaiting asynchronous Routines before moving on. |
| ParallelExecutor | Uses Parallel.ForEach, to execute all its Routines in parallel. All the Routines will finish before the execution is complete. |
| SplitExecutor | Will start execution of asynchronous Routines first, then run synchronous Routines, and finally the asynchronous Routines will be awaited. |

## TimedService

This class allows for repeated timed execution of Routines. It has two Waiters, a pre and a post, aswell as an Executor. The service, when started, will start a loop on a seperate thread, which will wait for however long its pre-Waiter dictates, the Executor will then execute the added Routines, then wait for however long its post-Waiter dictates, and repeat.

Both Waiters default to a Waiter that returns 0.

It is possible to stop the service, although the service will finish what it is doing, including waiting, before stopping.

A few predefined TimedServices are provided, aswell as CustomTimedService for which it is possible to specify the combination of Waiters and Executor, that is required. 