namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public Item HasItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                    return item;
            }
            return null;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string id)
        {
            Item itemToRemove = null;
            foreach (var item in _items)
            {
                if (item.AreYou(id.ToLower()))
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }

            return itemToRemove;
        }


        public Item Fetch(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id.ToLower()))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (var i in _items)
                {
                    itemList += i.Name + " :" + i.FullDescription + "\n";
                }
                return itemList;
            }
        }
    }
}
