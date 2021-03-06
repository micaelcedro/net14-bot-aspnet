﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class historicoChat
    {
        public static void inserirMensagem(Logic.SimpleMessage mensagem)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient cl = new MongoClient(connection);
            var db = cl.GetDatabase("BOT");
            var col = db.GetCollection<BsonDocument>("historicoMensagens");

            BsonDocument doc = new BsonDocument()
            {
                {"fromName", mensagem.User},
                {"fromId", mensagem.Id },
                {"mensagem", mensagem.Text}
            };

            col.InsertOne(doc);
        }
    }
}