using NUnit.Framework;

namespace Parser.Test
{
    [TestFixture]
    public class EmoticonsParserTest
    {
        [TestCase("Good morning! (megusta) (coffee)", new[] {"megusta", "coffee"})]
        [TestCase("@bob @john (success) such a cool feature; https://twitter.com/jdorfman/status/430511497475670016", new[] {"success"})]
        public async void TestCasePositive(string text, string[] expectedResults)
        {
            var parser = new EmoticonsParser();
            var result = await parser.Parse(text);
            Assert.AreEqual(expectedResults.Length, result.Length);
            for (var i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], result[i]);
            }
        }
    }
}