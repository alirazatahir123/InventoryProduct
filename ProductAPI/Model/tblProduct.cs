using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Model
{
    public class tblProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CategoryName")]
        public string CategoryName { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        public string Description { get; set; }
    }
}
