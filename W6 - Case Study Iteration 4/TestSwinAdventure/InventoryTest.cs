namespace SwinAdventure.Test
{
    [TestFixture]
    public class InventoryTest
    {
        private Item _uniform;
        private Item _belt;
        private Item _trainingEquipment;
        private Inventory _vovinamInventory;

        [SetUp]
        public void Setup()
        {
            _vovinamInventory = new Inventory();
            _uniform = new Item(new string[] { "blue", "gi", "clothing" }, "Traditional Vovinam uniform", "Worn during practice");
            _belt = new Item(new string[] { "rank", "belt", "sash" }, "Black belt", "Signifies advanced skill level");
            _trainingEquipment = new Item(new string[] { "wooden", "sword", "weapon" }, "Wooden training sword", "Used for practicing techniques");
            _vovinamInventory.AddItem(_uniform);
            _vovinamInventory.AddItem(_belt);
            _vovinamInventory.AddItem(_trainingEquipment);
        }

        [Test]
        public void HasItemTest()
        {
            Assert.That(_vovinamInventory.HasItem("gi"), Is.EqualTo(_uniform));
        }

        [Test]
        public void NoItemFind()
        {
            Assert.That(_vovinamInventory.HasItem("sparring gloves"), Is.EqualTo(null));
        }

        [Test]
        public void FetchItemTest()
        {
            Assert.That(_vovinamInventory.Fetch("wooden"), Is.EqualTo(_trainingEquipment));
        }

        [Test]
        public void TakeItemTest()
        {
            Assert.That(_vovinamInventory.Take("rank"), Is.EqualTo(_belt));
            Assert.That(_vovinamInventory.HasItem("rank"), Is.EqualTo(null));
        }

        [Test]
        public void VovinamInventoryDesc()
        {
            Assert.That(_vovinamInventory.ItemList, Is.EqualTo("\tTraditional Vovinam uniform: blue\n\tBlack belt: rank\n\tWooden training sword: wooden\n"));
        }
    }
}
