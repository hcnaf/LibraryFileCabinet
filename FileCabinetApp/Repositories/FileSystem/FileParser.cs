using FileCabinetApp.Models;
using FileCabinetApp.Repositories.Cache;
using Newtonsoft.Json;

namespace FileCabinetApp.Repositories.FileSystem
{
    public sealed class FileParser<T> where T : Document
    {
        public int CashTime
        {
            get => _cacher.CashTime;
            set => _cacher.CashTime = value;
        }

        private Cacher<string, T> _cacher { get; set; }
        public FileParser(Cacher<string, T> cacher)
        {
            _cacher = cacher;
        }

        public T GetDocument(string file)
        {
            if (_cacher.TryGet(file, out var result))
                return result;

            var book = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            if (book is not null)
                _cacher.Add(file, book);

            return book;
        }
    }
}
