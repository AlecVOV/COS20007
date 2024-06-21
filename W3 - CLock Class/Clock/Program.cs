namespace Clock
{
    internal class Program
    {
        static void PrintClock(Clock clock)
        {
            Console.Clear();
            Console.WriteLine("Clock: ");
            Console.WriteLine(clock.GetCurrentTime());
        }

        static void Main(string[] args)
        {
            const int CLOCK_TICK_DELAY = 300;
            Clock clock = new Clock();

            while (true)
            {
                clock.Tick();
                PrintClock(clock);
                Thread.Sleep(CLOCK_TICK_DELAY);
            }

        }


    }
}

