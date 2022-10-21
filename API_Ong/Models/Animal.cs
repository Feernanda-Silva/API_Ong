using MongoDB.Bson.Serialization.Attributes;

namespace API_Ong.Models
{
    public class Animal
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Familia { get; set; }
    }
}
