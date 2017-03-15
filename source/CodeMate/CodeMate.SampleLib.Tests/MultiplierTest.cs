using System;

namespace CodeMate.SampleLib.Tests
{
    using Xunit;

    public class MultiplierTest
    {
        [Fact]
        public void TwoByTwoIsFour()
        {
            Assert.Equal(Multiplier.Multiply(2, 2), 4);
        }

        [Fact]
        public void TwoByTwoIsSix()
        {
            Assert.Equal(Multiplier.Multiply(2, 2), 6);
        }
    }
}
