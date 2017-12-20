using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class APISense
    {
        public List<string> definitions { get; set; }
        public List<APIExample> examples { get; set; }
    }
}
