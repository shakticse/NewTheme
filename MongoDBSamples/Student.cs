using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBSamples
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        public int _id { get; set; }

        public string name { get; set; }

        public List<Score> scores { get; set; }
    }

    public class Score
    {
        public string type { get; set; }

        public double score { get; set; }
    }
}