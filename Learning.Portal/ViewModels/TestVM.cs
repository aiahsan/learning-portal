using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.ViewModels
{
    public class TestVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Class { get; set; }
        public string ClassName { get; set; }
        public int Subject { get; set; }
        public string SubjectName { get; set; }
        public string CreatedAt { get; set; }
        public int Topic { get; set; }
        public List<QuestionVM> Questions { get; set; }
    }

    public class TopicVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Class { get; set; }
        public string ClassName { get; set; }
        [Required]
        public int Subject { get; set; }
        public string SubjectName { get; set; }
        public string CreatedAt { get; set; }
        public int QuestionsCount { get; set; }
    }
}
