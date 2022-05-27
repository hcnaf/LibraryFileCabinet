using FileCabinetApp.Models;

namespace FileCabinetApp.Repositories
{
    public interface IDocumentRepository<T> where T : Document
    {
        IList<T> GetByNumber(int number);
    }
}
