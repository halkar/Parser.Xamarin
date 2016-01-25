using System.Text.RegularExpressions;

namespace Parser
{
    public class EmoticonsParser : RegexParser, IElementParser<string>
    {
        public EmoticonsParser () : base (new Regex (@"\(([a-zA-Z0-9]{1,15})\)"))
        {
        }

        public string Name => "emoticons";
    }
}

