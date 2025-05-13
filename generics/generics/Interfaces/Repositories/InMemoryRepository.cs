using generics.Interfaces;
namespace generics.Repositories
{
    class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey> {
    private Dictionary<TKey, TEntity> _store = new Dictionary<TKey, TEntity>();

    public void Add(TKey id, TEntity entity) {
        if (_store.ContainsKey(id)) {
            throw new ArgumentException("Entity with the same key already exists.");
        }
        _store[id] = entity;
    }

    public TEntity Get(TKey id) {
        if (_store.TryGetValue(id, out TEntity entity)) {
            return entity;
        }
        throw new KeyNotFoundException("Entity not found.");
    }

    public IEnumerable<TEntity> GetAll() {
        return _store.Values;
    }

    public void Remove(TKey id) {
        if (!_store.Remove(id)) {
            throw new KeyNotFoundException("Entity to remove not found.");
        }
    }
}
}

