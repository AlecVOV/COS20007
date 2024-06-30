using Microsoft.VisualStudio.CodeCoverage;
using NUnit.Framework;
using System.ComponentModel;
using System.Numerics;

namespace SwinAdventure.Test
{
    [TestFixture]
    public class LookCommandTest
    {
        LookCommand look;
        Player norStudent, vovStudent;
        Bag bag;

        Item gem = new Item(new string[] { "gem" }, "a gem", "This is shiny red gem");

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            norStudent = new Player("Chi Lon Thon", "Chi's Player"); /*A player with a bag*/
            vovStudent = new Player("Le Hoang Triet Thong", "Thong's Player"); /*A player with no bag*/
            bag = new Bag(new string[] { "bag" }, "a big bag", "It can contain everything.");

            bag.Inventory.AddItem(gem);
            norStudent.Inventory.AddItem(bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.AreEqual("You are Chi Lon Thon\nYou are known as: Chi's Player\nYou have \ta big bag: bag\n", look.Execute(norStudent, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void TestLookAtGem()
        {
            norStudent.Inventory.AddItem(gem);
            Assert.AreEqual("This is shiny red gem", look.Execute(norStudent, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtUnk()
        {
            Assert.AreEqual("Could not find gem", look.Execute(norStudent, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            norStudent.Inventory.AddItem(gem);
            Assert.AreEqual("This is shiny red gem", look.Execute(norStudent, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Assert.AreEqual("This is shiny red gem", look.Execute(norStudent, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestLookAtGemInUnk()
        {
            Assert.AreEqual("Could not find unk", look.Execute(norStudent, new string[] { "look", "at", "gem", "in", "unk" }));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            bag.Inventory.Take("gem");
            Assert.AreEqual("Could not find bag", look.Execute(vovStudent, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual(look.Execute(vovStudent, new string[] { "look", "around" }), "Error in look input.");
            Assert.AreEqual(look.Execute(vovStudent, new string[] { "find", "gem" }), "Error in look input.");
        }
    }
}
