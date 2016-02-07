using Newtonsoft.Json;
using Parser.Interface;

namespace Parser
{
    public class Serializer: ISerializer
    {
        public string ToString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}