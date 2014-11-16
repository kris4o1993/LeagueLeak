using AutoMapper;
using LeagueLeak.Data;
using LeagueLeak.Models;
using LeagueLeak.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueLeak.Web.Controllers
{
    public class CommentsController : BaseController
    {
        public CommentsController(IApplicationData data)
            :base(data)
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentsViewModel comment)
        {
            if (comment!=null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(comment);
                dbComment.Author = this.UserProfile;
                dbComment.AuthorId = this.UserProfile.Id;
                dbComment.DateCreated = DateTime.Now;
                
                if (dbComment.ArticleId != null)
                {
                    var article = this.Data.Articles.Find(dbComment.ArticleId);
                    article.Comments.Add(dbComment);
                    this.Data.SaveChanges();
                }
                else if (dbComment.GuideId != null)
                {
                    var guide = this.Data.Guides.Find(dbComment.GuideId);
                    guide.Comments.Add(dbComment);
                    this.Data.SaveChanges();
                }
                else if (dbComment.ChampionId != null)
                {
                    var champion = this.Data.Champions.Find(dbComment.ChampionId);
                    champion.Comments.Add(dbComment);
                    this.Data.SaveChanges();
                }
                else
                {
                    throw new HttpException(404, "Not found!");
                }

                var viewModel = Mapper.Map<CommentsViewModel>(dbComment);
                return PartialView("_CommentsSection", viewModel);
            }

            throw new HttpException(500, "Oops! Something bad happened. Try again later or don't do this again");
        }
    }
}