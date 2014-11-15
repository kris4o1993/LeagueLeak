using LeagueLeak.Models;
using LeagueLeak.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueLeak.Web.Models
{
    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
                 .ForMember(m => m.Content, opt => opt.MapFrom(c => c.Content))
                 .ForMember(m => m.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                 .ForMember(m => m.DateCreated, opt => opt.MapFrom(c => c.DateCreated))
                 .ReverseMap();
        }
    }
}