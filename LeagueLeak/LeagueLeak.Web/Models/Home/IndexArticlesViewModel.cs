using AutoMapper;
using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models.Home
{
    public class IndexArticlesViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ArticleTitle { get; set; }

        public int NumberOfComments { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, IndexArticlesViewModel>()
                .ForMember(m => m.ArticleTitle, opt => opt.MapFrom(a => a.Title))
                .ForMember(m => m.NumberOfComments, opt => opt.MapFrom(a => a.Comments.Count()))
                .ReverseMap();
        }
    }
}