using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class historicoChat
    {
        public void inserirMensagem(string fromName, string fromId, string mensagem)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient cl = new MongoClient(connection);
            var db = cl.GetDatabase("BOT");
            var col = db.GetCollection<BsonDocument>("historicoMensagens");

            BsonDocument doc = new BsonDocument()
            {
                {"fromName", fromName},
                {"fromId", fromId },
                {"mensagem", mensagem}
            };

            col.InsertOne(doc);
        }
    }
}