using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyG.Week6Test.Core.Model
{
    public class CustomerConstract
    {

        public int Id { get; set; }

        public string CustomerCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<OrderContract> orderContracts { get; set; }

    }
}
