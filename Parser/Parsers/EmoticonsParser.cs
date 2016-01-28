using System.Text.RegularExpressions;
using Parser.Interface;

namespace Parser.Parsers
{
    public class EmoticonsParser : RegexParser, IElementParser
    {
        public EmoticonsParser () : base (new Regex (@"\(([a-zA-Z0-9]{1,15})\)"))
        {
        }

        public string Name => "emoticons";
    }
}

