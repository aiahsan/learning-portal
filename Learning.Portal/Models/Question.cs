using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Question : Base
    {
        public Question()
        {
            this.TestQuestions = new HashSet<TestQuestion>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Q { get; set; }
        public bool IsMcq { get; set; }
        public bool IsPublic { get; set; }
        public Topic Topic { get; set; }
        public string CorrectAnswer { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
