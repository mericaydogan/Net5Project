using Microsoft.AspNetCore.Identity;
using Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Entity
{
    public class Order:BaseEntity
    {
        public string OrderNumber { get; set; }
        public AppUser User { get; set; }
    }
}
