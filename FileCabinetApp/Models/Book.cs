using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Models
{
    public class Book : Document
    {
        public string[] Authors { get; set; }
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
            => $"{this.Title} (ISBN: {this.ISBN}) Published {this.DatePublished} by {this.Publisher} with {this.NumberOfPages} pages.";
    }
}
