using NUnit.Framework;
using System.Linq;

namespace Parser.Test
{
    [TestFixture]
    public class MentionsParserTest
    {
        [Test]
        public async void TestCase1 ()
        {
            var parser = new MentionsParser ();
            var result = (await parser.Parse ("@chris you around?")).ToArray ();
            Assert.AreEqual (1, result.Length);
            Assert.AreEqual ("chris", result [0]);
        }

        [Test]
        public async void TestCase2 ()
        {
            var parser = new MentionsParser ();
            var result = (await parser.Parse ("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016")).ToArray ();
            Assert.AreEqual (2, result.Length);
            Assert.AreEqual ("bob", result [0]);
            Assert.AreEqual ("john", result [1]);
        }
    }
}

