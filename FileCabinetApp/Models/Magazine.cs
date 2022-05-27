using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Models
{
    public class Magazine : Document
    {
        public int ReleaseNumber { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
            => $"{this.Title} #{this.ReleaseNumber} Published {this.DatePublished} by {this.Publisher}.";
    }
}
