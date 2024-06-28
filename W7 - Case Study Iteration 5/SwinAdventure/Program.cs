namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Case Study Interation 5 - Typing it Together");
            Console.WriteLine("=============================================");
            Console.Write("Enter player's name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("=============================================");
            Console.Write("Enter player's description: ");
            string playerDesc = Console.ReadLine();
            Console.WriteLine("=============================================");

            Player player = new Player(playerName, playerDesc);
            player.Inventory.AddItem(new Item(new string[] { "sword" }, "A sword", "A sharp sword"));
            player.Inventory.AddItem(new Item(new string[] { "shield" }, "A shield", "A strong shield"));
            Bag bag = new Bag(new string[] { "bag" }, "A bag", "A leather bag");
            player.Inventory.AddItem(bag);
            bag.Inventory.AddItem(new Item(new string[] { "apple" }, "An apple", "A juicy apple"));

            Console.WriteLine(player.FullDescription);
            Console.WriteLine(bag.FullDescription);

            LookCommand look = new LookCommand();
            bool quit = false;
            while (!quit)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                string[] commandParts = command.Split(' ');
                if (commandParts[0] == "quit")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine(look.Execute(player, commandParts));
                }
            }
        }
    }
}
