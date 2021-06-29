using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class report : Base
    {
        public int Id { get; set; }
        public string file { get; set; }
        public SubmittedTest SubmittedTest {get;set;}
        public IEnumerable<Reply> replies { get; set; }
    }
}
