using System.Threading.Tasks;

namespace Parser.Parsers.Interface
{
    public interface ITitleRetriever
    {
        Task<string> GetLinkTitle(string url);
    }
}