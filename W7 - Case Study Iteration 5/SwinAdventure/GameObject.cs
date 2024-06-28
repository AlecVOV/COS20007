namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;
   

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name { get => _name; }
        public virtual string FullDescription { get => _description; }

        public string ShortDescription { get => $"{Name}: {FirstID}"; }
    }
}
