using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class controleMensagens
    {
        public static void controleDeEnvio(string idUser)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient cl = new MongoClient(connection);
            var db = cl.GetDatabase("BOT");
            var col = db.GetCollection<BsonDocument>("userProfile");

            var filtro = Builders<BsonDocument>.Filter.Eq("idUser", idUser);

            var res = col.Find(filtro).ToList();

            int qtdMsg = 1;

            BsonDocument doc = new BsonDocument()
            {
                {"idUser", idUser},
                {"qtdMsg", qtdMsg}
            };

            col.InsertOne(doc);
        }
    }
}