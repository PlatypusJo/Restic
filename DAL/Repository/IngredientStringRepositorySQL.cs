using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class IngredientStringRepositorySQL : IntRepository<IngredientString>
    {
        private Restaurant db;
        public IngredientStringRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(IngredientString item)
        {
            db.IngredientStrings.Add(item);
        }

        public void Delete(int id)
        {
            IngredientString item = db.IngredientStrings.Find(id);
            if (item != null)
                db.IngredientStrings.Remove(item);
        }

        public List<IngredientString> GetAll()
        {
            return db.IngredientStrings.ToList();
        }

        public IngredientString GetItem(int id)
        {
            return db.IngredientStrings.Find(id);
        }

        public void Update(IngredientString item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
