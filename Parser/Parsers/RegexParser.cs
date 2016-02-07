using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.Parsers
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

        public virtual async Task<object[]> Parse(string text)
        {
            var matchCollection = _regex.Matches(text);
            var result = matchCollection
                .Cast<Match>()
                .Where(match => match.Success)
                .Select(_selector)
                .ToArray();
            return result;
        }

        public string Remove(string text)
        {
            return_regex.Replace(text, "");
        }
    }
}