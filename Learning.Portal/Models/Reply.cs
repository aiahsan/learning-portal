using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [ForeignKey("Report")]
        public int repotId { get; set; }

        [ForeignKey("User")]
        public int studentId { get; set; }

        public report Report { get; set; }

        public User User { get; set; }
    }
}
