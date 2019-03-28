## How to run

This application takes input from a specified file path. To run head to the root directory and run:

`./kata.sh {filePath}`

Use the following command in the root directory to run tests:

`dotnet test`

## Initial Thoughts

When I'm approaching a problem I like to break it down to figure out what the pieces are (revolutionary, I know). Taking a look at the problem statement I came to the conclusion that we are dealing with:

- (Parsing) Input
- (State) Drivers
- (State) Trips
- (Formatting) Report

I'm going to treat this `README` as a tour-guide and touch on the thought process behind things as we run into them. Let's go ahead and start at `Main()`.

**Note**: I did not to put much time into dealing with sad-path scenarios due to time constraints.

## Dealing with input

I chose to accept input via a file path just because it's what I'm familiar with. The `System.File` singleton has a method, `ReadAllLines()`, that will return a `string[]` in which every (new) line of the file is it's own member. Perfect, every line in our input is a command.

### `InputService.GetCommandsFromInput()`
The input that we are dealing with is consistent, meaning we know that the first index will always be the "Action" and everything after is an argument, so splitting each command into an array seemed like a convenient way to handle accessing specific pieces of a it. I chose to return the commands with all of the `Driver` first just to have some explicit order.

### `InputService.CreateObjectFromCommand()`
Since we don't really know what commands we will be asked to execute until runtime, I thought it'd be a good time to do some reflection. I also didn't really know anything about it beyond that and wanted to learn something while doing this exercise. There's also the added bonus of our object creation being genericised-- now when we add that new `RobotDriver` command this method doesn't have to care. 🎉

I left comments in this method because reflection isn't something I see everyday and I didn't want to assume whoever looks at this was in a different boat.
[Reflection Docs](https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection)

## Setting up models

### `Driver`
I chose to keep my Model classes simple as I couldn't think of a reason to abstract them any further. Storing the trips a driver owns on this model felt intuitive, I don't have much to elaborate on there.

### `Trip`
This class is also really simple. I ended up using `TimeSpan` for the start and end points- this struct is used to represent time intervals and has a nifty `.Subtract` method that can be used to calculate time elapsed between two points which is all we really care about for each `Trip`.

I'm calculating the Mph in the constructor just because it's a really simple formula.

### `DriverService.AssociateTripsToDrivers()`
`CreateObjectFromCommand()` leaves us with a mixed-bag of `Driver` and `Trip` that needs to be sorted out. `Enumerable.OfType()` gives us a really convenient way to target a specific type in a collection, in this case it's `Driver`. When we have a list of drivers we can use `OfType()` and `Where()` to easily associate each `Trip` with the `Driver`.

## Reporting
At this point all that's left is formatting our data.

### `Report`
For time's sake I kept this class simple. It seems likely that we may want to save the reports that are generated so having a `Report` class felt right. We can also use this class to define consistent formatting for presentation through `ToString()` overloads.

### `ReportService.CreateReport()`
Now that we have all of our trips assigned to our drivers, it's time to make the data presentable. I chose to keep records simple, but I could definitely see why it'd be nice to have a `Record` class. We are creating a string with the information we are after and adding it to `Report.Records`. After we have all of the records added, we will head back to `Main()` and call the `ToString()` overload on the `Record` to output all records to console.