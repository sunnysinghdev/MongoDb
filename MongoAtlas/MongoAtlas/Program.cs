using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAtlas
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "*******";
            string database = "mycontacs";
            string connectionString = "mongodb://atlas_gladbeak:"+password
                +
                "@cluster-0-shard-00-00-kmsg7.mongodb.net:27017,cluster-0-shard-00-01-kmsg7.mongodb.net:27017,cluster-0-shard-00-02-kmsg7.mongodb.net:27017/"
                +
                database
                +
                @"?ssl=true&replicaSet=Cluster-0-shard-0&authSource=admin";
            try
            {
                var client = new MongoClient(connectionString);
                //var server = client.GetServer();
                var db = client.GetDatabase("mycontacs");
                GetList(db,client);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
        //public static async void GetList(IMongoDatabase idb, MongoClient mg)
        //{
        //    var list = await mg.ListDatabasesAsync();
        //    Console.WriteLine(list.First());
        //    var db = mg.GetDatabase("mycontacts");
        //    //var db1 = list.First();
        //   // db1.
        //    var lis1t = await db.ListCollectionsAsync();
        //    Console.WriteLine(lis1t.First());// list.Current;
        //    var coll = db.GetCollection<Contacts_Col>("contact_col");
        //    var list3 = await coll.FindAsync(Builders<Contacts_Col>.Filter.Empty);
        //    var list4 = list3.ToList();
        //    foreach (var item in list4)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
        public static async void GetList(IMongoDatabase idb, MongoClient mg)
        {
            var list = await mg.ListDatabasesAsync();
            Console.WriteLine(list.First());
            var db = mg.GetDatabase("bhandara");
            //var db1 = list.First();
            // db1.
            var lis1t = await db.ListCollectionsAsync();
            Console.WriteLine(lis1t.First());// list.Current;
            var coll = db.GetCollection<MotorPart>("inv_motor_parts");
            var list3 = await coll.FindAsync(Builders<MotorPart>.Filter.Empty);
            var list4 = list3.ToList();
            int i = 0;
            foreach (var item in list4)
            {

                Console.WriteLine(item);
                i++;
                if (i > 10)
                    break;
            }
        }
        public class MotorPart
        {
            [MongoDB.Bson.Serialization.Attributes.BsonId]
            public ObjectId _id { get; set; }
            public string ID { get; set; }
            public string Name { get; set; }
            public string BrandName { get; set; }

            public string VehicleType { get; set; }
            
            public string Price { get; set; }
            public string Discount { get; set; }
            
            public override string ToString()
            {
                return ID + " " + Name + " " + BrandName + " " + VehicleType + " " + Price + " " + Discount;
            }

        }
        public class Contacts_Col
        {
            [MongoDB.Bson.Serialization.Attributes.BsonId]
            public ObjectId _id { get; set; }
            public string first { get; set; }
            public string last { get; set; }

            public override string ToString()
            {
                return first + " " + last;
            }

        }
    }
}
