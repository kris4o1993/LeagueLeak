namespace LeagueLeak.Web.Controllers
{
    using LeagueLeak.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using LeagueLeak.Web.Models.Articles;
    using LeagueLeak.Web.Models;

    public class ArticlesController : BaseController
    {
        public ArticlesController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Articles
        public ActionResult Details(int id)
        {
            var article = this.Data.Articles.All().Where(a => a.Id == id).Project().To<ArticleDetailsViewModel>().FirstOrDefault();

            var commentsForArticle = this.Data.Comments.All().Where(c => c.ArticleId == id).Project().To<CommentsViewModel>().ToList();
            article.Comments = commentsForArticle;

            return View(article);
        }
    }
}