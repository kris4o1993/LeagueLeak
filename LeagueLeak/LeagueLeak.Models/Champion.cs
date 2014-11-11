using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Models
{
    public class Champion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public List<string> Roles { get; set; }

        public string ImagePath { get; set; }

        public int Defense { get; set; }

        public int Magic { get; set; }

        public int Difficulty { get; set; }

        public int Attack { get; set; }
    }
}
