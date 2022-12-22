using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class DishRepositorySQL : IntRepository<Dish>
    {
        private Restaurant db;
        public DishRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Dish item)
        {
            db.Dishes.Add(item);
        }

        public void Delete(int id)
        {
            Dish item = db.Dishes.Find(id);
            if (item != null)
                db.Dishes.Remove(item);
        }

        public List<Dish> GetAll()
        {
            return db.Dishes.ToList();
        }

        public Dish GetItem(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Update(Dish item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
