using FileCabinetApp.Models;

namespace FileCabinetApp.Repositories.Cache
{
    public class Cacher<TKey, TValue> where TKey : notnull where TValue : Document
    {
        private readonly Dictionary<TKey, (TValue Document, DateTime Expiration)> _cache;

        public int CashTime { get; set; }

        public Cacher(int cashTime)
        {
            CashTime = cashTime;
            _cache = new Dictionary<TKey, (TValue Document, DateTime Expiration)>();
        }

        public bool TryGet(TKey key, out TValue document)
        {
            document = null;

            if (_cache.TryGetValue(key, out var result))
            {
                if (result.Expiration > DateTime.Now)
                {
                    document = result.Document;
                    return true;
                }

                _cache.Remove(key);
            }

            return false;
        }

        public void Add(TKey key, TValue document)
        {
            if (CashTime == 0)
                return;

            _cache.Add(key, (document, DateTime.Now.AddMinutes(CashTime)));
        }
    }
}
