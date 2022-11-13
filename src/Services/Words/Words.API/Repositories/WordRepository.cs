using Words.API.Data;
using Words.API.Entities;
using MongoDB.Driver;

namespace Words.API.Repositories
{
    public sealed class WordRepository : IWordRepository
    {
        private readonly IWordsContext _context;

        public WordRepository(IWordsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WordEntity>> GetWordsAsync()
        {
            return await _context
                            .Words
                            .Find(x => true)
                            .ToListAsync();
        }

        public async Task<WordEntity> GetWordById(string id)
        {
            return await _context
                            .Words
                            .Find(x => x.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WordEntity>> GetWordByText(string text)
        {
            var filter = Builders<WordEntity>.Filter.ElemMatch(x => x.Text, text);

            return await _context
                            .Words
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateWord(WordEntity entity)
        {
            await _context.Words.InsertOneAsync(entity);
        }

        public async Task<bool?> DeleteWord(string id)
        {
            var filter = Builders<WordEntity>.Filter.Eq(x => x.Id, id);

            var deleteResult = await _context.Words.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateWord(WordEntity entity)
        {
            var updateResult = await _context
                .Words
                .ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
