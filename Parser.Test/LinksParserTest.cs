using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using Parser.Interface;

namespace Parser.Test
{
    [TestFixture]
    public class LinksParserTest
    {
        private const string ExpectedTitle = "Title";

        [TestCase("Olympics are starting soon; http://www.nbcolympics.com", new[] { "http://www.nbcolympics.com" })]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", new[] { "https://twitter.com/jdorfman/status/430511497475670016" })]
        public async void TestCasePositive(string text, string[] expectedResults)
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
                Assert.AreEqual(ExpectedTitle, result[i].title);
                Assert.AreEqual(expectedResults[i], result[i].url);
            }
        }
    }
}

