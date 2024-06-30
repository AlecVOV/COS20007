namespace SwinAdventure.Test
{
    [TestFixture]
    public class PlayerTest
    {
        private Player _vovinamStudent;
        private Item _uniform;

        [SetUp]
        public void Setup()
        {
            _vovinamStudent = new Player("Chi Lon Thon", "Dedicated Vovinam Practitioner");
            _uniform = new Item(new string[] { "blue", "gi", "clothing" }, "Traditional Vovinam uniform", "Worn during practice");
            _vovinamStudent.Inventory.AddItem(_uniform);
        }

        [Test]
        public void StudentKnowsThemselves()
        {
            Assert.That(_vovinamStudent.AreYou("Chi Lon Thon"), Is.EqualTo(true));
        }

        [Test]
        public void StudentLocatesItem()
        {
            Assert.That(_vovinamStudent.Locate("gi"), Is.EqualTo(_uniform));
        }

        [Test]
        public void StudentLocatesThemselves()
        {
            Assert.That(_vovinamStudent.Locate("me"), Is.EqualTo(_vovinamStudent));
        }

        [Test]
        public void StudentLocatesNothing()
        {
            Assert.That(_vovinamStudent.Locate("belt"), Is.EqualTo(null));
        }

        [Test]
        public void StudentDescription()
        {
            Assert.That(_vovinamStudent.FullDescription, Is.EqualTo("You are Chi Lon Thon\nYou are known as: Dedicated Vovinam Practitioner\nYou have \tTraditional Vovinam uniform: blue\n"));
        }
    }
}
