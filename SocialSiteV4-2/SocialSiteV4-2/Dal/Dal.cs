using SocialSiteV4_2.Models;
using System;
using System.Collections.Generic;
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

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users.Select(x => x).ToList();
        }

        public IEnumerable<Profile> GetProfileList()
        {
            return _context.Profiles.Select(x=>x).ToList();
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.Equals(username));
        }

        public void UpdateProfile(Profile p)
        {
            Profile temp = GetProfile(p.Id);

            temp.Favorite1Data = p.Favorite1Data;
            temp.Favorite1Title = p.Favorite1Title;
            temp.Favorite2Data = p.Favorite2Data;
            temp.Favorite2Title = p.Favorite2Title;
            temp.Favorite3Data = p.Favorite3Data;
            temp.Favorite3Title = p.Favorite3Title;
            temp.ProfileImage = p.ProfileImage;

            _context.SaveChanges();
        }
    }
}