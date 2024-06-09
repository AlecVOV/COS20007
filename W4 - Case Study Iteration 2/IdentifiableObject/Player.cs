namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) :base (new string [] {"me", name, "inventory"}, name, desc ) 
        {
            _inventory = new Inventory();
        }

        public GameObject Locate (string id)
        {
            if (this.AreYou(id.ToLower()))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                string returnDescription = "You are " + this.Name + "\n" + "You are known as: " + base.FullDescription + "\n" + "You have " + _inventory.ItemList;
                return returnDescription;
            }
        }
        public Inventory Inventory { get => _inventory; }
    }
}



