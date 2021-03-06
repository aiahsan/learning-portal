using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class AssignClass:Base
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }

    }
}
