using System.Threading.Tasks;

namespace Parser.Interface
{
    public interface IParser
    {
        Task<string> Parse (string text);
    }
}