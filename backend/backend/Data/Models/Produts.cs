﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Data.Models;
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Category { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
