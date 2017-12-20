using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class APIMeaningResponse
    {
        public object metadata { get; set; }
        public List<APIMeaning> results { get; set; }


    }
}
