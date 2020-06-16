using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Db
{
    public class UserApp : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
