using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kata
{
    public static class InputService
    {
        public static IEnumerable<string[]> GetCommandsFromInput(IEnumerable<string> input) =>
            input.Select(x => x.Split(' ')).OrderByDescending(x => x.First() == "Driver");

        public static object CreateObjectFromCommand(string[] cmd)
        {
            // Let's find out what type of object we are going to create
            // eg Kata.Driver or Kata.Trip
            Type type = Type.GetType($"Kata.{cmd[0]}");

            if (type == null) { return null; }

            // These are the arguments that will be passed into the constructor
            // Skipping the first item because it's just the class name
            IEnumerable<string> CtorArgs = cmd.Skip(1);

            // In order for reflection to find the constructor, we need to know
            // the types of all the arguments we want to pass in
            Type[] types = CtorArgs.Select(x => x.GetType()).ToArray();

            // Find the constructor for our Type
            ConstructorInfo ctor = type.GetConstructor(types);

            if (ctor == null) { return null; }

            // Create the object
            return ctor.Invoke(CtorArgs.ToArray());

        }

    }
}