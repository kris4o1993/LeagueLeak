using LeagueLeak.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeagueLeak.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
