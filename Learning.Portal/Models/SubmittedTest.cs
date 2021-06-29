using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class SubmittedTest : Base
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }

}
