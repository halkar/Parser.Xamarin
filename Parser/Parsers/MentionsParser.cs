using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Parser.Interface;

namespace Parser.Parsers
{
    public class MentionsParser : IElementParser
    {
        private readonly RegexParser _baseParser = new RegexParser(new Regex(@"@(\w+)"));

        public async Task<object[]> Parse(string text)
        {
            return _baseParser.Parse(text);
        }

        public string Remove(string text)
        {
            return _baseParser.Remove(text);
        }

        public string Name => "mention";
        public int Order => 100;
    }
}