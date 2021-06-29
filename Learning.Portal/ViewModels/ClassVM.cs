using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.ViewModels
{
    public class ClassVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int TopicsCount { get; set; }
    }
}
