using System.Threading.Tasks;

namespace Parser.Interface
{
    public interface ITitleRetriever
    {
        Task<string> GetLinkTitle(string url);
    }
}