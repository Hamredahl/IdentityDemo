using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.Web.Views.Account
{
    public class MembersVM
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FavouriteColour { get; set; } = null!;
        public string SpokenName { get; set; } = null!;
    }
}
