using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        //"Sheldon: Bazoonga"
        //"Raj: mumble"
        //"Raj: Shouldn't we be inheriting from characters instead of actors since we are the characters not the actors."
        //"Penny: I am a character named Penny from the Big Bang Theory"
        [TestMethod]
        public void PennySpeaks()
        { 
            Penny penny = new Penny();
            string result = penny.Speak();

            Assert.AreEqual("Penny: I am a character named Penny from the Big Bang Theory", result);
        }

        [TestMethod]
        public void SheldonSpeaks()
        {
            Sheldon sheldon = new Sheldon();
            string result = sheldon.Speak();

            Assert.AreEqual("Sheldon: Bazoonga", result);
        }

        [TestMethod]
        public void RajSpeaks_NoWomen()
        {
            Raj raj = new Raj();
            string result = raj.SpeakWithoutWomenPresent();

            Assert.AreEqual("Raj: Shouldn't we be inheriting from characters instead of actors since we are the characters not the actors.", result);
        }

        [TestMethod]
        public void RajSpeaks_Women()
        {
            Raj raj = new Raj();
            string result = raj.SpeakWithWomenPresent();

            Assert.AreEqual("Raj: mumble", result);
        }
    }
}
