using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Entity
{
    public class AppUserRole:IdentityRole<int>
    {
        public string TestProp { get; set; }
    }
}
