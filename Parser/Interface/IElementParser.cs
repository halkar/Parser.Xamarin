using System.Threading.Tasks;

namespace Parser.Interface
{
    public interface IElementParser
    {
        Task<object[]> Parse (string text);

        string Name { get; }
    }
}