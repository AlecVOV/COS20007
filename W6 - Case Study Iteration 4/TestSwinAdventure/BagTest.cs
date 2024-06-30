using NUnit.Framework;

namespace SwinAdventure.Test
{
    [TestFixture]
    public class BagTests
    {
        private Bag _bag;
        private Item _belt;
        private Item _gloves;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "bag", "gearbag" }, "Gear Bag", "A bag for carrying martial arts gear");
            _belt = new Item(new string[] { "belt", "vovinam belt" }, "Vovinam Belt", "A blue belt");
            _gloves = new Item(new string[] { "gloves", "training gloves" }, "Training Gloves", "A pair of protective gloves");
            _bag.Inventory.AddItem(_belt);
            _bag.Inventory.AddItem(_gloves);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.AreEqual(_belt, _bag.Locate("belt"));
            Assert.AreEqual(_gloves, _bag.Locate("gloves"));
            Assert.IsTrue(_bag.Inventory.HasItem("belt") != null);
            Assert.IsTrue(_bag.Inventory.HasItem("gloves") != null);
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.AreEqual(_bag, _bag.Locate("bag"));
            Assert.AreEqual(_bag, _bag.Locate("gearbag"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.IsNull(_bag.Locate("nonexistent"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            string expectedDescription = "Item Name: Gear Bag\nDescription: A bag for carrying martial arts gear\nContaining: \tVovinam Belt: belt\n\tTraining Gloves: gloves\n";
            Assert.AreEqual(expectedDescription, _bag.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            Bag innerBag = new Bag(new string[] { "small bag", "pouch" }, "Pouch", "A small pouch for accessories");
            _bag.Inventory.AddItem(innerBag);
            _bag.Inventory.AddItem(_belt);

            Assert.AreEqual(innerBag, _bag.Locate("small bag"));
            Assert.AreEqual(innerBag, _bag.Locate("pouch"));
            Assert.AreEqual(_belt, _bag.Locate("belt"));

            Item handWraps = new Item(new string[] { "handwraps", "wraps" }, "Hand Wraps", "A pair of hand wraps");
            innerBag.Inventory.AddItem(handWraps);

            Assert.AreEqual(handWraps, innerBag.Locate("handwraps"));
            Assert.AreEqual(handWraps, innerBag.Locate("wraps"));
            Assert.IsNull(_bag.Locate("handwraps"));
            Assert.IsNull(_bag.Locate("wraps"));
        }
    }
}
