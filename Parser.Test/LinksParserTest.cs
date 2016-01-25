using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Parser.Interface;

namespace Parser.Test
{
    [TestFixture]
    public class LinksParserTest
    {
        [Test]
        public async void TestCase1 ()
        {
            var mock = new Mock<ITitleRetriever>(MockBehavior.Strict);
            mock.Setup(m => m.GetLinkTitle("http://www.nbcolympics.com")).Returns(() => Task.FromResult("Title"));

            var parser = new LinksParser(mock.Object);
            var result = (await parser.Parse ("Olympics are starting soon; http://www.nbcolympics.com")).ToArray ();
            Assert.AreEqual (1, result.Length);
            Assert.AreEqual ("Title", result [0].title);
            Assert.AreEqual ("http://www.nbcolympics.com", result [0].url);
        }

        [Test]
        public async void TestCase2 ()
        {
            var mock = new Mock<ITitleRetriever>(MockBehavior.Strict);
            mock.Setup(m => m.GetLinkTitle("https://twitter.com/jdorfman/status/430511497475670016")).Returns(() => Task.FromResult("Title"));

            var parser = new LinksParser(mock.Object);
            var result = (await parser.Parse ("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016")).ToArray ();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Title", result[0].title);
            Assert.AreEqual("https://twitter.com/jdorfman/status/430511497475670016", result[0].url);
        }
    }
}

