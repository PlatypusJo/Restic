using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class ChefRepositorySQL : IntRepository<Chef>
    {
        private Restaurant db;
        public ChefRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Chef item)
        {
            db.Chefs.Add(item);
        }

        public void Delete(int id)
        {
            Chef item = db.Chefs.Find(id);
            if (item != null)
                db.Chefs.Remove(item);
        }

        public List<Chef> GetAll()
        {
            return db.Chefs.ToList();
        }

        public Chef GetItem(int id)
        {
            return db.Chefs.Find(id);
        }

        public void Update(Chef item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
