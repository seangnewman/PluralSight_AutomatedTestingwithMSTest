using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    public static class CustomAsserts
    {
        public static void IsInRange(this Assert assert, int actual, int expectedMinimumValue, int expectedMaximumValue)
        {
            if (actual < expectedMinimumValue || actual > expectedMaximumValue)
            {
                throw new AssertFailedException($"{actual} was not in the range  - {expectedMinimumValue} -- {expectedMaximumValue}");
            }
        }

    }
}
