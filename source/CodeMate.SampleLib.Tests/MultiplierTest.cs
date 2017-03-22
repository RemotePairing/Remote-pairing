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
        public void TwoByThreeIsSix()
        {
            Assert.Equal(Multiplier.Multiply(2, 3), 6);
        }
    }
}