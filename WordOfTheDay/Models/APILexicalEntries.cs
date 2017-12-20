using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class APILexicalEntries
    {
        public List<APIEntry> entries { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }

    }
}
