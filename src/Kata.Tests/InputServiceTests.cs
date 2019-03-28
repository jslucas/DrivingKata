using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class InputServiceTests
    {

        [Theory]
        [MemberData(nameof(CommandsFromInputTestCase))]
        public void GetCommandsFromInput(IEnumerable<string> input, List<string[]> expected)
        {
            IEnumerable<string[]> actual = InputService.GetCommandsFromInput(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(ObjectCreationTestCase))]
        public void CreateObjectAndAssignPropertiesFromCommand(string[] command, object expected)
        {
            object actual = InputService.CreateObjectFromCommand(command);

            Assert.NotStrictEqual(expected, actual);
        }

        #region "Test Cases"

        public static List<object[]> CommandsFromInputTestCase =>
            new List<object[]>
            {
                new object[]
                {
                    new string[] {"Driver Asdf","Trip Asdf 07:15 07:45 17.3"},
                    new List<string[]>
                    {
                        new string[] { "Driver", "Asdf" },
                        new string[] { "Trip", "Asdf", "07:15", "07:45", "17.3"}
                    }
                },
                new object[]
                {
                    new string[] {"Trip LargeMarge 17:15 23:41 33.2", "Driver LargeMarge"},
                    new List<string[]>
                    {
                        new string[] { "Driver", "LargeMarge" },
                        new string[] { "Trip", "LargeMarge", "17:15", "23:41", "33.2"}
                    }
                }
            };

        public static List<object[]> ObjectCreationTestCase =>
            new List<object[]>
            {
               new object[] { new string[] {"Driver", "Rom" }, new Driver("Rom") },
               new object[] { new string[] {"Driver", "Quark"}, new Driver("Quark") },
               new object[] { new string[] {"Trip", "Rom", "03:15", "17:45", "157.1"}, new Trip("Rom", "03:15", "17:45", "157.1") },
               new object[] { new string[] {"Trip", "Quark", "06:12", "06:32", "21.8"}, new Trip("Quark", "06:12", "06:32", "21.8") }
            };


        #endregion
    }

}