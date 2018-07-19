using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISYS.Model
{
    [BsonIgnoreExtraElements]
    public class Class:BaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int ClassDisplayOrder { get; set; }
    }
}
