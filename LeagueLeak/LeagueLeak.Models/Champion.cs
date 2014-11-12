using LeagueLeak.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Models
{
    public class Champion : AuditInfo
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [Range(1, 10)]
        public int Defense { get; set; }

        [Required]
        [Range(1, 10)]
        public int Magic { get; set; }

        [Required]
        [Range(1, 10)]
        public int Difficulty { get; set; }

        [Required]
        [Range(1, 10)]
        public int Attack { get; set; }
    }
}
