using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class OrderRepositorySQL : IntRepository<Order>
    {
        private Restaurant db;
        public OrderRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order item = db.Orders.Find(id);
            if (item != null)
                db.Orders.Remove(item);
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Orders.Find(id);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
