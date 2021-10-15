using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyG.Week6Test.Core.Model
{

    public class OrderContract
    {

        public int Id { get; set; }

        public DateTime OrderData { get; set; }

        public string OderCode { get; set; }

        public string ProductCode { get; set; }

        public decimal Import { get; set; }

        public int CustomerId { get; set; }

        public CustomerConstract CustomerConstract { get; set; }
    }
}
