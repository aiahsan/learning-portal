using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class ParrentTest:Base
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
        [ForeignKey("Test")]
        public int testId { get; set; }

        public Test Test { get; set; }
        public User User { get; set; }

    }
}
