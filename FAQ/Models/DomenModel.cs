using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQ.Models
{
    public class FAQ
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,100}$")]
        public string question { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,100}$")]
        public string answer { get; set; }
        public int like { get; set; }
        public int dislike { get; set; }
    }
}
