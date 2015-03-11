using SocialSiteV4_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSiteV4_2.Dal
{
    public interface IDal
    {
        Profile GetRandomProfile();
        Profile GetProfile(int id);

        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<Profile> GetProfileList();

        ApplicationUser GetUserByUsername(string username);

        void UpdateProfile(Profile p);

    }
}
