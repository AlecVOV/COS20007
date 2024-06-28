namespace SwinAdventure
{
    public class Bag : Item, I_Have_Inventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
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
                string returnDesc = "Item Name: " + this.Name + "\n";
                returnDesc += "Description: " + base.FullDescription + "\n";
                returnDesc += "Containing: " + _inventory.ItemList;
                return returnDesc;
            }
        }

        public Inventory Inventory { get => _inventory; }
    }
}

