namespace SwinAdventure
{
    public interface I_Have_Inventory
    {
        GameObject Locate(string id);
        string Name { get; }
    }
}
