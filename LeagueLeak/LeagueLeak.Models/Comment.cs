namespace LeagueLeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
