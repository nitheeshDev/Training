using System.Runtime.Serialization;
namespace Calc
{
    [DataContract]
    public class Calc
    {
        [DataMember]
        public double n1;
        [DataMember]
        public double n2;
    }
}