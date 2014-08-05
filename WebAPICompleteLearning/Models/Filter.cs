using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICompleteLearning.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Department { get; set; }
    }
}