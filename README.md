# ConDuck
 
ConDuck (A funky mixup of the word 'Conduct') is a library for controlling the time of execution for code. It gives some predefined classes, but does also allow for customization. 

The following sections will explain the different classes and types of ConDuck.

## TimeUnit

This is an enum, representing the timeunits that ConDuck works with. HOURS, MINUTES, SECONDS AND MILLISECONDS. It also has a static method for turning some amount of one unit, into MILLISECONDS.

## TimeOfDay

This class represents some time of day, in the format hh:mm:ss. Constructing the class without a definition for seconds, will set the seconds to 0. Likely the most interresting part of this class is TimeUntil, which gives how many milliseconds there are until the specified time occures again.

## TimedExecution

This static class, contain methods for one-off timed executions of delegates. All these methods return the Task that they create, which means that it is possible to wait for the execution to finish. If the delegate returns a value, it wont be acquirable.

### ExecuteIn()

Waits the specified amount of time before execution. If no TimeUnit is specifed, milliseconds will be used.

### ExecuteAt()

Waits until the specifed time of day arrives, before execution.

## Waiter

This is simply a delegate, which returns some integer value.

## Routine

## Executor