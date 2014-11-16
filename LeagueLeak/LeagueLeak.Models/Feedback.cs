using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
