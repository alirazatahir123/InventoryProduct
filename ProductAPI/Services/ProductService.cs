using MongoDB.Driver;
using ProductAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<tblProduct> _product;
        public ProductService(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _product = database.GetCollection<tblProduct>("tblProduct");
        }

        public List<tblProduct> Get() =>
            _product.Find(product => true).ToList();

        public tblProduct Get(string id) =>
            _product.Find<tblProduct>(product => product.Id == id).FirstOrDefault();

        public tblProduct Create(tblProduct product)
        {
            _product.InsertOne(product);
            return product;
        }
        public void Update(string id, tblProduct productIn) =>
            _product.ReplaceOne(pro => pro.Id == id, productIn);

        public void Remove(tblProduct productIn) =>
            _product.DeleteOne(pro => pro.Id == productIn.Id);

        public void Remove(string id) =>
            _product.DeleteOne(pro => pro.Id == id);
    }
}
