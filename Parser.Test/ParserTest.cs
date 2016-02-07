using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Parser.Interface;
using Parser.Parsers;
using Parser.Parsers.Interface;

namespace Parser.Test
{
    [TestFixture]
    public class ParserTest
    {
        [TestCase("Good morning! (megusta) (coffee)", "{\"emoticons\":[\"megusta\",\"coffee\"]}")]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", "{\"links\":[{\"url\":\"https://twitter.com/jdorfman/status/430511497475670016\",\"title\":null}],\"emoticons\":[\"success\"],\"mention\":[\"bob\",\"john\"]}")]
        [TestCase("Olympics are starting soon; http://www.nbcolympics.com", "{\"links\":[{\"url\":\"http://www.nbcolympics.com\",\"title\":null}]}")]
        [TestCase("http://login@pass:testurl.com", "{\"links\":[{\"url\":\"http://login@pass:testurl.com\",\"title\":null}]}")]
        public async void TestCasePositive(string text, string expectedResult)
        {
            var mockRetriever = new Mock<ITitleRetriever>(MockBehavior.Strict);
            mockRetriever.Setup(m => m.GetLinkTitle(It.IsAny<string>())).Returns(Task.FromResult((string) null));
            var parser = new Parser(new Serializer(), new List<IElementParser> {new EmoticonsParser(), new MentionsParser(), new LinksParser(mockRetriever.Object)});
            var result = await parser.Parse(text);
            Assert.AreEqual(expectedResult, result);
        }
    }
}