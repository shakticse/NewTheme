using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISYS.Model
{
    [BsonIgnoreExtraElements]
    public class Topic : BaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassName { get; set; }
        public int ClassDisplayOrder { get; set; }
        public string ClassDescription { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public int TotalLesson { get; set; }
        public int TotalSkillTest { get; set; }
    }
}