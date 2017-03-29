using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
    public class JobRequest
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [DisplayName("Name")]
        public string SubmittedBy { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required, MaxLength(12)]
        public string Phone { get; set; }
        [Required, MinLength(10), MaxLength(400)]
        public string Message { get; set; }
        [DisplayName("Date submitted")]
        public DateTime DateSubmitted { get; set; }
        [DisplayName("File")]
        public string FileName { get; set; }
    }
}