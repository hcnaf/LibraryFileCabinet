using FileCabinetApp.Models;
using ISBN;
using System.Text.Json;

//var book = new Book()
//{
//    Title = "Title One",
//    Authors = new[]
//    {
//        "Author 1", "Author 2"
//    },
//    DatePublished = DateTime.Now,
//    ISBN = IsbnGenerator.GenerateISBN(),
//    NumberOfPages = 450,
//    Publisher = "ABC",
//};

//using (FileStream fs = new FileStream(@"C:\Users\Anh_Tuan_Phan_Tran\source\repos\FileCabinetApp\Sandbox\GeneratedFiles\book_#312.json", FileMode.OpenOrCreate))
//{
//    await JsonSerializer.SerializeAsync<Book>(fs, book);
//}

var magazine = new Magazine()
{
    Title = "Magazine One",
    DatePublished = DateTime.Now,
    Publisher = "CBA",
    ReleaseNumber = 12
};

using (FileStream fs = new FileStream(@"C:\Users\Anh_Tuan_Phan_Tran\source\repos\FileCabinetApp\Sandbox\GeneratedFiles\magazine_#12.json", FileMode.OpenOrCreate))
{
    await JsonSerializer.SerializeAsync<Magazine>(fs, magazine);
}