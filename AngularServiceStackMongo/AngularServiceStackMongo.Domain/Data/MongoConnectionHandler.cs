namespace AngularServiceStackMongo.Domain
{
    using MongoDB.Driver;

    public class MongoConnectionHandler<T> where T : IEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler()
        {
            const string connectionString = "mongodb://jonathan_dudgeon:jonathan_dudgeon@ds053080.mongolab.com:53080/jonsmongodb";

            //// Get a thread-safe client object by using a connection string
            var mongoClient = new MongoClient(connectionString);

            //// Get a reference to a server object from the Mongo client object
            var mongoServer = mongoClient.GetServer();

            //// Get a reference to the "retrogamesweb" database object
            //// from the Mongo server object
            const string databaseName = "jonsmongodb";
            var db = mongoServer.GetDatabase(databaseName);

            //// Get a reference to the collection object from the Mongo database object
            //// The collection name is the type converted to lowercase + "s"
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}

