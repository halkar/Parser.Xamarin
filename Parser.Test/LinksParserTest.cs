using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using Parser.Data;
using Parser.Interface;
using Parser.Parsers;
using Parser.Parsers.Interface;

namespace Parser.Test
{
    [TestFixture]
    public class LinksParserTest
    {
        private const string ExpectedTitle = "Title";

        [TestCase("Olympics are starting soon; http://www.nbcolympics.com", new[] { "http://www.nbcolympics.com" })]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", new[] { "https://twitter.com/jdorfman/status/430511497475670016" })]
        public async void TestCasePositiveMockRetriever(string text, string[] expectedResults)
        {
            var mock = new Mock<ITitleRetriever>(MockBehavior.Strict);
            foreach (var expectedResult in expectedResults)
            {
                mock.Setup(m => m.GetLinkTitle(expectedResult)).Returns(() => Task.FromResult(ExpectedTitle));
            }

            var parser = new LinksParser(mock.Object);
            var result = await parser.Parse(text);
            Assert.AreEqual(expectedResults.Length, result.Length);
            for (var i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(ExpectedTitle, ((Link)result[i]).title);
                Assert.AreEqual(expectedResults[i], ((Link)result[i]).url);
            }
        }

        [TestCase("Olympics are starting soon; http://www.nbco111lympics.com", new[] { "http://www.nbco111lympics.com" })]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", new[] { "https://twitter.com/jdorfman/status/430511497475670016" })]
        public async void TestCasePositiveRealRetriever(string text, string[] expectedResults)
        {
            var parser = new LinksParser(new WebsiteTitleRetriever());
            var result = await parser.Parse(text);
            Assert.AreEqual(expectedResults.Length, result.Length);
            for (var i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], ((Link)result[i]).url);
            }
        }
    }
}

