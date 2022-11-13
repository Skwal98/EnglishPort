using Words.API.Entities;

namespace Words.API.Repositories
{
    public interface IWordRepository
    {
        Task<IEnumerable<WordEntity>> GetWordsAsync();
        Task<WordEntity> GetWordById(string id);
        Task<IEnumerable<WordEntity>> GetWordByText(string text);

        Task CreateWord(WordEntity entity);
        Task<bool> UpdateWord(WordEntity entity);
        Task<bool?> DeleteWord(string id);
    }
}
