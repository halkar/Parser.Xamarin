using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Parser.Interface;

namespace Parser
{
    public class LinksParser : IElementParser<Link>
    {
        private static readonly Regex Regex =
            new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");

        private readonly RegexParser _baseParser = new RegexParser(Regex, match => match.Value);
        private readonly ITitleRetriever _titleRetriever;

        public LinksParser(ITitleRetriever titleRetriever)
        {
            _titleRetriever = titleRetriever;
        }

        public async Task<Link[]> Parse(string text)
        {
            var links = await _baseParser.Parse(text);
            var list = new List<Link>();
            foreach (var link in links)
            {
                list.Add(await GetTitle(link));
            }
            return list.ToArray();
        }

        public string Name => "links";

        private async Task<Link> GetTitle(string link)
        {
            var title = await _titleRetriever.GetLinkTitle(link);
            return new Link {title = title, url = link};
        }
    }
}