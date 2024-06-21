using NUnit.Framework;

namespace Clock
{
    [TestFixture]
    public class CounterUnitTest
    {
        Counter c;

        [SetUp]
        public void Setup()
        {
            c = new Counter("Counter test");
        }

        [Test]
        public void TestIncrement()
        {
            for (int i = 0; i < 20; i++)
                c.Increment();
            Assert.AreEqual(20, c.Ticks);
        }

        [Test]
        public void TestReset()
        {
            for (int i = 0; i < 20; i++)
                c.Increment();
            c.Reset();
            Assert.AreEqual(0, c.Ticks);
        }
    }
}