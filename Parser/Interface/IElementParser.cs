using System.Threading.Tasks;

namespace Parser.Interface
{
    public interface IElementParser
    {
        Task<object[]> Parse (string text);

        void Remove(ref string text);

        string Name { get; }

        int Order { get; }
    }
}