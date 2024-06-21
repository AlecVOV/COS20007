namespace Clock
{
    public class Clock
    {
        private readonly Counter _second;
        private readonly Counter _minute;
        private readonly Counter _hour;
        private const int SEC_LIMIT = 60;
        private const int MIN_LIMIT = 60;

        public Clock()
        {
            _second = new Counter("Second");
            _minute = new Counter("Minute");
            _hour = new Counter("Hour");
        }

        public Counter Second { get { return _second; } }
        public Counter Minute { get { return _minute; } }
        public Counter Hour { get { return _hour; } }

        public void Tick()
        {
            _second.Increment();
            if (_second.Ticks == SEC_LIMIT)
            {
                _second.Reset();
                _minute.Increment();
            }
            if (_minute.Ticks == MIN_LIMIT)
            {
                _minute.Reset();
                _hour.Increment();
            }
        }

        public void Reset()
        {
            _second.Reset();
            _minute.Reset();
            _hour.Reset();
        }

        public string GetCurrentTime()
        {
            return $" {_hour.Ticks.ToString("00")}:{_minute.Ticks.ToString("00")}:{_second.Ticks.ToString("00")}.";
        }
    }
}
