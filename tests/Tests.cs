using System;
using Xunit;
using NewFAHP.Lib;

using static NewFAHP.Lib.Stat;

namespace NewFAHP.Tests
{
    public class Tests
    {
        [Fact]
        public void CanScalarMultiply()
        {
            var x = (1.0, 2.0, 3.0);
            var y = (1.0, 4.0, 9.0);
            var z = x.ScalarMultiply(y);
            Assert.Equal((1.0, 8.0, 27.0), z);
        }

        [Fact]
        public void CanFuzzyMultiply()
        {
            var x = (1.0, 2.0, 3.0);
            var y = (2.0, 4.0, 6.0);
            var z = x.FuzzyMultiply(y);
            Assert.Equal((2.0, 8.0, 18.0), z);
        }
    }
}
