using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            
        public string[] Parse(string text)
        {
            return _regex.Matches(text)
                .Cast<Match>()
                .Where(match => match.Success)
                .Select(_selector)
                .ToArray();
        }

        public string Remove(string text)
        {
            return _regex.Replace(text, "");
        }
    }
}