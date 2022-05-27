using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Models
{
    internal class Patent : Document
    {
        public string[] Authors { get; set; }
        public Guid Id { get; set; }
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
            => $"{this.Title} #{this.Id} Published {this.DatePublished} by {this.Authors} " +
                   $"until {this.ExpirationDate}.";
    }
}
