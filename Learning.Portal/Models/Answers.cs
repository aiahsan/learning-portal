using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Answer:Base
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string answer { get; set; }
        [ForeignKey("Test")]
        public int SubmittedTestId { get; set; }
        public SubmittedTest Test { get; set; }
    }
}
