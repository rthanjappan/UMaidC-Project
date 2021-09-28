using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Wrapper<T>
    {
        [DataMember]
        public List<T> Data { get; set; }
    }

}
