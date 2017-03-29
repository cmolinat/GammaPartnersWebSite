using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
    public class JobComment
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string SubmittedBy { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        [Required, MaxLength(100)]
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime DateSubmitted { get; set; }

        public virtual Job Job { get; set; }
    }
}