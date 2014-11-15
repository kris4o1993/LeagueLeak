using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Articles
{
    public class ArticleDetailsViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string ArticleTitle { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }



        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleDetailsViewModel>()
                .ForMember(m => m.ArticleTitle, opt => opt.MapFrom(a => a.Title))
                .ForMember(m => m.Content, opt => opt.MapFrom(a => a.Content))
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(a => a.DateCreated))
                .ReverseMap();
        }
    }
}