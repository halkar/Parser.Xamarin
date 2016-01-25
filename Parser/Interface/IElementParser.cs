using System.Threading.Tasks;

namespace Parser
{
    public interface IElementParser<T>
    {
        Task<T[]> Parse (string text);

        string Name { get; }
    }
}