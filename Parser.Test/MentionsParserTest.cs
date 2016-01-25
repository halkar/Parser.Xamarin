using NUnit.Framework;

namespace Parser.Test
{
    [TestFixture]
    public class MentionsParserTest
    {
        [TestCase("@chris you around?", new[] { "chris" })]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", new[] { "bob", "john" })]
        public async void TestCasePositive(string text, string[] expectedResults)
        {
            var parser = new MentionsParser();
            var result = await parser.Parse(text);
            Assert.AreEqual(expectedResults.Length, result.Length);
            for (var i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], result[i]);
            }
        }
    }
}

