using System.Runtime.Serialization;

namespace Utilities.Peticiones
{
    [DataContract]
    public class Mensaje<T>
    {
        [DataMember(Name = "IsSucess")]
        public bool IsSucess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }
    }
}
