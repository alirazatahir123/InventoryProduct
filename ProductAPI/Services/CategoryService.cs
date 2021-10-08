using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class CategoryService 
    {
        private readonly IMongoCollection<tblCategory> _category;
        public CategoryService(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _category = database.GetCollection<tblCategory>(settings.ProductCollectionName);
        }


        public List<tblCategory> Get() =>
            _category.Find(category => true).ToList();

        public tblCategory Get(string id) =>
            _category.Find<tblCategory>(category => category.Id == id).FirstOrDefault();

        public tblCategory Create(tblCategory category)
        {
            _category.InsertOne(category);
            return category;
        }
        public void Update(string id, tblCategory categoryin) =>
            _category.ReplaceOne(cat => cat.Id == id, categoryin);

        public void Remove(tblCategory categoryin) =>
            _category.DeleteOne(cat => cat.Id == categoryin.Id);

        public void Remove(string id) =>
            _category.DeleteOne(cat => cat.Id == id);
    }
}
