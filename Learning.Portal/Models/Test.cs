using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Test : Base
    {
        public Test()
        {
            this.TestQuestions = new HashSet<TestQuestion>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Topic Topic { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
        public ICollection<SubmittedTest> SubmittedTests { get; set; }

    }
}
