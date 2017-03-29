using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StoreMVC.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual JobDetail Details { get; set; }
        public virtual JobCategory Category { get; set; }
        public ICollection<JobComment> Comments { get; set; }
    }
}
