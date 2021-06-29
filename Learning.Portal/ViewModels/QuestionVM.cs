using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.ViewModels
{
    public class QuestionVM
    {
        public int Id { get; set; }
        [Display(Name = "Question")]
        public string Title { get; set; }
        public string Q { get; set; }
        public bool IsMcq { get; set; }
        public bool IsPublic { get; set; }

        [Display(Name = "Correct Answer")]
        public string CorrectAnswer { get; set; }
        public int Topic { get; set; }
        public string TopicName { get; set; }
        public int Subject { get; set; }
        public string SubjectName { get; set; }
        public int Class { get; set; }
        public string ClassName { get; set; }
    }

    public class AnswerVM
    {
        public int Question { get; set; }
        public string Answer { get; set; }
    }
}
