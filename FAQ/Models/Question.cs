using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQ.Models
{
    public class Questions
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public string navn { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,100}$")]
        public string epost { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9._-]+@[A-Za-z0-9.-_]+\.[A-Za-z.]{4,12}$")]
        public string question { get; set; }
    }
}
