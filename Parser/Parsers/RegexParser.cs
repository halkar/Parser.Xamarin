using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    public class RegexParser
    {
        private readonly Regex _regex;
        private readonly Func<Match, string> _selector;

        public RegexParser(Regex regex, Func<Match, string> selector)
        {
            _regex = regex;
            _selector = selector;
        }

        public RegexParser(Regex regex) : this(regex, match => match.Groups[1].Value)
        {
        }

        public virtual async Task<string[]> Parse(string text)
        {
            var matchCollection = _regex.Matches(text);
            return matchCollection
                .Cast<Match>()
                .Where(match => match.Success)
                .Select(_selector)
                .ToArray();
        }
    }
}