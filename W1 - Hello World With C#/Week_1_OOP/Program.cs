namespace HelloWorld
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greeting from Message Object.");

            myMessage.Print();

            Console.WriteLine("------------------------------------------");
            //Create a list of greeting
            List<Message> messages = new List<Message>
            {
            new Message("Nice to meet you again!!!"),
            new Message("How ya doing"),
            new Message("Ayyo what's up"),
            new Message("Good to see ya mate!!!"),
            new Message("It's always a pleasure to see you")
            };


            //Ask users to input their name
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            //Output the corresponding greeting
            if (name.ToLower() == "wilma")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "fred")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "peter")
            {
                messages[2].Print();
            }
            else if (name.ToLower() == "john")
            {
                messages[3].Print();
            }
            else 
            {
                messages[4].Print();
            }
        }
    }
}


