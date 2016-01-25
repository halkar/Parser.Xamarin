using System.Text.RegularExpressions;

namespace Parser
{
    public class MentionsParser : RegexParser, IElementParser<string>
    {
        public MentionsParser () : base (new Regex (@"@(\w+)"))
        {
        }

        public string Name => "mention";
    }
}

