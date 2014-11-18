using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Articles
{
    public class ArticleDetailsViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }

        public string Content { get; set; }

        public ICollection<CommentsViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleDetailsViewModel>()
                .ForMember(m => m.ArticleTitle, opt => opt.MapFrom(a => a.Title))
                .ForMember(m => m.Content, opt => opt.MapFrom(a => a.Content))
                .ReverseMap();
        }
    }
}