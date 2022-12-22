using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class DishOrderRepositorySQL : IntRepository<DishOrder>
    {
        private Restaurant db;
        public DishOrderRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(DishOrder item)
        {
            db.DishOrders.Add(item);
        }

        public void Delete(int id)
        {
            DishOrder item = db.DishOrders.Find(id);
            if (item != null)
                db.DishOrders.Remove(item);
        }

        public List<DishOrder> GetAll()
        {
            return db.DishOrders.ToList();
        }

        public DishOrder GetItem(int id)
        {
            return db.DishOrders.Find(id);
        }

        public void Update(DishOrder item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
