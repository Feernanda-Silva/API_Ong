using System.Collections.Generic;
using API_Ong.Models;
using API_Ong.Utils;
using MongoDB.Driver;

namespace API_Ong.Service
{
    public class PessoaService
    {
        private readonly IMongoCollection<Pessoa> _pessoa;

        public PessoaService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pessoa = database.GetCollection<Pessoa>(settings.PessoaCollectionName);
        }

        public Pessoa Create(Pessoa pessoa)
        {
            _pessoa.InsertOne(pessoa);
            return pessoa;
        }

        public List<Pessoa> Get() => _pessoa.Find<Pessoa>(pessoa => true).ToList();
        public Pessoa Get(string id) => _pessoa.Find<Pessoa>(pessoa => pessoa.Id == id).FirstOrDefault();

        public void Update(string id, Pessoa pessoaIn)
        {
            _pessoa.ReplaceOne(pessoa => pessoa.Id == id, pessoaIn);
        }

        public void Remove(Pessoa pessoaIn) => _pessoa.DeleteOne(pessoa => pessoa.Id == pessoaIn.Id);
    }
}

