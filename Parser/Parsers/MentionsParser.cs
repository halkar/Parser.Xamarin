using System.Text.RegularExpressions;
using Parser.Interface;

namespace Parser.Parsers
{
    public class MentionsParser : RegexParser, IElementParser
    {
        public MentionsParser () : base (new Regex (@"@(\w+)"))
        {
        }

        public string Name => "mention";
    }
}

