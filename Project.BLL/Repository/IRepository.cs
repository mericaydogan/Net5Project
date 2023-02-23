using Project.Entity.Abstract;
using System.Collections.Generic;

namespace Project.BLL.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        //todo: discontinued alanı true/false olanları listeleme
        //todo: status'a göre verileri listeleme



        //List
        IEnumerable<T> GetAll();
        //Create
        void Insert(T entity);
        //Delete
        void Remove(T entity);
        //Update
        void Update(T entity);
        //Get
        T Get(int id);
        string SaveChanges();

    }
}
