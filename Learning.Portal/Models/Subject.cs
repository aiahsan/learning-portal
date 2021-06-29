using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Subject : Base
    {
        public Subject()
        {
            Topics = new HashSet<Topic>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public string Description { get; set; }

    }
}
