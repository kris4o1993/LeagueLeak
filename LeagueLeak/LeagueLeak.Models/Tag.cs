namespace LeagueLeak.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueLeak.Common.Models;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
