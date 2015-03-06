using SocialSiteV4_2.Models;
using System;
using System.Linq;
using System.Web;

namespace SocialSiteV4_2.Dal
{
    public class Dal : IDal
    {
        private readonly SocialDbContext _context = new SocialDbContext();
        private static readonly Random Random = new Random();

        public Profile GetRandomProfile()
        {
            return GetProfile(Random.Next(1,_context.Profiles.Count()));
        }

        public Profile GetProfile(int id)
        {
            return _context.Profiles.FirstOrDefault(x => x.Id == id);
        }


        public ApplicationUser GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.Equals(username));
        }
    }
}