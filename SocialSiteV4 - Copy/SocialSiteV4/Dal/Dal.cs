using System;
using System.Linq;
using System.Web;

namespace SocialSiteV4.Dal
{
    public class Dal : IDal
    {
        private readonly SocialDBContext _context = new SocialDBContext();
        private static readonly Random Random = new Random();

        public Profile GetRandomProfile()
        {
            return GetProfile(Random.Next(1,_context.Profiles.Count()));
        }

        public Profile GetProfile(int id)
        {
            return _context.Profiles.FirstOrDefault(x => x.Id == id);
        }


        public AspNetUser GetUserByUsername(string username)
        {
            return _context.AspNetUsers.FirstOrDefault(x => x.UserName.Equals(username));
        }
    }
}