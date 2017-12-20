using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
        public string Comment { get; set; }
    }
}
