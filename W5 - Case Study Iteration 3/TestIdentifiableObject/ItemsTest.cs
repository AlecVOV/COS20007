namespace SwinAdventure.Test
{
    [TestFixture]
    public class ItemTests
    {
        private Item _itemObject;
        private string[] idents = new[] { "Yellow Belt", "the Honour Belt of the desier" }; 

        [SetUp]
        public void Setup()
        {
            _itemObject = new Item(idents, "Yellow Belt", "A belt which every student in Vovinam want to achieve, after a hard working process of learning.");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.True(_itemObject.AreYou(id: "Yellow Belt")); 
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("Yellow Belt: yellow belt", _itemObject.ShortDescription); 
        }

        [Test]
        public void TestLongDescription()
        { 
            Assert.AreEqual("A belt which every student in Vovinam want to achieve, after a hard working process of learning.", _itemObject.FullDescription); 
        }
    }
}