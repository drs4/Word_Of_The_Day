using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class APIEntry
    {
        public List<string> etymologies { get; set; }
        public List<APISense> senses { get; set; }

    }
}
