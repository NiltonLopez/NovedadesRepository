using MongoDB.Driver;
using Novedades.DAL.Mongo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.DAL.Mongo.DataContext
{
    public class Context : IContext
    {
        private readonly IMongoDatabase database;
        public Context(string connectionString, string nombreDb)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase(nombreDb);
        }

        public IMongoCollection<NovedadSQL> Novedades { get => database.GetCollection<NovedadSQL>("Novedades"); } 
    }
}
