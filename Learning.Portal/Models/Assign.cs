using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Assign:Base
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("User1")]
        public int parrentId { get; set; }
        public string AssignType { get; set; }
        public User User { get; set; }
        public User User1 { get; set; }
      
    }
}
