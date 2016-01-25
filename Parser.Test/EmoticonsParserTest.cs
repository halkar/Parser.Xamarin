using NUnit.Framework;
using System.Linq;

namespace Parser.Test
{
    [TestFixture]
    public class EmoticonsParserTest
    {
        [Test]
        public async void TestCase1 ()
        {
            var parser = new EmoticonsParser ();
            var result = (await parser.Parse ("Good morning! (megusta) (coffee)")).ToArray ();
            Assert.AreEqual (2, result.Length);
            Assert.AreEqual ("megusta", result [0]);
            Assert.AreEqual ("coffee", result [1]);
        }

        [Test]
        public async void TestCase2 ()
        {
            var parser = new EmoticonsParser ();
            var result = (await parser.Parse ("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016")).ToArray ();
            Assert.AreEqual (1, result.Length);
            Assert.AreEqual ("success", result [0]);
        }
    }
}

