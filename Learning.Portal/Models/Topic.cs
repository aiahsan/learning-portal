using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Topic : Base
    {
        public Topic()
        {
            Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; }
        public Class Class { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
