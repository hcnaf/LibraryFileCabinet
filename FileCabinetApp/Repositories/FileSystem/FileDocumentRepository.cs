using FileCabinetApp.Models;
using FileCabinetApp.Repositories.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Repositories.FileSystem
{
    public sealed class FileDocumentRepository<T> : IDocumentRepository<T> where T : Document 
    {
        private readonly string _dir;
        private Func<string, (string Type, int Number)> _getFileSignature;
        private Cacher<string, T> _cacher;
        public FileDocumentRepository(string dir, Func<string, (string Type, int Number)> getFileSignature, Cacher<string, T> cacher)
        {
            _dir = Directory.Exists(dir) ? dir : throw new ArgumentException("Directory is incorrect.");
            _getFileSignature = getFileSignature ?? throw new ArgumentNullException(nameof(getFileSignature));
            _cacher = cacher;
        }

        public IList<T> GetByNumber(int number)
        {
            var documents = new List<T>();
            var fileParser = new FileParser<T>(_cacher);
            var files = Directory.GetFiles(_dir).Where(x => _getFileSignature(x).Number == number);
            foreach (var file in files)
            {
                var document = fileParser.GetDocument(file);
                if (document is not null)
                    documents.Add(document);
            }

            return documents;
        }
    }
}
