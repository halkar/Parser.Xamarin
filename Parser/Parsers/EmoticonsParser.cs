using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Parser.Interface;

namespace Parser.Parsers
{
    public class EmoticonsParser : IElementParser
    {
        private readonly RegexParser _baseParser = new RegexParser(new Regex(@"\(([a-zA-Z0-9]{1,15})\)"));

        public async Task<object[]> Parse(string text)
        {
            return _baseParser.Parse(text);
        }

        public string Remove(string text)
        {
            return _baseParser.Remove(text);
        }

        public string Name => "emoticons";
        public int Order => 100;
    }
}