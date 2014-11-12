using LeagueLeak.Infrastructure.Mapping;
using LeagueLeak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.ViewModels.Home
{
    public class IndexNewsViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }
    }
}