using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSiteV4.Dal
{
    public interface IDal
    {
        Profile GetRandomProfile();
        Profile GetProfile(int id);

        AspNetUser GetUserByUsername(string username);

    }
}
