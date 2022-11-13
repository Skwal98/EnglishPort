using MongoDB.Driver;
using Words.API.Entities;

namespace Words.API.Data
{
    public sealed class WordsContext : IWordsContext
    {
        public IMongoCollection<WordEntity> Words { get; }

        public WordsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Words = database.GetCollection<WordEntity>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
    }
}
