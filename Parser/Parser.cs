using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parser.Interface;

namespace Parser
{
    public class Parser : IParser
    {
        private readonly IList<IElementParser> _parsers;
        private readonly ISerializer _serializer;

        public Parser(ISerializer serializer, IList<IElementParser> parsers)
        {
            _serializer = serializer;
            _parsers = parsers;
        }

        public async Task<string> Parse(string text)
        {
            var root = new Dictionary<string, object>();
            foreach (var parser in _parsers.OrderBy(p => p.Order))
            {
                var data = await parser.Parse(text);
                text = parser.Remove(text);
                if (data.Length > 0)
                {
                    root[parser.Name] = data;
                }
            }

            return _serializer.ToString(root);
        }
    }
}