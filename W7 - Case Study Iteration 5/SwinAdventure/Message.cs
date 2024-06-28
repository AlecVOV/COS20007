namespace SwinAdventure
{
    public class Message
    {
        private string _message;

        public Message(string message)
        {
            _message = message;
        }

        public void Print()
        {
            System.Console.WriteLine(_message);
        }
    }
}

