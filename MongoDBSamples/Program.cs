using ISYS.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using System.IO;
using System.Text;

namespace MongoDBSamples
{
    class Program
    {
        public class A
        {
            public virtual void display(int a)
            {
                Console.Write(a);
            }

            public virtual void display(object a)
            {
                Console.Write(a);
            }
        }

        public class B : A
        {
            public override void display(object a)
            {
                Console.Write(a);
            }
        }

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
         
            Console.WriteLine("Hello World!");
        }

        static async Task MainAsync(string[] arg)
        {
            try
            {
                //GetStudentData();
                //A a = new B();
                //a.display(10);

                //Console.ReadKey();

                //var client = new MongoClientSettings { };
                //var connectionString = "mongodb://localhost:27017";
                //var client = new MongoClient(connectionString);
                //var db = client.GetDatabase("AddNSubtract"); // and db setting as another parameter.

                //var connectionString = "mongodb://addnsubtract:fl9Cq2lqbJL5bHyn@cluster0-crpoe.mongodb.net/test?retryWrites=true";

                //var client = new MongoClient("mongodb://addnsubtract:fl9Cq2lqbJL5bHyn@cluster0-shard-00-00-crpoe.mongodb.net:27017,cluster0-shard-00-01-crpoe.mongodb.net:27017,cluster0-shard-00-02-crpoe.mongodb.net:27017/addnsubtract?authSource=admin");
                var client = new MongoClient("mongodb+srv://addnsubtract:fl9Cq2lqbJL5bHyn@cluster0-crpoe.mongodb.net/addnsubtract?retryWrites=true");
                var db = client.GetDatabase("addnsubtract");

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string path = @"C:\Users\SHAKTI\Downloads\CBSESamplePapers6to12.xlsx";

                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    
                    int i = 0;
                    int displayOrder = 0;
                    string className = string.Empty;
                    IExcelDataReader reader;
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    while (reader.Read())
                    {
                        if (className != reader[1].ToString())
                        {
                            ++displayOrder;
                            className = reader[1].ToString();
                        }
                        if (i<=153)
                        {
                            Topic topic = new Topic();
                            topic.ClassName = reader[1].ToString();
                            topic.ClassDescription = reader[1].ToString();
                            topic.ClassDisplayOrder = displayOrder;
                            topic.LessonName = reader[2].ToString();
                            topic.LessonDescription = reader[2].ToString();
                            db.GetCollection<Topic>("topic").InsertOne(topic);
                        }
                        i++;
                    }
                }

                await db.GetCollection<Topic>("topic").FindAsync(new BsonDocument());
                //await db.GetCollection<Topic>("topic").InsertOneAsync(new Topic());

                //var myObj = BsonSerializer.Deserialize<Student>(;

                //var col = await db.GetCollection<Topic>("topic").Find(new BsonDocument()).ToListAsync();

                //var filter = new BsonDocument("type", "homework");//.Add("student_id", 1);            

                //var builder = Builders<BsonDocument>.Filter;
                //var contraint = builder
                //var c = col.Find(new BsonDocument()).Count();
                //foreach (var elm in c)
                //{
                //    col.DeleteOne(elm);
                //}
                //PrintDocument(c);

                //Console.WriteLine(c);


                //var list = await col.Find(filter).Sort("{student_id: 1, score:1 }").ToListAsync();

                ////var studentid = 0;
                ////int prevStudentId = 0;
                //foreach (var doc in list)
                //{
                //    //studentid = DeleteDocument(col, ref prevStudentId, doc);
                //    Console.WriteLine(doc);
                //}

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        private static void ReadExcelData()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1252 = Encoding.GetEncoding(1252);

            string path = @"C:\Users\SHAKTI\Downloads\CBSESamplePapers6to12.xlsx";

            // ReadInData readInData = new ReadInData(@"C:\SC.xlsx", "sc_2014");

            // new ExcelData(path).GetData(worksheetName, isFirstRowAsColumnNames)
            //.Select(dataRow => new Recipient()
            //{
            //    Municipality = dataRow["Municipality"].ToString(),
            //    Sexe = dataRow["Sexe"].ToString(),
            //    LivingArea = dataRow["LivingArea"].ToString()
            //});

            //IEnumerable<Recipient> recipients = readInData.GetData();

            //var file = new FileInfo(path);

            using (
                var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                while (reader.Read())
                {

                }
                
            }

        }

        private static void GetStudentData()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("school");

            //var myObj = BsonSerializer.Deserialize<Student>(;

            var collection = db.GetCollection<Student>("students");

            List <Student> col = db.GetCollection<Student>("students").Find(new BsonDocument()).ToList();

            foreach (var item in col)
            {
                var rec = item.scores.Where(x=>x.type == "homework").Select(x=>x.score).Min();

                var score = item.scores.Where(x => x.score == rec).FirstOrDefault();

                item.scores.Remove(score);

                collection.ReplaceOne(c => c._id == item._id, item);

                //var filter = new BsonDocument("name", item.name);
                //var update = Builders<Student>.Update.PullFilter("scores",
                //    Builders<Student>.Filter.Eq("scores.score", rec));
                //var result = collection.FindOneAndUpdateAsync(filter, update);
                var res = 10;
            }
        }

        private static void PrintDocument(System.Collections.Generic.List<BsonDocument> c)
        {
            foreach (var doc in c)
            {
                Console.WriteLine(doc);
            }
        }

        private static int DeleteDocument(IMongoCollection<BsonDocument> col, ref int prevStudentId, BsonDocument doc)
        {
            int studentid = (int)doc["student_id"];

            if (studentid > 0 && studentid != prevStudentId)
            {
                col.DeleteOne(doc);
                //Console.WriteLine(doc);
            }

            prevStudentId = studentid;
            return studentid;
        }
    }
}
