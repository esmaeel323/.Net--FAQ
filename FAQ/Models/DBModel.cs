using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FAQ.Models
{
    public class FAQs
    {
        [Key]
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int like { get; set; }
        public int dislike { get; set; }

    }

   
    

    public class Question
    {
        [Key]
        public int id { get; set; }
        public string navn { get; set; }
        public string epost { get; set; }
        public string question { get; set; }

    }

    public class FAQContext : DbContext
    {
        public FAQContext(DbContextOptions<FAQContext> options)
        : base(options)
        {
            {

            }
        }

        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<Question> Question { get; set; }
      

    }

}
