using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class APIListResponse
    {
        public object metadata { get; set; }
        public List<APIWord> results { get; set; }

    }
}
