using Project.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        //Create
        void CreateProduct(Product product);
        //Delete
        void RemoveProduct(Product product);
        //Update
        void UpdateProduct(Product product);
        //Get
        Product Get(int id);



    }
}
