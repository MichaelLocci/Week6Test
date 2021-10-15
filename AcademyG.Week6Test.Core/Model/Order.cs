using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyG.Week6Test.Core.Model
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime OrderData { get; set; }
        [DataMember]
        public string OderCode { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public decimal Import { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
    }
}
