using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using SocialSiteV4_2.Dal;
using SocialSiteV4_2.Models;

namespace SocialSiteV4_2.Infrastructure
{
    public class AuthorizeSelfAndAttribute : AuthorizeAttribute
    {
        private readonly IDal _dal = new Dal.Dal();
        private string _roles;
        private string[] _rolesSplit = new string[0];
        private string _users;
        private string[] _usersSplit = new string[0];

        public new string Roles
        {
            get { return _roles ?? string.Empty; }
            set
            {
                _roles = value;
                _rolesSplit = SplitString(value);
            }
        }

        public new string Users
        {
            get { return _users ?? string.Empty; }
            set
            {
                _users = value;
                _usersSplit = SplitString(value);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            // check if they have logged in
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            // check if it is their profile
            var routeData = httpContext.Request.RequestContext.RouteData;
            var profileId = int.Parse((string)routeData.Values["id"]);
            Profile profile = _dal.GetProfile(profileId);
            ApplicationUser user2 = _dal.GetUserByUsername(user.Identity.Name);
            routeData.Values["profile"] = profile;
            if (profile.User.Id.Equals(user2.Id))
            {
                return true;
            }

            // check if they are spacified as a user
            if (_usersSplit.Any() && _usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }

            // check if they are spacified as a role
            if (_rolesSplit.Any() && _rolesSplit.Any(user.IsInRole))
            {
                return true;
            }
            return false;
        }

        internal static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
}