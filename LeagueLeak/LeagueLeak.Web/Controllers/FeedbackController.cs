using AutoMapper;
using LeagueLeak.Data;
using LeagueLeak.Models;
using LeagueLeak.Web.Models.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace LeagueLeak.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        public FeedbackController(IApplicationData data)
            :base(data)
        {
        }

        [HttpGet]
        public ActionResult All()
        {
            var feedbacks = this.Data.Feedbacks.All().Project().To<FeedbackViewModel>().ToList();
            return this.View(feedbacks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new FeedbackViewModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackViewModel feedback)
        {
            if (ModelState.IsValid)
            {
                var author = this.UserProfile;
                var databasebFeedback = Mapper.Map<Feedback>(feedback);
                databasebFeedback.Author = author;
                databasebFeedback.AuthorId = author.Id;
                databasebFeedback.CreationDate = DateTime.Now;

                this.Data.Feedbacks.Add(databasebFeedback);
                this.Data.SaveChanges();

                return this.RedirectToAction("All", "Feedback");
            }

            return this.View(feedback);
        }
    }
}