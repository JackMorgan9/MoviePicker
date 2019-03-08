using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePicker.Models.IndexModels
{
    public class IndexModel
    {
        public string type { get; set; }
        
        public string actor { get; set; }

        public string genre { get; set; }

        public string year { get; set; }

        public string sort_by { get; set; }

        public string page { get; set; }
    }
}
