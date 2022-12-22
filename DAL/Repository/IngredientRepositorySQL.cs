﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class IngredientRepositorySQL : IntRepository<Ingredient>
    {
        private Restaurant db;
        public IngredientRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Ingredient item)
        {
            db.Ingredients.Add(item);
        }

        public void Delete(int id)
        {
            Ingredient item = db.Ingredients.Find(id);
            if (item != null)
                db.Ingredients.Remove(item);
        }

        public List<Ingredient> GetAll()
        {
            return db.Ingredients.ToList();
        }

        public Ingredient GetItem(int id)
        {
            return db.Ingredients.Find(id);
        }

        public void Update(Ingredient item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
