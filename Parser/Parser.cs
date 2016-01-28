using System.Collections.Generic;
using System.Threading.Tasks;
using Parser.Interface;
using XLabs.Ioc;

namespace Parser
{
    public class Parser:IParser
    {
        private readonly ISerializer _serializer;
        private readonly IList<IElementParser> _parsers; 

        public Parser(ISerializer serializer, IList<IElementParser> parsers)
        {
            _serializer = serializer;
            _parsers = parsers;
        }

        public async Task<string> Parse(string text)
        {
            var root = new Dictionary<string, object>();
            foreach (var parser in _parsers)
            {
                var data = await parser.Parse(text);
                if (data.Length > 0)
                {
                    root[parser.Name] = data;
                }
            }

            return _serializer.ToString(root);
        }
    }
}