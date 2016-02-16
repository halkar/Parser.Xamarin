using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Parser.Parsers.Interface;
using System.Net;

namespace Parser.Parsers
{
    public class WebsiteTitleRetriever : ITitleRetriever
    {
        private readonly Regex _regex = new Regex (@"(?<=<title.*>)([\s\S]*)(?=</title>)");
        private readonly TimeSpan? _timeSpan;

        public WebsiteTitleRetriever (int? seconds = null)
        {
            _timeSpan = seconds.HasValue ? TimeSpan.FromSeconds (seconds.Value) : (TimeSpan?)null;
        }

        public async Task<string> GetLinkTitle (string url)
        {
            var client = new HttpClient ();
            if (_timeSpan.HasValue)
                client.Timeout = _timeSpan.Value;
            try {
                var text = await client.GetStringAsync (url);
                var match = _regex.Match (text);
                return match.Success ? match.Value : null;
            } catch (HttpRequestException) {
                return null;
            } catch (WebException) {
                return null;
            }
        }
    }
}