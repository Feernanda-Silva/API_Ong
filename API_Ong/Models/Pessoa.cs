using System;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Ong.Models
{
    public class Pessoa
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }  
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
