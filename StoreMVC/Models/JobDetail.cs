using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
    public class JobDetail
    {
        [Key, ForeignKey("Job")]
        public int JobId { get; set; }
        [DisplayName("Full Description")]
        public string LongDesctiption { get; set; }
        public decimal Price { get; set; }
        public bool Finished { get; set; }

        public virtual Job Job { get; set; }
    }
}