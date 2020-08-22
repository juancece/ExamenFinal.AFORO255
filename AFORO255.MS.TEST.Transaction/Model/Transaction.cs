using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AFORO255.MS.TEST.Transaction.Model
{
    public class Transaction
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int IdTransaction { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}