using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ISYS.Model
{
    [BsonIgnoreExtraElements]
    public class Post : BaseEntity
    {
        [BsonElement("_id")]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string[] Tags { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public List<Comment> Comments { get; set; }
    }
}