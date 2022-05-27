using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Models
{
    public class LocalizedBook : Book
    {
        public string LocalCountry { get; set; }
        public string LocalPublisher { get; set; }

        public override string ToString()
            => $"{this.Title} (ISBN: {this.ISBN}) Published {this.DatePublished} by {this.Publisher} " +
                   $"and localized by {this.LocalPublisher} in {this.LocalCountry} " +
                   $"with {this.NumberOfPages} pages.";
    }
}
