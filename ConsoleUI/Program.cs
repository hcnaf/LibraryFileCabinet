using FileCabinetApp.Models;
using FileCabinetApp.Repositories;
using FileCabinetApp.Repositories.Cache;
using FileCabinetApp.Repositories.FileSystem;

Console.WriteLine("[LibX] Welcome to cabinet!");
Console.Write("Library directory: ");
var directory = Console.ReadLine();
var bookCacher = new Cacher<string, Book>(10);
IDocumentRepository<Book> bookRepository = new FileDocumentRepository<Book>(directory,
    x =>
    {
        var signature = Path.GetFileNameWithoutExtension(x).Split("_#", 2);
        return (signature[0], int.Parse(signature[1]));
    },
    bookCacher);

while (true)
{
    Console.Write("Number of book: ");
    var number = Console.ReadLine();
    if (string.IsNullOrEmpty(number))
        break;

    var books = bookRepository.GetByNumber(int.Parse(number));

    foreach (var book in books)
        Console.WriteLine(book);
}

var magazineCacher = new Cacher<string, Magazine>(10);
IDocumentRepository<Magazine> magazineRepository = new FileDocumentRepository<Magazine>(directory,
    x =>
    {
        var signature = Path.GetFileNameWithoutExtension(x).Split("_#", 2);
        return (signature[0], int.Parse(signature[1]));
    },
    magazineCacher);

while (true)
{
    Console.Write("Number of magazine: ");
    var number = Console.ReadLine();
    if (string.IsNullOrEmpty(number))
        break;

    var magazines = magazineRepository.GetByNumber(int.Parse(number));

    foreach (var magazine in magazines)
        Console.WriteLine(magazine);
}