using System.Collections.Generic;
using API_Ong.Models;
using API_Ong.Utils;
using MongoDB.Driver;

namespace API_Ong.Service
{
    public class AnimalService
    {
        private readonly IMongoCollection<Animal> _animals; 

        public AnimalService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _animals = database.GetCollection<Animal>(settings.AnimalCollectionName);
        }

        public Animal Create(Animal animal)
        {
            _animals.InsertOne(animal);
            return animal;
        }

        public List<Animal> Get() => _animals.Find<Animal>(animal => true).ToList();
        public Animal Get(string id) => _animals.Find<Animal>(animal => animal.Id == id).FirstOrDefault();
        
        public void Update(string id, Animal animalIn)
        {
            _animals.ReplaceOne(animal => animal.Id == id, animalIn);
        }

        public void Remove(Animal animalIn) => _animals.DeleteOne(animal => animal.Id == animalIn.Id);
    }
}

