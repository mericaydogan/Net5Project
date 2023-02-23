using Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Entity
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        //Relational Mapping
        public int CategorId { get; set; }
        public virtual Category Category { get; set; } //todo: Lazy Load Nedir?

    }
}
