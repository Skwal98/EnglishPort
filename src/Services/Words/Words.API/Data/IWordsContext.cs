using MongoDB.Driver;
using Words.API.Entities;

namespace Words.API.Data
{
    public interface IWordsContext
    {
        IMongoCollection<WordEntity> Words { get; }
    }
}
