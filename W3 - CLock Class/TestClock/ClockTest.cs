using NUnit.Framework;


namespace Clock
{
    [TestFixture]
    public class ClockUnitTest
    {
        Clock clock;

        [SetUp]
        public void Setup()
        {
            clock = new Clock();
        }

        [Test]
        public void TestTick_Second()
        {
            clock.Tick();
            Assert.AreEqual(1, clock.Second.Ticks);
            Assert.AreEqual(0, clock.Minute.Ticks);
            Assert.AreEqual(0, clock.Hour.Ticks);
        }

        [Test]
        public void TestTick_Minute()
        {
            for (int i = 0; i < 60; i++)
                clock.Tick();
            Assert.AreEqual(0, clock.Second.Ticks);
            Assert.AreEqual(1, clock.Minute.Ticks);
            Assert.AreEqual(0, clock.Hour.Ticks);
        }

        [Test]
        public void TestTick_Hour()
        {
            for (int i = 0; i < 3600; i++)
                clock.Tick();
            Assert.AreEqual(0, clock.Second.Ticks);
            Assert.AreEqual(0, clock.Minute.Ticks);
            Assert.AreEqual(1, clock.Hour.Ticks);
        }

        [TestCase(1)]       // Scenario 1: 00:00:01
        [TestCase(32)]      // Scenario 2: random second
        [TestCase(60)]      // Scenario 3: 00:01:00
        [TestCase(65)]      // Scenario 4: random minute w. second
        [TestCase(3600)]    // Scenario 5: 01:00:00
        [TestCase(5324)]    // Scenario 6: random hour w. second & minute
        public void TestReset(int seconds)
        {
            for (int i = 0; i < seconds; i++)
                clock.Tick();
            clock.Reset();
            Assert.AreEqual(0, clock.Second.Ticks);
            Assert.AreEqual(0, clock.Minute.Ticks);
            Assert.AreEqual(0, clock.Hour.Ticks);
        }

        [Test]
        public void TestGetCurrentTime()
        {
            for (int i = 0; i < 13530; i++)
            {
                clock.Tick();
            }
            Assert.AreEqual(" 03:45:30.", clock.GetCurrentTime());
        }
    }
}
