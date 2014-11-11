using LeagueLeak.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Models
{
    public class News : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }



        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
