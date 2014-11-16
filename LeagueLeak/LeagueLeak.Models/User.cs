using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Models
{
    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<Guide> guides;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.guides = new HashSet<Guide>();
            this.Points = 0;
        }

        public int Points { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Guide> Guide
        {
            get { return this.guides; }
            set { this.guides = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
