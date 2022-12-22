using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class CategoryRepositorySQL : IntRepository<Category>
    {
        private Restaurant db;
        public CategoryRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category item = db.Categories.Find(id);
            if (item != null)
                db.Categories.Remove(item);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetItem(int id)
        {
            return db.Categories.Find(id);
        }

        public void Update(Category item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
